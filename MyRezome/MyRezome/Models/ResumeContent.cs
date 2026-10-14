namespace MyRezome.Models;

public sealed record SocialLink(string Icon, string Label, string Url);

public sealed record MenuLink(string Icon, string Label, string Target);

public sealed record ProfileFact(string Label, string Value);

public sealed record TimelineItem(string Title, string Place, string Period, string Summary);

public sealed record LinearSkill(string Name, string Percent);

public sealed record CircularSkill(string Name, string Value);

public sealed record PortfolioDetail(
    IReadOnlyList<string> Paragraphs,
    string Client,
    string Category,
    string Date,
    IReadOnlyList<string> Gallery,
    string? Website = null);

public sealed record PortfolioItem(
    string Filter,
    string Category,
    string Title,
    string Image,
    string Icon,
    string LinkClass,
    string Url,
    PortfolioDetail? Detail);

public sealed record ServiceItem(
    string Title,
    string Icon,
    string Excerpt,
    string Image,
    IReadOnlyList<string> Paragraphs);

public sealed record Testimonial(string Quote, string Name, string Role, string Avatar);

public sealed record NewsPost(string Category, string Title, string Image, IReadOnlyList<string> Paragraphs);

public sealed record ContactChannel(string Icon, string Title, string Value, string? Url);

public sealed record HeroShape(string CssClass, string Icon);

public sealed record ResumeLabels(
    string DownloadCv,
    string ResumeEyebrow,
    string ResumeTitle,
    string EducationTitle,
    string ExperienceTitle,
    string PersonalSkillsTitle,
    string SoftwareSkillsTitle,
    string PortfolioEyebrow,
    string PortfolioTitle,
    string FilterAll,
    string FilterVimeo,
    string FilterYoutube,
    string FilterSoundcloud,
    string FilterDetail,
    string Client,
    string Category,
    string Date,
    string Share,
    string ServiceEyebrow,
    string ServiceTitle,
    string TestimonialsEyebrow,
    string TestimonialsTitle,
    string BlogEyebrow,
    string BlogTitle,
    string ContactEyebrow,
    string ContactTitle,
    string NamePlaceholder,
    string EmailPlaceholder,
    string PhonePlaceholder,
    string SubjectPlaceholder,
    string MessagePlaceholder,
    string Submit,
    string EmptyNotice,
    string SuccessMessage,
    string ContactError,
    string FooterCredit,
    string Terms,
    string Privacy,
    string Login,
    string Language,
    string Theme,
    string ThemeLight,
    string ThemeDark,
    string Accent,
    string Website);

public sealed record LanguageOption(string Code, string ShortLabel, string NativeName, string Path);

public static class SiteCulture
{
    public const string CookieName = "resume-lang";

    public static readonly LanguageOption[] Options =
    [
        new("en", "EN", "English", "/"),
        new("de", "DE", "Deutsch", "/de"),
        new("fa", "فا", "فارسی", "/fa")
    ];

    public static string FromPath(string? path)
    {
        var segment = path?.Trim('/').Split('/', 2, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        return Normalize(segment);
    }

    public static string Normalize(string? culture) => culture?.ToLowerInvariant() switch
    {
        "de" or "de-de" => "de",
        "fa" or "fa-ir" => "fa",
        _ => "en"
    };

    public static bool IsRtl(string culture) => culture == "fa";

    public static bool KeepLtr(string value) =>
        value.Contains('@', StringComparison.Ordinal)
        || value.Contains('+', StringComparison.Ordinal)
        || value.Any(char.IsAsciiDigit);
}

public static class SiteTheme
{
    public const string CookieName = "resume-theme";
    public const string Light = "light";
    public const string Dark = "dark";

    public static bool IsDark(string? value) =>
        string.Equals(value, Dark, StringComparison.OrdinalIgnoreCase);
}

public static class SiteAccent
{
    public const string CookieName = "resume-accent";
    public const string Default = "#ff451b";

    public static string Normalize(string? value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 7 || value[0] != '#')
        {
            return Default;
        }

        for (var index = 1; index < value.Length; index++)
        {
            if (!Uri.IsHexDigit(value[index]))
            {
                return Default;
            }
        }

        return value.ToLowerInvariant();
    }
}

public sealed class ResumeProfile
{
    public required string Culture { get; init; }
    public required bool RightToLeft { get; init; }
    public required ResumeLabels Labels { get; init; }
    public required string Name { get; init; }
    public required string Greeting { get; init; }
    public required string Headline { get; init; }
    public required string AboutEyebrow { get; init; }
    public required string AboutTitle { get; init; }
    public required string AboutLead { get; init; }
    public required string AboutBody { get; init; }
    public required string HeroImage { get; init; }
    public required string HeroThumb { get; init; }
    public required string AboutImage { get; init; }
    public required string AboutThumb { get; init; }
    public required string Logo { get; init; }
    public required string CvUrl { get; init; }
    public required string VideoUrl { get; init; }
    public required string VideoLabel { get; init; }
    public required IReadOnlyList<SocialLink> SocialLinks { get; init; }
    public required IReadOnlyList<MenuLink> Menu { get; init; }
    public required IReadOnlyList<ProfileFact> Facts { get; init; }
    public required IReadOnlyList<TimelineItem> Education { get; init; }
    public required IReadOnlyList<TimelineItem> Experience { get; init; }
    public required IReadOnlyList<LinearSkill> PersonalSkills { get; init; }
    public required IReadOnlyList<CircularSkill> SoftwareSkills { get; init; }
    public required IReadOnlyList<PortfolioItem> Portfolio { get; init; }
    public required IReadOnlyList<ServiceItem> Services { get; init; }
    public required IReadOnlyList<Testimonial> Testimonials { get; init; }
    public required IReadOnlyList<NewsPost> News { get; init; }
    public required IReadOnlyList<ContactChannel> Channels { get; init; }
    public required IReadOnlyList<HeroShape> Shapes { get; init; }
}

public static partial class ResumeContent
{
    public static ResumeProfile English { get; } = CreateEnglish();
    public static ResumeProfile German { get; } = CreateGerman();
    public static ResumeProfile Persian { get; } = CreatePersian();
    public static ResumeProfile Profile => English;

    public static ResumeProfile Get(string? culture) => SiteCulture.Normalize(culture) switch
    {
        "de" => German,
        "fa" => Persian,
        _ => English
    };

    private static partial ResumeProfile CreateGerman();
    private static partial ResumeProfile CreatePersian();

    private static PortfolioItem Project(string filter, string category, string title, string image, string summary, string client, string kind, string date, string? website) =>
        new(filter, category, title, image, "img/svg/web.svg", "portfolio_popup", "#",
            new PortfolioDetail([summary], client, kind, date, [], website));

    private static ResumeProfile CreateEnglish()
    {
        return new ResumeProfile
        {
            Culture = "en",
            RightToLeft = false,
            Labels = new ResumeLabels(
                DownloadCv: "Download CV",
                ResumeEyebrow: "Resume",
                ResumeTitle: "Experience, education, and skills",
                EducationTitle: "Education",
                ExperienceTitle: "Work history",
                PersonalSkillsTitle: "Languages",
                SoftwareSkillsTitle: "Core skills",
                PortfolioEyebrow: "Projects",
                PortfolioTitle: "Work I have shipped",
                FilterAll: "All",
                FilterVimeo: "Healthcare",
                FilterYoutube: "Transport",
                FilterSoundcloud: "Web",
                FilterDetail: "Detail",
                Client: "Client",
                Category: "Category",
                Date: "Date",
                Share: "Share",
                ServiceEyebrow: "Skills",
                ServiceTitle: "What I use to build software",
                TestimonialsEyebrow: "Testimonials",
                TestimonialsTitle: "What people say about me",
                BlogEyebrow: "Blog",
                BlogTitle: "Latest tips, tricks & Updates",
                ContactEyebrow: "Contact",
                ContactTitle: "Get in touch about a project",
                NamePlaceholder: "Your Name",
                EmailPlaceholder: "Your Email",
                PhonePlaceholder: "Your Phone",
                SubjectPlaceholder: "Subject",
                MessagePlaceholder: "Your message here",
                Submit: "Submit Now",
                EmptyNotice: "Please Fill Required Fields",
                SuccessMessage: "Your message has been received, We will contact you soon.",
                ContactError: "Please enter a valid name, email, and message.",
                FooterCredit: "Designed with love",
                Terms: "Terms & Condition",
                Privacy: "Privacy Policy",
                Login: "Login",
                Language: "Language",
                Theme: "Color theme",
                ThemeLight: "Light",
                ThemeDark: "Dark",
                Accent: "Color",
                Website: "Website"),
            Name = "Farhad Hosseinzadeh",
            Greeting = "Full-stack",
            Headline = "Full-stack developer. I ship the interface and the API, based in Tabriz",
            AboutEyebrow = "About me",
            AboutTitle = "Full-stack developer",
            AboutLead = "I take a product from the screen, through the API, to the database.",
            AboutBody = "My main work is full-stack development, on both the front end and the back end. I build interfaces with JavaScript and frameworks such as Angular, React, and Vue, and services with C# and ASP.NET Core, including Web API and MVC. I am also familiar with Python and Go. I design data in SQL Server, have worked with MongoDB, and use Docker for local development.",
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
                new("img/svg/archive.svg", "About", "#about"),
                new("img/svg/contacs.svg", "Resume", "#resume"),
                new("img/svg/briefcase.svg", "Projects", "#portfolio"),
                new("img/svg/gear.svg", "Skills", "#service"),
                new("img/svg/letter.svg", "Contact", "#contact")
            ],
            Facts =
            [
                new("Name", "Farhad Hosseinzadeh"),
                new("Born", "1371/6/6"),
                new("Email", "webspacesexplorer@outlook.com"),
                new("Phone", "+98 936 278 0737"),
                new("Address", "East Azerbaijan, Tabriz"),
                new("Marital status", "Married"),
                new("Military service", "Completed")
            ],
            Education =
            [
                new("Bachelor's degree, Software Engineering", "Payame Noor University", "1390 – 1393", "East Azerbaijan, Tabriz.")
            ],
            Experience =
            [
                new("Back-end programmer", "Aftab Shafa", "Farvardin 1404 – present", "East Azerbaijan, Tabriz."),
                new("Front-end developer", "Rahyaft Dadeh Pardaz Arka", "Azar 1402 – Esfand 1403", "East Azerbaijan, Tabriz."),
                new("Front-end developer", "Fanavaran Ettelaat Setak", "Tir 1403 – Azar 1403", "East Azerbaijan, Tabriz."),
                new("Front-end developer", "Elba Gostar", "Ordibehesht 1401 – Bahman 1401", "East Azerbaijan, Tabriz."),
                new("Front-end internship", "Delorix", "1405", "Internship."),
                new("Front-end internship", "Elba Gostar", "1401", "Internship.")
            ],
            PersonalSkills =
            [
                new("English, reading", "60"),
                new("English, writing", "60"),
                new("English, speaking", "60"),
                new("English, listening", "60"),
                new("German", "50")
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
                Project("health", "Healthcare", "Medical council system", "img/portfolio/p1.jpg", "A system for users to file complaints about clinics and physicians.", "Eliagostar, and Fanavaran Ettelaat Setak", "Healthcare", "—", null),
                Project("health", "Healthcare", "Nobatall", "img/portfolio/p2.jpg", "Appointment booking for physicians.", "Nobatall", "Healthcare", "—", "https://nobatall.com"),
                Project("web", "Web", "Rinotex", "img/portfolio/p3.jpg", "Site for the 11th Rabe Rashidi innovation and technology exhibition.", "Fanavaran Ettelaat Setak", "Exhibition", "—", "https://rinotex.ir"),
                Project("web", "Web", "Ideh Gostar", "img/portfolio/p4.jpg", "Organizer of leading vocational-training courses across the country.", "Fanavaran Ettelaat Setak", "Education", "—", "https://ide-ac.ir"),
                Project("web", "Web", "Pooshesh Omran", "img/portfolio/p5.jpg", "Pooshesh Omran chemical industries.", "Fanavaran Ettelaat Setak", "Industry", "—", "https://poschemical.com"),
                Project("fleet", "Transport", "UTCMS", "img/portfolio/p6.jpg", "Urban and suburban transport management system, built with C# and JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Transport", "—", "https://utcms.ir"),
                Project("fleet", "Transport", "National fleet tracking", "img/portfolio/p7.jpg", "National program for fitting freight and passenger fleets with a tracking system, built with C# and JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Transport", "—", "https://sipaad.ir"),
                Project("fleet", "Transport", "Tire and engine-oil desk", "img/portfolio/p8.jpg", "Reservation requests for tires and engine oil, for owners of heavy and semi-heavy fleets. Built with C# and JavaScript.", "Rahyaft Dadeh Pardaz Arka", "Transport", "—", "https://kalaa.ntsw.ir"),
                Project("health", "Healthcare", "Shafadoc", "img/portfolio/p9.jpg", "Online appointment booking for physicians.", "Aftab Shafa development and IT network", "Healthcare", "Farvardin 1404", "http://shafadoc.ir")
            ],
            Services =
            [
                new("Back end", "img/svg/squares.svg", "C# and ASP.NET Core for APIs, plus familiarity with Python and Go.", "img/service/1.jpg", ["Web API and MVC on ASP.NET Core.", "Legacy ASP.NET MVC and Windows Forms.", "Familiar with Python and Go for supporting services."]),
                new("Supporting tools", "img/svg/physics.svg", "Entity Framework Core, JWT, Swagger, AutoMapper, and dependency injection.", "img/service/2.jpg", ["Entity Framework Core.", "Dependency injection and AutoMapper.", "JWT authentication and authorization.", "REST APIs documented with Swagger and OpenAPI."]),
                new("Databases", "img/svg/web.svg", "SQL Server for design and queries, plus an introduction to MongoDB.", "img/service/3.jpg", ["SQL Server: comfortable with schema design and query writing.", "MongoDB: introductory NoSQL work."]),
                new("Front end", "img/svg/user.svg", "Interfaces with JavaScript, Angular, React, and Vue.", "img/service/4.jpg", ["JavaScript and TypeScript.", "UI implementation with Angular, React, and Vue.", "Bootstrap, Tailwind, MUI, and Ant Design."]),
                new("Architecture", "img/svg/briefcase.svg", "Microservices, service-oriented design, and local Docker.", "img/service/5.jpg", ["Familiar with microservices and service-oriented architecture.", "Docker for local development and testing.", "Postman, and Git with GitHub and GitLab."]),
                new("Interface notes", "img/svg/writing_2.svg", "Figma, used to read a screen and pull out the UI requirements.", "img/service/6.jpg", ["Figma at the level of reviewing a file and extracting UI and UX requirements."])
            ],
            Testimonials = [],
            News = [],
            Channels =
            [
                new("img/svg/smartphone.svg", "Phone", "+98 936 278 0737", "tel:+989362780737"),
                new("img/svg/letter.svg", "Email", "webspacesexplorer@outlook.com", "mailto:webspacesexplorer@outlook.com"),
                new("img/svg/placeholder.svg", "Address", "East Azerbaijan, Tabriz", null)
            ],
            Shapes =
            [
                new("one anim_scale", "img/svg/shapes/9.svg"),
                new("two anim_moveLeft", "img/svg/shapes/dot.svg"),
                new("three anim_moveTop", "img/svg/shapes/dot-2.svg"),
                new("four anim_circle", "img/svg/shapes/1.svg"),
                new("five anim_circle", "img/svg/shapes/8.svg"),
                new("six anim_circle", "img/svg/shapes/3.svg"),
                new("seven anim_right", "img/svg/shapes/4.svg"),
                new("eight anim_scale", "img/svg/shapes/9.svg"),
                new("nine anim_circle", "img/svg/shapes/3.svg"),
                new("ten anim_moveLeft", "img/svg/shapes/4.svg"),
                new("eleven anim_scale", "img/svg/shapes/9.svg"),
                new("twelve anim_extra", "img/svg/shapes/2.svg"),
                new("thirteen anim_circle", "img/svg/shapes/5.svg"),
                new("fourteen anim_scale", "img/svg/shapes/9.svg"),
                new("fifteen anim_circle", "img/svg/shapes/3.svg"),
                new("sixteen anim_scale", "img/svg/shapes/9.svg"),
                new("seventeen anim_circle", "img/svg/shapes/5.svg"),
                new("eighteen anim_scale", "img/svg/shapes/9.svg"),
                new("nineteen anim_scale", "img/svg/shapes/9.svg"),
                new("twenty anim_circle", "img/svg/shapes/1.svg")
            ]
        };
    }
}
