/* Consulta SIL - comportamiento de la capa visual: menu lateral, loader global y
   mostrar/ocultar password. No toca la logica de las pantallas. */
(function ($) {
    "use strict";

    // ---- Loader global: window.SilLoader.show() / hide() ----
    var loader = {
        el: null,
        show: function (texto) {
            if (!this.el) { return; }
            $(this.el).find(".sil-loader__text").text(texto || "Cargando...");
            $(this.el).addClass("is-visible").attr("aria-hidden", "false");
        },
        hide: function () {
            if (!this.el) { return; }
            $(this.el).removeClass("is-visible").attr("aria-hidden", "true");
        }
    };
    window.SilLoader = loader;

    $(function () {
        loader.el = document.getElementById("sil-loader");

        // Menu lateral
        $(document).on("click", "[data-sil-toggle='sidebar']", function () {
            $("body").toggleClass("sil-sidebar-open");
        });
        $(document).on("click", ".sil-backdrop", function () {
            $("body").removeClass("sil-sidebar-open");
        });
        $(document).on("keydown", function (e) {
            if (e.key === "Escape") { $("body").removeClass("sil-sidebar-open"); }
        });

        // Link activo segun la URL (Info es la pagina por defecto: "/" y "/Info")
        var path = window.location.pathname.toLowerCase().replace(/\/+$/, "");
        $(".sil-nav__link[data-sil-match]").each(function () {
            var match = $(this).data("sil-match").toString().toLowerCase().split("|");
            for (var i = 0; i < match.length; i++) {
                if (path === match[i] || (match[i] && path.indexOf(match[i] + "/") === 0)) {
                    $(this).addClass("active");
                    break;
                }
            }
        });

        // Loader al navegar: submit de formularios y links marcados con data-sil-loader
        $(document).on("submit", "form:not([data-sil-no-loader])", function () {
            var $form = $(this);
            // no mostrar si la validacion del lado cliente frena el envio
            if ($.fn.valid && $form.data("validator") && !$form.valid()) { return; }
            loader.show($form.data("sil-loader-text"));
        });
        $(document).on("click", "a[data-sil-loader]", function (e) {
            if (e.ctrlKey || e.metaKey || e.shiftKey || e.button === 1) { return; }
            loader.show($(this).data("sil-loader"));
        });

        // Mostrar / ocultar password
        $(document).on("click", ".sil-pass-toggle", function () {
            var $input = $("#" + $(this).data("target"));
            var visible = $input.attr("type") === "text";
            $input.attr("type", visible ? "password" : "text");
            $(this).find(".bi").toggleClass("bi-eye", visible).toggleClass("bi-eye-slash", !visible);
            $(this).attr("aria-label", visible ? "Mostrar contrasena" : "Ocultar contrasena");
        });
    });

    // Al volver con "Atras" el navegador puede restaurar la pagina con el loader visible
    $(window).on("pageshow", function () { loader.hide(); });
})(jQuery);
