namespace MyRezome.Models;

public static partial class ResumeContent
{
    private static partial ResumeProfile CreatePersian()
    {
        return new ResumeProfile
        {
            Culture = "fa",
            RightToLeft = true,
            Labels = new ResumeLabels(
                DownloadCv: "دانلود رزومه",
                ResumeEyebrow: "رزومه",
                ResumeTitle: "سوابق، تحصیلات و مهارت‌ها",
                EducationTitle: "سوابق تحصیلی",
                ExperienceTitle: "سوابق شغلی",
                PersonalSkillsTitle: "زبان‌ها",
                SoftwareSkillsTitle: "مهارت‌های اصلی",
                PortfolioEyebrow: "پروژه‌ها",
                PortfolioTitle: "کارهایی که انجام داده‌ام",
                FilterAll: "همه",
                FilterVimeo: "درمان",
                FilterYoutube: "حمل‌ونقل",
                FilterSoundcloud: "وب",
                FilterDetail: "جزئیات",
                Client: "کارفرما",
                Category: "دسته",
                Date: "تاریخ",
                Share: "شبکه‌ها",
                ServiceEyebrow: "مهارت‌ها",
                ServiceTitle: "ابزارهایی که با آن‌ها نرم‌افزار می‌سازم",
                TestimonialsEyebrow: "نظرات",
                TestimonialsTitle: "دیگران چه می‌گویند",
                BlogEyebrow: "وبلاگ",
                BlogTitle: "یادداشت‌ها",
                ContactEyebrow: "تماس",
                ContactTitle: "برای همکاری در تماس باشید",
                NamePlaceholder: "نام شما",
                EmailPlaceholder: "ایمیل شما",
                PhonePlaceholder: "تلفن شما",
                SubjectPlaceholder: "موضوع",
                MessagePlaceholder: "پیام شما",
                Submit: "ارسال",
                EmptyNotice: "فیلدهای ضروری را پر کنید",
                SuccessMessage: "پیام شما دریافت شد. به‌زودی پاسخ می‌دهم.",
                ContactError: "لطفاً نام، ایمیل و پیام معتبر وارد کنید.",
                FooterCredit: "فرهاد حسین‌زاده",
                Terms: "شرایط",
                Privacy: "حریم خصوصی",
                Login: "ورود",
                Language: "زبان",
                Theme: "رنگ زمینه",
                ThemeLight: "روشن",
                ThemeDark: "تیره",
                Accent: "رنگ",
                Website: "وب‌سایت"),
            Name = "فرهاد حسین‌زاده",
            Greeting = "فول‌استک",
            Headline = "توسعه‌دهنده فول‌استک؛ فرانت‌اند و بک‌اند را با هم تحویل می‌دهم. مقیم تبریز",
            AboutEyebrow = "درباره من",
            AboutTitle = "توسعه‌دهنده فول‌استک",
            AboutLead = "محصول وب را از نیاز شرکت تا نسخه‌ای که بشود به مشتری داد، یکجا می‌سازم.",
            AboutBody = "وقتی پروژه‌ای هم به رابط کاربری نیاز دارد و هم به سرویس پشت آن، هر دو را با هم پیش می‌برم. فرانت‌اند را با JavaScript و Angular، React یا Vue می‌سازم و بک‌اند را با C# و ASP.NET Core، شامل Web API. داده را در SQL Server طراحی می‌کنم و احراز هویت، مجوزدهی و اعتبارسنجی را از همان اول در کار می‌گذارم. با Python، Go، Docker، MongoDB و تست نفوذ وب در سطح کاربردی آشنا هستم، از جمله ضعف‌های رایج OWASP Top 10. می‌توانم یک قابلیت یا یک محصول کامل را، از توافق روی محدوده تا تحویل، کنار تیم شما جلو ببرم.",
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
                new("img/svg/archive.svg", "درباره من", "#about"),
                new("img/svg/contacs.svg", "رزومه", "#resume"),
                new("img/svg/briefcase.svg", "پروژه‌ها", "#portfolio"),
                new("img/svg/gear.svg", "مهارت‌ها", "#service"),
                new("img/svg/letter.svg", "تماس", "#contact")
            ],
            Facts =
            [
                new("نام", "فرهاد حسین‌زاده"),
                new("تولد", "۱۳۷۶/۰۶/۳۱"),
                new("ایمیل", "webspacesexplorer@outlook.com"),
                new("تلفن", "+98 936 278 0737"),
                new("نشانی", "آذربایجان شرقی، تبریز"),
                new("وضعیت تأهل", "متأهل"),
                new("وضعیت سربازی", "پایان خدمت")
            ],
            Education =
            [
                new("کارشناسی مهندسی نرم‌افزار", "دانشگاه پیام نور", "۱۳۹۳ تا ۱۳۹۶", "آذربایجان شرقی، تبریز.")
            ],
            Experience =
            [
                new("برنامه‌نویس Back-End", "آفتاب شفا", "فروردین ۱۴۰۴ تا اکنون", "آذربایجان شرقی، تبریز."),
                new("Front-End Developer", "رهیافت داده پرداز آرکا", "آذر ۱۴۰۲ تا اسفند ۱۴۰۳", "آذربایجان شرقی، تبریز."),
                new("Front-End Developer", "فناوری و اطلاعات ستاک", "تیر ۱۴۰۳ تا آذر ۱۴۰۳", "آذربایجان شرقی، تبریز."),
                new("Front-End Developer", "البا گستر", "اردیبهشت ۱۴۰۱ تا بهمن ۱۴۰۱", "آذربایجان شرقی، تبریز."),
                new("کارآموز فرانت‌اند", "Delorix", "۱۴۰۵", "دوره کارآموزی."),
                new("کارآموز Front-End", "البا گستر", "۱۴۰۱", "دوره کارآموزی.")
            ],
            PersonalSkills =
            [
                new("انگلیسی، خواندن", "60"),
                new("انگلیسی، نوشتن", "60"),
                new("انگلیسی، گفتاری", "60"),
                new("انگلیسی، شنیداری", "60"),
                new("آلمانی", "50")
            ],
            SoftwareSkills =
            [
                new("C#", "0.9"),
                new("ASP.NET Core", "0.85"),
                new("JavaScript", "0.75"),
                new("SQL Server", "0.85"),
                new("Python", "0.45"),
                new("Go", "0.45"),
                new("امنیت", "0.45")
            ],
            Portfolio =
            [
                Project("health", "درمان", "نظام پزشکی", "img/portfolio/p1.jpg", "سامانه ثبت شکایت کاربران از مراکز درمانی و پزشکان.", "شرکت الیاگستر و فناوران اطلاعات و ارتباطات ستاک", "درمان", "—", null),
                Project("health", "درمان", "نوبت‌ال", "img/portfolio/p2.jpg", "نوبت‌دهی و رزرو وقت برای پزشکان.", "نوبت‌ال", "درمان", "—", "https://nobatall.com"),
                Project("web", "وب", "رینوتکس", "img/portfolio/p3.jpg", "یازدهمین نمایشگاه نوآوری و فناوری ربع رشیدی.", "فناوران اطلاعات و ارتباطات ستاک", "نمایشگاه", "—", "https://rinotex.ir"),
                Project("web", "وب", "ایده‌گستر", "img/portfolio/p4.jpg", "مجری برگزاری دوره‌های آموزشی در حوزه مهارت‌آموزی در سراسر کشور.", "فناوران اطلاعات و ارتباطات ستاک", "آموزش", "—", "https://ide-ac.ir"),
                Project("web", "وب", "پوشش عمران", "img/portfolio/p5.jpg", "صنایع شیمی پوشش عمران.", "فناوران اطلاعات و ارتباطات ستاک", "صنعت", "—", "https://poschemical.com"),
                Project("fleet", "حمل‌ونقل", "سامانه ملی UTCMS", "img/portfolio/p6.jpg", "سامانه مدیریت حمل‌ونقل درون‌شهری و حومه‌ای که با C# و JavaScript توسعه داده شده است.", "رهیافت داده پرداز آرکا", "حمل‌ونقل", "—", "https://utcms.ir"),
                Project("fleet", "حمل‌ونقل", "سامانه پیمایش ناوگان", "img/portfolio/p7.jpg", "طرح ملی تجهیز ناوگان حمل‌ونقل بار و مسافر به سامانه پیمایش، توسعه‌داده‌شده با C# و JavaScript.", "رهیافت داده پرداز آرکا", "حمل‌ونقل", "—", "https://sipaad.ir"),
                Project("fleet", "حمل‌ونقل", "تایر و روغن موتور", "img/portfolio/p8.jpg", "ثبت درخواست رزرو تایر و روغن موتور برای دارندگان ناوگان سنگین و نیمه‌سنگین. توسعه‌داده‌شده با C# و JavaScript.", "رهیافت داده پرداز آرکا", "حمل‌ونقل", "—", "https://kalaa.ntsw.ir"),
                Project("health", "درمان", "شفاداک", "img/portfolio/p9.jpg", "نوبت‌دهی آنلاین برای پزشکان.", "شبکه توسعه و فناوری اطلاعات آفتاب شفا", "درمان", "فروردین ۱۴۰۴", "http://shafadoc.ir")
            ],
            Services =
            [
                new("بک‌اند", "img/svg/squares.svg", "C# و ASP.NET Core برای API، و آشنایی با Python و Go.", "img/service/1.jpg", ["Web API و MVC با ASP.NET Core.", "پروژه‌های قدیمی ASP.NET MVC و Windows Forms.", "آشنا با Python و Go برای سرویس‌های جانبی."]),
                new("ابزارهای مکمل", "img/svg/physics.svg", "Entity Framework Core، JWT، Swagger، AutoMapper و تزریق وابستگی.", "img/service/2.jpg", ["Entity Framework Core.", "تزریق وابستگی و AutoMapper.", "احراز هویت و مجوزدهی JWT.", "توسعه REST API و مستندسازی با Swagger و OpenAPI."]),
                new("پایگاه داده", "img/svg/web.svg", "SQL Server برای طراحی و کوئری، و آشنایی با MongoDB.", "img/service/3.jpg", ["SQL Server: مسلط به طراحی و کوئری‌نویسی.", "MongoDB: آشنایی و کار اولیه با NoSQL."]),
                new("فرانت‌اند", "img/svg/user.svg", "رابط کاربری با JavaScript، Angular، React و Vue.", "img/service/4.jpg", ["JavaScript و TypeScript.", "پیاده‌سازی رابط با Angular، React و Vue.", "Bootstrap، Tailwind، MUI و Ant Design."]),
                new("معماری", "img/svg/briefcase.svg", "میکروسرویس، طراحی سرویس‌محور و Docker محلی.", "img/service/5.jpg", ["آشنا با میکروسرویس و معماری سرویس‌محور.", "Docker برای توسعه و تست محلی.", "Postman و Git برای GitHub و GitLab."]),
                new("رابط کاربری", "img/svg/writing_2.svg", "Figma در حد دیدن طرح و استخراج نیازمندی‌های رابط.", "img/service/6.jpg", ["Figma در حد مشاهده و استخراج نیازمندی‌های UI و UX."]),
                new("امنیت نرم‌افزار", "img/svg/gear.svg", "پیاده‌سازی امنیت در پروژه، و آشنایی کلی با تست نفوذ وب.", "img/service/2.jpg", ["احراز هویت، مجوزدهی و اعتبارسنجی ورودی در API و رابط کاربری.", "نگهداری امن‌تر رازها، پیکربندی، HTTPS و وابستگی‌ها.", "آشنا با OWASP Top 10 و بررسی وب‌اپلیکیشن برای ضعف‌های رایج.", "تست نفوذ در سطح کلی: توافق روی محدوده، بررسی برنامه و نوشتن گزارش یافته‌ها."])
            ],
            Testimonials = [],
            News = [],
            Channels =
            [
                new("img/svg/smartphone.svg", "تلفن", "+98 936 278 0737", "tel:+989362780737"),
                new("img/svg/letter.svg", "ایمیل", "webspacesexplorer@outlook.com", "mailto:webspacesexplorer@outlook.com"),
                new("img/svg/placeholder.svg", "نشانی", "آذربایجان شرقی، تبریز", null)
            ],
            Shapes = English.Shapes
        };
    }
}
