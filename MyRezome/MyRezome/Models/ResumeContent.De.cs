namespace MyRezome.Models;

public static partial class ResumeContent
{
    private static partial ResumeProfile CreateGerman()
    {
        return new ResumeProfile
        {
            Culture = "de",
            RightToLeft = false,
            Labels = new ResumeLabels(
                DownloadCv: "Lebenslauf laden",
                ResumeEyebrow: "Lebenslauf",
                ResumeTitle: "Werdegang, Ausbildung und Kenntnisse",
                EducationTitle: "Ausbildung",
                ExperienceTitle: "Berufserfahrung",
                PersonalSkillsTitle: "Sprachen",
                SoftwareSkillsTitle: "Kernkompetenzen",
                PortfolioEyebrow: "Projekte",
                PortfolioTitle: "Umgesetzte Arbeiten",
                FilterAll: "Alle",
                FilterVimeo: "Gesundheit",
                FilterYoutube: "Verkehr",
                FilterSoundcloud: "Web",
                FilterDetail: "Details",
                Client: "Auftraggeber",
                Category: "Bereich",
                Date: "Datum",
                Share: "Netze",
                ServiceEyebrow: "Kenntnisse",
                ServiceTitle: "Womit ich Software baue",
                TestimonialsEyebrow: "Referenzen",
                TestimonialsTitle: "Stimmen",
                BlogEyebrow: "Blog",
                BlogTitle: "Notizen",
                ContactEyebrow: "Kontakt",
                ContactTitle: "Schreiben Sie mir zu einem Projekt",
                NamePlaceholder: "Ihr Name",
                EmailPlaceholder: "Ihre E-Mail",
                PhonePlaceholder: "Ihre Telefonnummer",
                SubjectPlaceholder: "Betreff",
                MessagePlaceholder: "Ihre Nachricht",
                Submit: "Senden",
                EmptyNotice: "Bitte füllen Sie die Pflichtfelder aus",
                SuccessMessage: "Ihre Nachricht ist angekommen. Ich antworte bald.",
                ContactError: "Bitte geben Sie einen gültigen Namen, eine E-Mail und eine Nachricht ein.",
                FooterCredit: "Farhad Hosseinzadeh",
                Terms: "AGB",
                Privacy: "Datenschutz",
                Login: "Anmelden",
                Language: "Sprache",
                Theme: "Farbschema",
                ThemeLight: "Hell",
                ThemeDark: "Dunkel",
                Accent: "Farbe",
                Website: "Website"),
            Name = "Farhad Hosseinzadeh",
            Greeting = "Full-Stack",
            Headline = "Full-Stack-Entwickler. Ich liefere Oberfläche und API, wohnhaft in Täbris",
            AboutEyebrow = "Über mich",
            AboutTitle = "Full-Stack-Entwickler",
            AboutLead = "Ich führe ein Produkt von der Oberfläche über die API bis zur Datenbank.",
            AboutBody = "Mein Schwerpunkt ist Full-Stack-Entwicklung, auf beiden Seiten. Oberflächen baue ich mit JavaScript und Frameworks wie Angular, React und Vue, Dienste mit C# und ASP.NET Core, einschließlich Web API und MVC. Mit Python und Go bin ich ebenfalls vertraut. Daten modelliere ich in SQL Server, MongoDB kenne ich, und für die lokale Entwicklung nutze ich Docker.",
            HeroImage = "img/hero/farhad.jpg",
            HeroThumb = "img/thumbs/47-60.jpg",
            AboutImage = "img/hero/farhad.jpg",
            AboutThumb = "img/thumbs/35-44.jpg",
            Logo = "img/logo/dark.png",
            CvUrl = "",
            VideoUrl = "",
            VideoLabel = "",
            SocialLinks =
            [
                new("img/svg/social/instagram.svg", "Far.h.a.d.e_79", "https://instagram.com/Far.h.a.d.e_79"),
                new("img/svg/social/linkedin-2.svg", "Farhad Hoseinzadeh", "https://www.linkedin.com/search/results/people/?keywords=Farhad%20Hoseinzadeh"),
                new("img/svg/social/github.svg", "ProgramerWb", "https://github.com/ProgramerWb"),
                new("img/svg/social/telegram.svg", "Farhad_Hz_Dev", "https://t.me/Farhad_Hz_Dev")
            ],
            Menu =
            [
                new("img/svg/archive.svg", "Über mich", "#about"),
                new("img/svg/contacs.svg", "Lebenslauf", "#resume"),
                new("img/svg/briefcase.svg", "Projekte", "#portfolio"),
                new("img/svg/gear.svg", "Kenntnisse", "#service"),
                new("img/svg/letter.svg", "Kontakt", "#contact")
            ],
            Facts =
            [
                new("Name", "Farhad Hosseinzadeh"),
                new("Geboren", "1371/6/6"),
                new("E-Mail", "webspacesexplorer@outlook.com"),
                new("Telefon", "+98 936 278 0737"),
                new("Adresse", "Ost-Aserbaidschan, Täbris"),
                new("Familienstand", "Verheiratet"),
                new("Wehrdienst", "Abgeleistet")
            ],
            Education =
            [
                new("Bachelor, Softwaretechnik", "Payame-Noor-Universität", "1390 – 1393", "Ost-Aserbaidschan, Täbris.")
            ],
            Experience =
            [
                new("Backend-Entwickler", "Aftab Shafa", "Farvardin 1404 – heute", "Ost-Aserbaidschan, Täbris."),
                new("Frontend-Entwickler", "Rahyaft Dadeh Pardaz Arka", "Azar 1402 – Esfand 1403", "Ost-Aserbaidschan, Täbris."),
                new("Frontend-Entwickler", "Fanavaran Ettelaat Setak", "Tir 1403 – Azar 1403", "Ost-Aserbaidschan, Täbris."),
                new("Frontend-Entwickler", "Elba Gostar", "Ordibehesht 1401 – Bahman 1401", "Ost-Aserbaidschan, Täbris."),
                new("Frontend-Praktikum", "Delorix", "1405", "Praktikum."),
                new("Frontend-Praktikum", "Elba Gostar", "1401", "Praktikum.")
            ],
            PersonalSkills =
            [
                new("Englisch, Lesen", "60"),
                new("Englisch, Schreiben", "60"),
                new("Englisch, Sprechen", "60"),
                new("Englisch, Hören", "60"),
                new("Deutsch", "50")
            ],
            SoftwareSkills =
            [
                new("C#", "0.9"),
                new("ASP.NET Core", "0.85"),
                new("JavaScript", "0.75"),
                new("SQL Server", "0.85"),
                new("Python", "0.45"),
                new("Go", "0.45")
            ],
            Portfolio =
            [
                Project("health", "Gesundheit", "Ärztekammer-System", "img/portfolio/p1.jpg", "System, über das Nutzer Beschwerden über Kliniken und Ärzte einreichen.", "Eliagostar und Fanavaran Ettelaat Setak", "Gesundheit", "—", null),
                Project("health", "Gesundheit", "Nobatall", "img/portfolio/p2.jpg", "Terminvergabe und Reservierung für Ärzte.", "Nobatall", "Gesundheit", "—", "https://nobatall.com"),
                Project("web", "Web", "Rinotex", "img/portfolio/p3.jpg", "Seite der 11. Innovations- und Technologiemesse Rabe Raschidi.", "Fanavaran Ettelaat Setak", "Messe", "—", "https://rinotex.ir"),
                Project("web", "Web", "Ideh Gostar", "img/portfolio/p4.jpg", "Veranstalter führender Weiterbildungskurse im ganzen Land.", "Fanavaran Ettelaat Setak", "Bildung", "—", "https://ide-ac.ir"),
                Project("web", "Web", "Pooshesh Omran", "img/portfolio/p5.jpg", "Chemieindustrie Pooshesh Omran.", "Fanavaran Ettelaat Setak", "Industrie", "—", "https://poschemical.com"),
                Project("fleet", "Verkehr", "UTCMS", "img/portfolio/p6.jpg", "Verwaltungssystem für städtischen und stadtnahen Verkehr, entwickelt mit C# und JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Verkehr", "—", "https://utcms.ir"),
                Project("fleet", "Verkehr", "Nationale Flottenortung", "img/portfolio/p7.jpg", "Nationales Programm zur Ausstattung von Güter- und Personenflotten mit einem Ortungssystem, entwickelt mit C# und JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Verkehr", "—", "https://sipaad.ir"),
                Project("fleet", "Verkehr", "Reifen und Motoröl", "img/portfolio/p8.jpg", "Reservierung von Reifen und Motoröl für Halter schwerer und mittelschwerer Flotten. Entwickelt mit C# und JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Verkehr", "—", "https://kalaa.ntsw.ir"),
                Project("health", "Gesundheit", "Shafadoc", "img/portfolio/p9.jpg", "Online-Terminvergabe für Ärzte.", "Entwicklungs- und IT-Netz Aftab Shafa", "Gesundheit", "Farvardin 1404", "http://shafadoc.ir")
            ],
            Services =
            [
                new("Backend", "img/svg/squares.svg", "C# und ASP.NET Core für APIs, dazu Vertrautheit mit Python und Go.", "img/service/1.jpg", ["Web API und MVC mit ASP.NET Core.", "Ältere ASP.NET-MVC-Projekte und Windows Forms.", "Vertraut mit Python und Go für ergänzende Dienste."]),
                new("Werkzeuge", "img/svg/physics.svg", "Entity Framework Core, JWT, Swagger, AutoMapper und Dependency Injection.", "img/service/2.jpg", ["Entity Framework Core.", "Dependency Injection und AutoMapper.", "JWT-Authentifizierung und Autorisierung.", "REST-APIs mit Swagger und OpenAPI."]),
                new("Datenbanken", "img/svg/web.svg", "SQL Server für Entwurf und Abfragen, dazu ein Einstieg in MongoDB.", "img/service/3.jpg", ["SQL Server: sicher im Entwurf und beim Schreiben von Abfragen.", "MongoDB: erste Arbeit mit NoSQL."]),
                new("Frontend", "img/svg/user.svg", "Oberflächen mit JavaScript, Angular, React und Vue.", "img/service/4.jpg", ["JavaScript und TypeScript.", "Umsetzung der Oberfläche mit Angular, React und Vue.", "Bootstrap, Tailwind, MUI und Ant Design."]),
                new("Architektur", "img/svg/briefcase.svg", "Microservices, serviceorientiertes Design und lokales Docker.", "img/service/5.jpg", ["Vertraut mit Microservices und serviceorientierter Architektur.", "Docker für lokale Entwicklung und Tests.", "Postman sowie Git mit GitHub und GitLab."]),
                new("Oberfläche", "img/svg/writing_2.svg", "Figma, um einen Entwurf zu lesen und die UI-Anforderungen zu entnehmen.", "img/service/6.jpg", ["Figma im Umfang von Sichten und Ableiten der UI- und UX-Anforderungen."])
            ],
            Testimonials = [],
            News = [],
            Channels =
            [
                new("img/svg/smartphone.svg", "Telefon", "+98 936 278 0737", "tel:+989362780737"),
                new("img/svg/letter.svg", "E-Mail", "webspacesexplorer@outlook.com", "mailto:webspacesexplorer@outlook.com"),
                new("img/svg/placeholder.svg", "Adresse", "Ost-Aserbaidschan, Täbris", null)
            ],
            Shapes = English.Shapes
        };
    }
}
