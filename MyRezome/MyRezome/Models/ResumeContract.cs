namespace MyRezome.Models;

public static class ResumeContract
{
    public static ContractContent English { get; } = new(
        Eyebrow: "Work contract",
        Title: "Project agreement for software work",
        Lead: "Download a working contract, fill the blanks with the client, then upload the signed file so the project can start on a written basis.",
        Body: "This is a freelance software-development template for a named project. It follows ordinary contract structure: parties, subject, scope, payment, delivery of source, intellectual property after full payment, confidentiality, delay, termination, and Iranian law with the place of performance in Tabriz. Amounts, dates, and the client name stay blank until both sides write them in. It is a working document for negotiation, not a substitute for a lawyer on a large or unusual deal.",
        Download: "Download contract",
        Upload: "Upload signed contract",
        NamePlaceholder: "Client name",
        EmailPlaceholder: "Client email",
        FileLabel: "Signed file (PDF, DOC, or DOCX, up to 8 MB)",
        UploadHint: "Upload the filled and signed copy. PDF is preferred.",
        Success: "The contract file was received. I will review it and reply.",
        Error: "Please enter the client name, a valid email, and a contract file.",
        FileTypeError: "Only PDF, DOC, or DOCX files up to 8 MB are accepted.",
        Disclaimer: "This template is a working starting point for a software project. It does not create a licensed legal opinion. For a high-value or unusual engagement, have a qualified lawyer review the final text before signing.",
        Clauses:
        [
            new("Parties", "The contractor is Farhad Hosseinzadeh, software developer, East Azerbaijan, Tabriz. The client (employer) is the natural or legal person named on the first page. This agreement does not create an employment, partnership, or agency relationship."),
            new("Subject", "Design, development, or delivery of a software or web product described in the project annex, against the fee and timetable written by the parties."),
            new("Scope and changes", "Work starts only on the written scope. Extra features, redesign, or new integrations need written agreement and may change the fee and the delivery date."),
            new("Deliverables and source", "Unless the annex says otherwise, delivery includes the agreed running version and the project source needed to build and maintain it, after the conditions of payment are met."),
            new("Payment", "The fee is the amount written on the first page, in Iranian Rial unless the parties write another currency. Work that depends on a first installment does not start until that installment is received. Later installments follow the written stages. Full intellectual-property transfer waits for full payment."),
            new("Acceptance", "The client has seven calendar days after each delivery to report defects inside the agreed scope in writing. Silence in that period counts as acceptance of that delivery, except for hidden defects reported without delay."),
            new("Intellectual property", "Until full payment, the contractor keeps the rights in the custom work. After full payment, those rights in the custom work for this project pass to the client. Third-party libraries, fonts, and tools stay under their own licenses. The contractor may reuse general methods and know-how that are not the client’s confidential material."),
            new("Confidentiality", "Each party keeps the other party’s non-public information confidential during the project and for two years after, except where disclosure is required by law."),
            new("Delay and termination", "A party may terminate in writing if a material breach is not cured within ten calendar days of notice. For convenience, either party may terminate with fourteen calendar days’ written notice; work already accepted is paid, and unfinished work is settled in proportion. Force majeure suspends timelines while it lasts."),
            new("Law and disputes", "The governing law is the law of the Islamic Republic of Iran. The place of performance is Tabriz. The parties first try to settle in good faith; remaining disputes go to the competent courts of Tabriz."),
            new("Form", "The downloaded file is one original. A signed scan or a signed upload has the same effect between the parties as a paper original, unless a later written change replaces it.")
        ]);

    public static ContractContent Persian { get; } = new(
        Eyebrow: "قرارداد کاری",
        Title: "قرارداد انجام پروژه نرم‌افزاری",
        Lead: "قرارداد را دانلود کنید، جاهای خالی را با کارفرما پر کنید، نسخه امضاشده را بارگذاری کنید تا کار روی مبنای مکتوب شروع شود.",
        Body: "این متن یک الگوی قراردادی برای توسعه نرم‌افزار به‌صورت پیمانی است. ساختار آن مطابق اصول رایج قرارداد است: طرفین، موضوع، محدوده کار، مبلغ و مراحل پرداخت، تحویل سورس، انتقال مالکیت فکری پس از تسویه کامل، محرمانگی، تأخیر، فسخ، و قانون حاکم جمهوری اسلامی ایران با محل اجرای تبریز. مبلغ، تاریخ و نام کارفرما تا وقتی دو طرف ننویسند خالی می‌ماند. این سند مبنای مذاکره و شروع کار است، نه جایگزین نظر وکیل در قراردادهای بزرگ یا غیرمعمول.",
        Download: "دانلود قرارداد",
        Upload: "بارگذاری قرارداد امضاشده",
        NamePlaceholder: "نام کارفرما",
        EmailPlaceholder: "ایمیل کارفرما",
        FileLabel: "فایل امضاشده (PDF، DOC یا DOCX تا ۸ مگابایت)",
        UploadHint: "نسخه تکمیل و امضاشده را بارگذاری کنید. ترجیح با PDF است.",
        Success: "فایل قرارداد دریافت شد. بررسی می‌کنم و پاسخ می‌دهم.",
        Error: "نام کارفرما، ایمیل معتبر و فایل قرارداد را وارد کنید.",
        FileTypeError: "فقط فایل PDF، DOC یا DOCX تا ۸ مگابایت پذیرفته می‌شود.",
        Disclaimer: "این الگو نقطه شروع کاری برای پروژه نرم‌افزاری است و نظر حقوقی دارای پروانه وکالت نیست. در قرارداد با مبلغ بالا یا شرایط غیرمعمول، متن نهایی را پیش از امضا با وکیل واجد صلاحیت بررسی کنید.",
        Clauses:
        [
            new("طرفین", "پیمانکار: فرهاد حسین‌زاده، برنامه‌نویس نرم‌افزار، آذربایجان شرقی، تبریز. کارفرما شخص حقیقی یا حقوقی است که در صفحه نخست نام او نوشته می‌شود. این قرارداد رابطه استخدامی، شراکت یا نمایندگی ایجاد نمی‌کند."),
            new("موضوع", "طراحی، توسعه یا تحویل محصول نرم‌افزاری یا وب طبق شرح پیوست پروژه، در برابر مبلغ و زمان‌بندی که طرفین می‌نویسند."),
            new("محدوده و تغییرات", "کار فقط روی محدوده مکتوب شروع می‌شود. قابلیت اضافه، بازطراحی یا یکپارچه‌سازی جدید نیاز به توافق کتبی دارد و ممکن است مبلغ و موعد تحویل را تغییر دهد."),
            new("تحویل و سورس", "مگر پیوست خلاف آن را بگوید، تحویل شامل نسخه اجرایی مورد توافق و سورس لازم برای ساخت و نگهداری است، پس از تحقق شرایط پرداخت."),
            new("پرداخت", "مبلغ همان عددی است که در صفحه نخست نوشته می‌شود، به ریال ایران مگر ارز دیگری نوشته شود. کاری که به پیش‌پرداخت وابسته است تا دریافت آن شروع نمی‌شود. اقساط بعدی طبق مراحل مکتوب است. انتقال کامل مالکیت فکری تا تسویه کامل به تعویق می‌افتد."),
            new("پذیرش", "کارفرما هفت روز تقویمی پس از هر تحویل فرصت دارد ایراد داخل محدوده را کتباً اعلام کند. سکوت در این مهلت به‌معنای پذیرش همان تحویل است، جز عیب پنهان که باید بدون تأخیر اعلام شود."),
            new("مالکیت فکری", "تا تسویه کامل، حقوق اثر سفارشی نزد پیمانکار می‌ماند. پس از تسویه کامل، حقوق اثر سفارشی این پروژه به کارفرما منتقل می‌شود. کتابخانه‌ها، قلم‌ها و ابزارهای شخص ثالث تابع مجوز خودشان می‌مانند. پیمانکار می‌تواند روش‌ها و دانش عمومی را که محرمانه کارفرما نیست دوباره به کار ببرد."),
            new("محرمانگی", "هر طرف اطلاعات غیرعمومی طرف دیگر را در مدت پروژه و تا دو سال پس از آن محرمانه نگه می‌دارد، مگر جایی که قانون افشا را الزام کند."),
            new("تأخیر و فسخ", "در نقض اساسی، پس از اخطار کتبی و ده روز تقویمی مهلت رفع، طرف زیان‌دیده می‌تواند فسخ کند. فسخ بدون تقصیر با اخطار کتبی چهارده روزه ممکن است؛ کار پذیرفته‌شده پرداخت می‌شود و کار ناتمام به‌نسبت تسویه می‌گردد. قوه قاهره زمان‌بندی را تا رفع آن معلق می‌کند."),
            new("قانون و اختلاف", "قانون حاکم، قوانین جمهوری اسلامی ایران است. محل اجرای تعهد تبریز است. طرفین نخست با حسن‌نیت سازش می‌کنند؛ اختلاف باقی‌مانده در صلاحیت دادگاه‌های صالح تبریز است."),
            new("شکل قرارداد", "فایل دانلودشده یک نسخه اصل است. تصویر امضاشده یا فایل بارگذاری‌شده امضاشده بین طرفین همان اثر نسخه کاغذی را دارد، مگر تغییر کتبی بعدی جایگزین آن شود.")
        ]);

    public static ContractContent German { get; } = new(
        Eyebrow: "Werkvertrag",
        Title: "Projektvertrag für Softwarearbeit",
        Lead: "Laden Sie den Vertrag, füllen Sie die Lücken mit dem Auftraggeber, und laden Sie die unterzeichnete Datei hoch, damit die Arbeit schriftlich beginnt.",
        Body: "Das ist eine Vorlage für freie Softwareentwicklung zu einem benannten Projekt. Sie folgt dem üblichen Vertragsaufbau: Parteien, Gegenstand, Umfang, Zahlung, Quellcode, Rechte nach vollständiger Zahlung, Vertraulichkeit, Verzug, Kündigung sowie iranisches Recht mit Erfüllungsort Täbris. Beträge, Daten und der Auftraggeber bleiben leer, bis beide Seiten sie eintragen. Es ist ein Arbeitsdokument zur Verhandlung, kein Ersatz für anwaltliche Prüfung bei einem großen oder ungewöhnlichen Auftrag.",
        Download: "Vertrag laden",
        Upload: "Unterzeichneten Vertrag hochladen",
        NamePlaceholder: "Name des Auftraggebers",
        EmailPlaceholder: "E-Mail des Auftraggebers",
        FileLabel: "Unterzeichnete Datei (PDF, DOC oder DOCX, bis 8 MB)",
        UploadHint: "Laden Sie die ausgefüllte und unterzeichnete Fassung hoch. PDF ist bevorzugt.",
        Success: "Die Vertragsdatei ist angekommen. Ich prüfe sie und antworte.",
        Error: "Bitte Name des Auftraggebers, eine gültige E-Mail und eine Vertragsdatei angeben.",
        FileTypeError: "Nur PDF, DOC oder DOCX bis 8 MB werden angenommen.",
        Disclaimer: "Diese Vorlage ist ein Arbeitsstart für ein Softwareprojekt. Sie ist keine anwaltliche Beratung. Bei hohem Volumen oder ungewöhnlichen Bedingungen sollte ein zugelassener Anwalt den Endtext vor der Unterschrift prüfen.",
        Clauses:
        [
            new("Parteien", "Auftragnehmer ist Farhad Hosseinzadeh, Softwareentwickler, Ost-Aserbaidschan, Täbris. Auftraggeber ist die auf der ersten Seite genannte natürliche oder juristische Person. Dieser Vertrag begründet kein Arbeits-, Gesellschafts- oder Vertretungsverhältnis."),
            new("Gegenstand", "Entwurf, Entwicklung oder Lieferung eines Software- oder Webprodukts nach der Projektanlage gegen das von den Parteien geschriebene Entgelt und den Zeitplan."),
            new("Umfang und Änderungen", "Die Arbeit beginnt nur auf dem schriftlichen Umfang. Zusätzliche Funktionen, Redesign oder neue Integrationen brauchen schriftliche Einigung und können Entgelt und Liefertermin ändern."),
            new("Lieferung und Quellcode", "Soweit die Anlage nichts anderes sagt, umfasst die Lieferung die vereinbarte lauffähige Fassung und den Quellcode zum Bauen und Pflegen, nach Erfüllung der Zahlungsbedingungen."),
            new("Zahlung", "Das Entgelt ist der auf der ersten Seite geschriebene Betrag, in iranischen Rial, sofern keine andere Währung steht. Arbeit, die von einer ersten Rate abhängt, beginnt erst nach deren Eingang. Weitere Raten folgen den geschriebenen Stufen. Die volle Rechteübertragung wartet auf die vollständige Zahlung."),
            new("Abnahme", "Der Auftraggeber hat sieben Kalendertage nach jeder Lieferung, Mängel im vereinbarten Umfang schriftlich anzuzeigen. Schweigen in dieser Frist gilt als Abnahme dieser Lieferung, außer versteckten Mängeln, die unverzüglich anzuzeigen sind."),
            new("Immaterialgüter", "Bis zur vollständigen Zahlung bleiben die Rechte am Auftragswerk beim Auftragnehmer. Danach gehen diese Rechte am Auftragswerk dieses Projekts auf den Auftraggeber über. Drittbibliotheken, Schriften und Werkzeuge bleiben unter ihren Lizenzen. Der Auftragnehmer darf allgemeine Methoden und Know-how wiederverwenden, die kein vertrauliches Material des Auftraggebers sind."),
            new("Vertraulichkeit", "Jede Partei hält nicht öffentliche Informationen der anderen während des Projekts und zwei Jahre danach geheim, außer soweit das Gesetz eine Offenlegung verlangt."),
            new("Verzug und Kündigung", "Bei wesentlicher Pflichtverletzung kann nach schriftlicher Abhilfeaufforderung und zehn Kalendertagen gekündigt werden. Ohne Pflichtverletzung ist Kündigung mit vierzehn Kalendertagen schriftlicher Frist möglich; abgenommene Arbeit wird bezahlt, unfertige Arbeit anteilig abgerechnet. Höhere Gewalt hemmt die Fristen, solange sie andauert."),
            new("Recht und Streit", "Es gilt das Recht der Islamischen Republik Iran. Erfüllungsort ist Täbris. Die Parteien versuchen zuerst eine gütliche Einigung; verbleibende Streitigkeiten gehören vor die zuständigen Gerichte in Täbris."),
            new("Form", "Die geladene Datei ist eine Urschrift. Ein unterzeichnetes Scan oder ein unterzeichneter Upload hat zwischen den Parteien dieselbe Wirkung wie die Papierurkunde, sofern eine spätere schriftliche Änderung sie nicht ersetzt.")
        ]);
}
