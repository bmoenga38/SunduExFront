jQuery(
  (function ($) {
    "use strict";
    $(window).on("scroll", function () {
      if ($(this).scrollTop() > 30) {
        $(".navbar-area").addClass("is-sticky");
      } else {
        $(".navbar-area").removeClass("is-sticky");
      }
    });
    jQuery(".mean-menu").meanmenu({ meanScreenWidth: "1199" });
    $(".others-option-for-responsive .dot-menu").on("click", function () {
      $(".others-option-for-responsive .container .container").toggleClass(
        "active"
      );
    });
    $(".language-option").each(function () {
      var each = $(this);
      each
        .find(".lang-name")
        .html(each.find(".language-dropdown-menu a:nth-child(1)").text());
      var allOptions = $(".language-dropdown-menu").children("a");
      each.find(".language-dropdown-menu").on("click", "a", function () {
        allOptions.removeClass("selected");
        $(this).addClass("selected");
        $(this)
          .closest(".language-option")
          .find(".lang-name")
          .html($(this).text());
      });
    });
    $(".amount-currency-select").each(function () {
      var each = $(this);
      each
        .find(".currency-name")
        .html(each.find(".currency-dropdown-menu a:nth-child(1)").text());
      var allOptions = $(".currency-dropdown-menu").children("a");
      each.find(".currency-dropdown-menu").on("click", "a", function () {
        allOptions.removeClass("selected");
        $(this).addClass("selected");
        $(this)
          .closest(".amount-currency-select")
          .find(".currency-name")
          .html($(this).text());
      });
    });
    $(".main-banner-area").mousemove(function (e) {
      var wx = $(window).width();
      var wy = $(window).height();
      var x = e.pageX - this.offsetLeft;
      var y = e.pageY - this.offsetTop;
      var newx = x - wx / 2;
      var newy = y - wy / 2;
      $(".main-banner-image, .main-banner-shape, .main-banner-shape-2").each(
        function () {
          var speed = $(this).attr("data-speed");
          if ($(this).attr("data-revert")) speed *= -0.4;
          TweenMax.to($(this), 1, { x: 1 - newx * speed, y: 1 - newy * speed });
        }
      );
    });
    $(".why-choose-us-area").mousemove(function (e) {
      var wx = $(window).width();
      var wy = $(window).height();
      var x = e.pageX - this.offsetLeft;
      var y = e.pageY - this.offsetTop;
      var newx = x - wx / 2;
      var newy = y - wy / 2;
      $(".choose-shape, .choose-shape-2").each(function () {
        var speed = $(this).attr("data-speed");
        if ($(this).attr("data-revert")) speed *= -0.4;
        TweenMax.to($(this), 1, { x: 1 - newx * speed, y: 1 - newy * speed });
      });
    });
    $(".security-area").mousemove(function (e) {
      var wx = $(window).width();
      var wy = $(window).height();
      var x = e.pageX - this.offsetLeft;
      var y = e.pageY - this.offsetTop;
      var newx = x - wx / 2;
      var newy = y - wy / 2;
      $(".security-shape, .security-shape-2").each(function () {
        var speed = $(this).attr("data-speed");
        if ($(this).attr("data-revert")) speed *= -0.4;
        TweenMax.to($(this), 1, { x: 1 - newx * speed, y: 1 - newy * speed });
      });
    });
    $(".main-banner-wrap-image").each(function () {
      var tl = new TimelineMax();
      if (tl.isActive()) {
        return false;
      }
      var cov = $(this).find(".overlay");
      tl.from(cov, 0.6, { scaleX: 0, transformOrigin: "left" });
      tl.to(cov, 0.6, { scaleX: 0, transformOrigin: "right" }, "reveal");
      var scene = new ScrollMagic.Scene({
        triggerElement: this,
        triggerHook: 0.7,
      });
    });
    $(".review-slides").owlCarousel({
      loop: true,
      nav: false,
      dots: false,
      smartSpeed: 500,
      margin: 25,
      autoplayHoverPause: true,
      autoplay: true,
      responsive: {
        0: { items: 1 },
        576: { items: 1 },
        768: { items: 2 },
        1200: { items: 3 },
      },
    });
    $(".review-slides-two").owlCarousel({
      loop: true,
      nav: false,
      dots: false,
      smartSpeed: 500,
      margin: 25,
      autoplayHoverPause: true,
      autoplay: true,
      responsive: {
        0: { items: 1 },
        576: { items: 1 },
        768: { items: 1 },
        1024: { items: 2 },
        1200: { items: 2 },
      },
    });
    $(".partner-slides").owlCarousel({
      loop: true,
      nav: false,
      dots: false,
      smartSpeed: 500,
      margin: 30,
      autoplayHoverPause: true,
      autoplay: true,
      responsive: {
        0: { items: 2 },
        576: { items: 4 },
        768: { items: 5 },
        1200: { items: 6 },
      },
    });
    $(".popup-youtube").magnificPopup({
      disableOn: 320,
      type: "iframe",
      mainClass: "mfp-fade",
      removalDelay: 160,
      preloader: false,
      fixedContentPos: false,
    });
    $(".newsletter-form")
      .validator()
      .on("submit", function (event) {
        if (event.isDefaultPrevented()) {
          formErrorSub();
          submitMSGSub(false, "Please enter your email correctly.");
        } else {
          event.preventDefault();
        }
      });
    function callbackFunction(resp) {
      if (resp.result === "success") {
        formSuccessSub();
      } else {
        formErrorSub();
      }
    }
    function formSuccessSub() {
      $(".newsletter-form")[0].reset();
      submitMSGSub(true, "Thank you for subscribing!");
      setTimeout(function () {
        $("#validator-newsletter").addClass("hide");
      }, 4000);
    }
    function formErrorSub() {
      $(".newsletter-form").addClass("animated shake");
      setTimeout(function () {
        $(".newsletter-form").removeClass("animated shake");
      }, 1000);
    }
    function submitMSGSub(valid, msg) {
      if (valid) {
        var msgClasses = "validation-success";
      } else {
        var msgClasses = "validation-danger";
      }
      $("#validator-newsletter").removeClass().addClass(msgClasses).text(msg);
    }
    $(".newsletter-form").ajaxChimp({
      url: "https://envytheme.us20.list-manage.com/subscribe/post?u=60e1ffe2e8a68ce1204cd39a5&amp;id=42d6d188d9",
      callback: callbackFunction,
    });
    function makeTimer() {
      var endTime = new Date("May 20, 2025 17:00:00 PDT");
      var endTime = Date.parse(endTime) / 1000;
      var now = new Date();
      var now = Date.parse(now) / 1000;
      var timeLeft = endTime - now;
      var days = Math.floor(timeLeft / 86400);
      var hours = Math.floor((timeLeft - days * 86400) / 3600);
      var minutes = Math.floor((timeLeft - days * 86400 - hours * 3600) / 60);
      var seconds = Math.floor(
        timeLeft - days * 86400 - hours * 3600 - minutes * 60
      );
      if (hours < "10") {
        hours = "0" + hours;
      }
      if (minutes < "10") {
        minutes = "0" + minutes;
      }
      if (seconds < "10") {
        seconds = "0" + seconds;
      }
      $("#days").html(days + "<span>Days</span>");
      $("#hours").html(hours + "<span>Hours</span>");
      $("#minutes").html(minutes + "<span>Minutes</span>");
      $("#seconds").html(seconds + "<span>Seconds</span>");
    }
    setInterval(function () {
      makeTimer();
    }, 0);
    $(".odometer").appear(function (e) {
      var odo = $(".odometer");
      odo.each(function () {
        var countNumber = $(this).attr("data-count");
        $(this).html(countNumber);
      });
    });
    AOS.init();
    if ($(".wow").length) {
      var wow = new WOW({ mobile: false });
      wow.init();
    }
    $(window).on("scroll", function () {
      var scrolled = $(window).scrollTop();
      if (scrolled > 600) $(".go-top").addClass("active");
      if (scrolled < 600) $(".go-top").removeClass("active");
    });
    $(".go-top").on("click", function () {
      $("html, body").animate({ scrollTop: "0" }, 500);
    });
    jQuery(window).on("load", function () {
      jQuery(".preloader").fadeOut(500);
    });
    $("body").append(
      "<div class='switch-box'><label id='switch' class='switch'><input type='checkbox' onchange='toggleTheme()' id='slider'><span class='slider round'></span></label></div>"
    );
  })(jQuery)
);
function setTheme(themeName) {
  localStorage.setItem("snuff_theme", themeName);
  document.documentElement.className = themeName;
}
function toggleTheme() {
  if (localStorage.getItem("snuff_theme") === "theme-dark") {
    setTheme("theme-light");
  } else {
    setTheme("theme-dark");
  }
}
(function () {
  if (localStorage.getItem("snuff_theme") === "theme-dark") {
    setTheme("theme-dark");
    document.getElementById("slider").checked = false;
  } else {
    setTheme("theme-light");
    document.getElementById("slider").checked = true;
  }
})();


// Contact Tabs Hq and Branch 
document.addEventListener("DOMContentLoaded", function () {
    const tabs = document.querySelectorAll(".tab-link");
    const contents = document.querySelectorAll(".tab-content");

    tabs.forEach((tab) => {
        tab.addEventListener("click", function (event) {
            event.preventDefault();
            const targetTab = this.getAttribute("data-tab");

            tabs.forEach((t) => t.querySelector("a").classList.remove("active"));
            contents.forEach((c) => c.classList.remove("current"));

            this.querySelector("a").classList.add("active");
            document.getElementById(targetTab).classList.add("current");
        });
    });
});

