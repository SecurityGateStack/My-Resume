(function ($) {
    "use strict";

    function refreshResumeSkills() {
        $(".circular_progress_bar .myCircle").each(function () {
            var circle = $(this);
            circle.removeData("circle-progress");
            circle.empty();
        });

        if (typeof iknow_tm_circular_progress === "function") {
            iknow_tm_circular_progress();
        }

        $(".dodo_progress").each(function () {
            if (typeof tdProgress === "function") {
                tdProgress($(this));
            }
        });
    }

    $(function () {
        if (typeof iknow_tm_data_images === "function") {
            iknow_tm_data_images();
        }

        if (typeof iknow_tm_imgtosvg === "function") {
            iknow_tm_imgtosvg();
        }

        if (typeof iknow_tm_hero_height === "function") {
            iknow_tm_hero_height();
        }

        $(window).on("load", function () {
            if ($("#preloader").length && typeof iknow_tm_my_load === "function") {
                iknow_tm_my_load();
            }
        });

        $(".accent_switch input").on("input", function () {
            var color = String(this.value || "").toLowerCase();
            if (!/^#[0-9a-f]{6}$/.test(color)) {
                return;
            }

            document.documentElement.style.setProperty("--resume-accent", color);
        }).on("change", function () {
            var color = String(this.value || "").toLowerCase();
            if (!/^#[0-9a-f]{6}$/.test(color)) {
                return;
            }

            document.documentElement.style.setProperty("--resume-accent", color);
            document.cookie = "resume-accent=" + color + ";path=/;max-age=31536000;samesite=lax";
            refreshResumeSkills();
        });

        $(".theme_switch [data-theme]").on("click", function () {
            var theme = $(this).attr("data-theme") === "dark" ? "dark" : "light";
            document.body.classList.toggle("dark", theme === "dark");
            $(".theme_switch [data-theme]").each(function () {
                var selected = $(this).attr("data-theme") === theme;
                $(this).toggleClass("active", selected).attr("aria-pressed", selected ? "true" : "false");
            });
            document.cookie = "resume-theme=" + theme + ";path=/;max-age=31536000;samesite=lax";
            return false;
        });

        $(".iknow_tm_hero .main_menu ul li a").on("click", function () {
            if ($(this).attr("href") === "#resume") {
                window.setTimeout(refreshResumeSkills, 280);
            }
        });

        $(".contact_form #send_message").off("click").on("click", function () {
            var form = $(".contact_form");
            var name = $.trim(form.find("#name").val());
            var email = $.trim(form.find("#email").val());
            var message = $.trim(form.find("#message").val());
            var subject = $.trim(form.find("#subject").val());
            var success = form.find(".returnmessage").data("success");

            form.find(".returnmessage").empty();
            if (name === "" || email === "" || message === "") {
                $("div.empty_notice").slideDown(500).delay(2000).slideUp(500);
            } else {
                $.post("/modal/contact.php", {
                    ajax_name: name,
                    ajax_email: email,
                    ajax_message: message,
                    ajax_subject: subject,
                    ajax_culture: document.documentElement.lang
                }, function (data) {
                    form.find(".returnmessage").append(data);
                    if (form.find(".returnmessage span.contact_error").length) {
                        form.find(".returnmessage").slideDown(500).delay(2000).slideUp(500);
                    } else {
                        form.find(".returnmessage").append("<span class='contact_success'>" + success + "</span>");
                        form.find(".returnmessage").slideDown(500).delay(4000).slideUp(500);
                    }
                    if (data === "") {
                        form[0].reset();
                    }
                });
            }
            return false;
        });
    });
})(jQuery);
