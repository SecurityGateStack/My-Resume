using MyRezome.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MyRezome.Services;

public static class ContractPdf
{
    public static byte[] Create(ResumeProfile profile, string accent)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        accent = SiteAccent.Normalize(accent);
        var contract = profile.Contract;
        var rtl = profile.RightToLeft;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(36);
                page.DefaultTextStyle(text => text
                    .FontFamily("Vazirmatn")
                    .FontSize(10)
                    .FontColor("#222222")
                    .LineHeight(1.45f));

                if (rtl)
                {
                    page.ContentFromRightToLeft();
                }

                page.Header().Element(header =>
                {
                    header.Column(col =>
                    {
                        col.Item().Text(contract.Eyebrow).FontSize(9).FontColor(accent);
                        col.Item().Text(contract.Title).FontSize(16).Bold();
                        col.Item().PaddingTop(4).LineHorizontal(1.5f).LineColor(accent);
                    });
                });

                page.Content().PaddingTop(12).Element(body =>
                {
                    var directed = rtl ? body.ContentFromRightToLeft() : body;
                    directed.Column(column =>
                    {
                    column.Spacing(8);
                    column.Item().Text(contract.Lead);
                    column.Item().Text(contract.Body).FontColor("#444444");

                    column.Item().PaddingTop(8).Background("#f7f7f7").Padding(10).Column(box =>
                    {
                        box.Spacing(4);
                        box.Item().Text(Blank(profile, "client")).SemiBold();
                        box.Item().Text(Blank(profile, "project"));
                        box.Item().Text(Blank(profile, "fee"));
                        box.Item().Text(Blank(profile, "start"));
                        box.Item().Text(Blank(profile, "end"));
                        box.Item().Text($"{Label(profile, "contractor")}: {profile.Name}");
                        box.Item().Text($"{Label(profile, "place")}: {Place(profile)}");
                    });

                    var index = 1;
                    foreach (var clause in contract.Clauses)
                    {
                        column.Item().PaddingTop(4).Text($"{index}. {clause.Title}").SemiBold().FontColor(accent);
                        column.Item().Text(clause.Body);
                        index++;
                    }

                    column.Item().PaddingTop(10).Text(contract.Disclaimer).FontSize(8).FontColor("#666666").Italic();

                    column.Item().PaddingTop(16).Row(row =>
                    {
                        row.RelativeItem().Column(sign =>
                        {
                            sign.Item().Text(Label(profile, "clientSign")).SemiBold();
                            sign.Item().PaddingTop(28).LineHorizontal(0.6f).LineColor("#999999");
                            sign.Item().PaddingTop(4).Text(Label(profile, "date")).FontSize(8).FontColor("#777777");
                        });
                        row.ConstantItem(24);
                        row.RelativeItem().Column(sign =>
                        {
                            sign.Item().Text(Label(profile, "contractorSign")).SemiBold();
                            sign.Item().PaddingTop(28).LineHorizontal(0.6f).LineColor("#999999");
                                sign.Item().PaddingTop(4).Text(profile.Name).FontSize(8).FontColor("#777777");
                        });
                    });
                    });
                });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span(profile.Name + "  ·  ").FontSize(8).FontColor("#888888");
                    text.CurrentPageNumber().FontSize(8).FontColor("#888888");
                    text.Span(" / ").FontSize(8).FontColor("#888888");
                    text.TotalPages().FontSize(8).FontColor("#888888");
                });
            });
        }).GeneratePdf();
    }

    private static string Place(ResumeProfile profile) => profile.Culture switch
    {
        "fa" => "تبریز، آذربایجان شرقی، ایران",
        "de" => "Täbris, Ost-Aserbaidschan, Iran",
        _ => "Tabriz, East Azerbaijan, Iran"
    };

    private static string Blank(ResumeProfile profile, string key) => (profile.Culture, key) switch
    {
        ("fa", "client") => "کارفرما: ................................................",
        ("fa", "project") => "عنوان پروژه: ................................................",
        ("fa", "fee") => "مبلغ کل (ریال، مگر خلاف آن نوشته شود): ................................................",
        ("fa", "start") => "تاریخ شروع: ........ / ........ / ........",
        ("fa", "end") => "تاریخ تحویل مورد توافق: ........ / ........ / ........",
        ("de", "client") => "Auftraggeber: ................................................",
        ("de", "project") => "Projekttitel: ................................................",
        ("de", "fee") => "Gesamtvergütung (IRR, sofern nichts anderes steht): ................................................",
        ("de", "start") => "Beginn: ........ / ........ / ........",
        ("de", "end") => "Vereinbarte Lieferung: ........ / ........ / ........",
        (_, "client") => "Client: ................................................",
        (_, "project") => "Project title: ................................................",
        (_, "fee") => "Total fee (IRR unless another currency is written): ................................................",
        (_, "start") => "Start date: ........ / ........ / ........",
        _ => "Agreed delivery date: ........ / ........ / ........"
    };

    private static string Label(ResumeProfile profile, string key) => (profile.Culture, key) switch
    {
        ("fa", "contractor") => "پیمانکار",
        ("fa", "place") => "محل اجرا",
        ("fa", "clientSign") => "امضای کارفرما",
        ("fa", "contractorSign") => "امضای پیمانکار",
        ("fa", "date") => "تاریخ",
        ("de", "contractor") => "Auftragnehmer",
        ("de", "place") => "Erfüllungsort",
        ("de", "clientSign") => "Unterschrift Auftraggeber",
        ("de", "contractorSign") => "Unterschrift Auftragnehmer",
        ("de", "date") => "Datum",
        (_, "contractor") => "Contractor",
        (_, "place") => "Place of performance",
        (_, "clientSign") => "Client signature",
        (_, "contractorSign") => "Contractor signature",
        _ => "Date"
    };
}
