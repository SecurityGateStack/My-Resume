using System.Globalization;
using MyRezome.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MyRezome.Services;

public static class ResumePdf
{
    private static bool _fontsReady;

    public static void RegisterFonts(string webRoot)
    {
        if (_fontsReady)
        {
            return;
        }

        var folder = Path.Combine(webRoot, "fonts");
        foreach (var file in new[] { "Vazirmatn-Regular.ttf", "Vazirmatn-Bold.ttf" })
        {
            var path = Path.Combine(folder, file);
            if (!File.Exists(path))
            {
                continue;
            }

            using var stream = File.OpenRead(path);
            FontManager.RegisterFontFromStream(stream);
        }

        _fontsReady = true;
    }

    public static byte[] Create(ResumeProfile profile, string accent)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        accent = SiteAccent.Normalize(accent);

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(32);
                page.DefaultTextStyle(style => style.FontFamily("Vazirmatn").FontSize(10).FontColor("#1c1c1c").LineHeight(1.35f));

                page.Content().Element(body =>
                {
                    var directed = profile.RightToLeft ? body.ContentFromRightToLeft() : body;
                    directed.Column(column =>
                    {
                        column.Spacing(8);
                        WriteHeader(column, profile, accent);
                        WriteFacts(column, profile);
                        WriteAbout(column, profile, accent);
                        WriteTimeline(column, profile.Labels.EducationTitle, profile.Education, accent);
                        WriteTimeline(column, profile.Labels.ExperienceTitle, profile.Experience, accent);
                        WriteSkills(column, profile, accent);
                        WriteProjects(column, profile, accent);
                        WriteServices(column, profile, accent);
                    });
                });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.DefaultTextStyle(style => style.FontFamily("Vazirmatn").FontSize(8).FontColor("#888888"));
                    text.Span(profile.Name);
                    text.Span("  ·  ");
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        }).GeneratePdf();
    }

    private static void WriteHeader(ColumnDescriptor column, ResumeProfile profile, string accent)
    {
        column.Item().Background(accent).Padding(16).Column(header =>
        {
            header.Spacing(4);
            header.Item().Text(profile.Greeting).FontSize(11).FontColor("#ffffff");
            header.Item().Text(profile.Name).FontSize(22).Bold().FontColor("#ffffff");
            header.Item().Text(profile.Headline).FontSize(11).FontColor("#ffffff");
        });
    }

    private static void WriteFacts(ColumnDescriptor column, ResumeProfile profile)
    {
        column.Item().PaddingTop(4).Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            foreach (var fact in profile.Facts)
            {
                table.Cell().PaddingBottom(6).PaddingRight(8).Column(cell =>
                {
                    cell.Item().Text(fact.Label).FontSize(8).FontColor("#777777");
                    cell.Item().Element(value => WriteValue(value, fact.Value, profile.RightToLeft));
                });
            }
        });
    }

    private static void WriteAbout(ColumnDescriptor column, ResumeProfile profile, string accent)
    {
        Section(column, profile.AboutTitle, accent, section =>
        {
            section.Item().Text(profile.AboutLead).SemiBold();
            section.Item().PaddingTop(4).Text(profile.AboutBody);
        });
    }

    private static void WriteTimeline(ColumnDescriptor column, string title, IReadOnlyList<TimelineItem> items, string accent)
    {
        if (items.Count == 0)
        {
            return;
        }

        Section(column, title, accent, section =>
        {
            foreach (var item in items)
            {
                section.Item().PaddingBottom(8).Column(entry =>
                {
                    entry.Item().Text(item.Title).SemiBold().FontSize(11);
                    entry.Item().Text(text =>
                    {
                        text.Span(item.Place).FontColor("#444444");
                        if (!string.IsNullOrWhiteSpace(item.Period))
                        {
                            text.Span("  ·  ").FontColor("#999999");
                            text.Span(item.Period).FontColor(accent);
                        }
                    });
                    if (!string.IsNullOrWhiteSpace(item.Summary))
                    {
                        entry.Item().Text(item.Summary).FontColor("#555555");
                    }
                });
            }
        });
    }

    private static void WriteSkills(ColumnDescriptor column, ResumeProfile profile, string accent)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Element(cell => SkillList(cell, profile.Labels.PersonalSkillsTitle, profile.PersonalSkills.Select(skill => (skill.Name, Percent(skill.Percent))), accent, profile.RightToLeft));
            row.ConstantItem(16);
            row.RelativeItem().Element(cell => SkillList(cell, profile.Labels.SoftwareSkillsTitle, profile.SoftwareSkills.Select(skill => (skill.Name, Percent(skill.Value))), accent, profile.RightToLeft));
        });
    }

    private static void SkillList(IContainer container, string title, IEnumerable<(string Name, string Level)> skills, string accent, bool rightToLeft)
    {
        container.Column(column =>
        {
            Section(column, title, accent, section =>
            {
                foreach (var skill in skills)
                {
                    section.Item().PaddingBottom(3).Row(line =>
                    {
                        line.RelativeItem().Element(name => WriteValue(name, skill.Name, rightToLeft));
                        line.ConstantItem(42).AlignLeft().Text(skill.Level).FontColor(accent).SemiBold();
                    });
                }
            });
        });
    }

    private static void WriteProjects(ColumnDescriptor column, ResumeProfile profile, string accent)
    {
        if (profile.Portfolio.Count == 0)
        {
            return;
        }

        Section(column, profile.Labels.PortfolioTitle, accent, section =>
        {
            foreach (var project in profile.Portfolio)
            {
                section.Item().PaddingBottom(8).Column(entry =>
                {
                    entry.Item().Text(project.Title).SemiBold().FontSize(11);
                    var meta = string.Join("  ·  ", new[] { project.Category, project.Detail?.Client, project.Detail?.Date }.Where(part => !string.IsNullOrWhiteSpace(part)));
                    if (!string.IsNullOrWhiteSpace(meta))
                    {
                        entry.Item().Text(meta).FontColor("#666666").FontSize(9);
                    }

                    var summary = project.Detail?.Paragraphs.FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(summary))
                    {
                        entry.Item().Text(summary);
                    }

                    if (!string.IsNullOrWhiteSpace(project.Detail?.Website))
                    {
                        entry.Item().Element(link =>
                        {
                            var target = profile.RightToLeft ? link.ContentFromLeftToRight() : link;
                            target.Text(project.Detail.Website).FontColor(accent).FontSize(9);
                        });
                    }
                });
            }
        });
    }

    private static void WriteServices(ColumnDescriptor column, ResumeProfile profile, string accent)
    {
        if (profile.Services.Count == 0)
        {
            return;
        }

        Section(column, profile.Labels.ServiceTitle, accent, section =>
        {
            foreach (var service in profile.Services)
            {
                section.Item().PaddingBottom(6).Column(entry =>
                {
                    entry.Item().Text(service.Title).SemiBold();
                    if (!string.IsNullOrWhiteSpace(service.Excerpt))
                    {
                        entry.Item().Text(service.Excerpt).FontColor("#555555");
                    }
                });
            }
        });
    }

    private static void Section(ColumnDescriptor column, string title, string accent, Action<ColumnDescriptor> content)
    {
        column.Item().PaddingTop(6).Text(title).FontSize(13).Bold().FontColor(accent);
        column.Item().PaddingTop(1).LineHorizontal(1).LineColor(accent);
        column.Item().PaddingTop(6).Column(content);
    }

    private static void WriteValue(IContainer container, string value, bool rightToLeft)
    {
        var target = rightToLeft && SiteCulture.KeepLtr(value)
            ? container.ContentFromLeftToRight()
            : container;
        target.Text(value);
    }

    private static string Percent(string value)
    {
        if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var number))
        {
            return value;
        }

        if (number <= 1)
        {
            number *= 100;
        }

        return $"{decimal.Round(number, 0)}%";
    }
}
