using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace MyRezome.Services;

public static class ContractUpload
{
    public const long MaxBytes = 8 * 1024 * 1024;

    private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".pdf", ".doc", ".docx"
    };

    public static async Task<(bool Ok, string Code)> SaveAsync(
        IWebHostEnvironment environment,
        IFormFile? file,
        string partyName,
        string partyEmail,
        string culture,
        CancellationToken cancellationToken)
    {
        if (file is null || file.Length <= 0 || file.Length > MaxBytes)
        {
            return (false, "type");
        }

        var extension = Path.GetExtension(file.FileName);
        if (!AllowedExtensions.Contains(extension) || !LooksLikeAllowedFile(file, extension))
        {
            return (false, "type");
        }

        var folder = Path.Combine(environment.ContentRootPath, "App_Data", "contracts");
        Directory.CreateDirectory(folder);

        var stamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
        var safeName = Sanitize(partyName);
        var safeCulture = culture is "fa" or "de" or "en" ? culture : "en";
        var stored = $"{stamp}-{safeCulture}-{safeName}{extension.ToLowerInvariant()}";
        var path = Path.Combine(folder, stored);

        await using (var stream = File.Create(path))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }

        var note = Path.Combine(folder, Path.ChangeExtension(stored, ".txt"));
        await File.WriteAllTextAsync(
            note,
            $"name={partyName}{Environment.NewLine}email={partyEmail}{Environment.NewLine}original={file.FileName}{Environment.NewLine}utc={DateTime.UtcNow:O}{Environment.NewLine}",
            cancellationToken);

        return (true, "ok");
    }

    private static bool LooksLikeAllowedFile(IFormFile file, string extension)
    {
        Span<byte> header = stackalloc byte[8];
        using var stream = file.OpenReadStream();
        var read = stream.Read(header);
        if (read < 4)
        {
            return false;
        }

        if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            return header[0] == (byte)'%' && header[1] == (byte)'P' && header[2] == (byte)'D' && header[3] == (byte)'F';
        }

        if (extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
        {
            return header[0] == 0x50 && header[1] == 0x4B;
        }

        return header[0] == 0xD0 && header[1] == 0xCF && header[2] == 0x11 && header[3] == 0xE0;
    }

    private static string Sanitize(string name)
    {
        var trimmed = string.Join("-", name.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
        var safe = Regex.Replace(trimmed, @"[^\p{L}\p{N}-]+", "");
        return string.IsNullOrWhiteSpace(safe) ? "client" : safe[..Math.Min(safe.Length, 40)];
    }
}
