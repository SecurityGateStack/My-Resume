using MyRezome.Components;
using MyRezome.Models;
using MyRezome.Services;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();
ResumePdf.RegisterFonts(app.Environment.WebRootPath);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value ?? "/";
    if (path is "/" or "/en" or "/de" or "/fa")
    {
        context.Response.Cookies.Append(SiteCulture.CookieName, SiteCulture.FromPath(path), new CookieOptions
        {
            IsEssential = true,
            MaxAge = TimeSpan.FromDays(365),
            SameSite = SameSiteMode.Lax,
            Path = "/"
        });
    }

    await next();
});

app.UseAntiforgery();

app.MapPost("/modal/contact.php", async (HttpRequest request, ILoggerFactory loggerFactory) =>
{
    var form = await request.ReadFormAsync();
    var name = form["ajax_name"].ToString().Trim();
    var email = form["ajax_email"].ToString().Trim();
    var message = form["ajax_message"].ToString().Trim();
    var subject = form["ajax_subject"].ToString().Trim();

    var culture = SiteCulture.Normalize(form["ajax_culture"].ToString());
    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message)
        || !email.Contains('@', StringComparison.Ordinal) || !email.Contains('.', StringComparison.Ordinal))
    {
        var error = ResumeContent.Get(culture).Labels.ContactError;
        return Results.Content($"<span class='contact_error'>{error}</span>", "text/html");
    }

    loggerFactory.CreateLogger("ContactForm").LogInformation(
        "Resume message from {Name} <{Email}> about {Subject}",
        name,
        email,
        string.IsNullOrWhiteSpace(subject) ? "(no subject)" : subject);

    return Results.Content(string.Empty, "text/html");
}).DisableAntiforgery();

app.MapGet("/resume/{culture}/cv.pdf", (string culture, HttpRequest request) =>
{
    var profile = ResumeContent.Get(culture);
    var accent = SiteAccent.Normalize(request.Cookies[SiteAccent.CookieName]);
    var pdf = ResumePdf.Create(profile, accent);
    return Results.File(pdf, "application/pdf", $"Farhad-Hosseinzadeh-{profile.Culture}.pdf");
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
