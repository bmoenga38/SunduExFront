(function ($) {
  "use strict";
  $("#contactForm")
    .validator()
    .on("submit", function (event) {
      if (event.isDefaultPrevented()) {
        formError();
        submitMSG(false, "Did you fill in the form properly?");
      } else {
        event.preventDefault();
        submitForm();
      }
    });
  function submitForm() {
    var name = $("#name").val();
    var email = $("#email").val();
    var msg_subject = $("#msg_subject").val();
    var phone_number = $("#phone_number").val();
    var message = $("#message").val();
    var gridCheck = $("#gridCheck").val();

    var toEmail = "kifarundogo11230@gmail.com";
    // Send form data to the server-side script
    $.ajax({
      type: "POST",
      url: "send_email.php", // Replace "send_email.php" with the path to your server-side script
      data: {
        name: name,
        email: email,
        msg_subject: msg_subject,
        phone_number: phone_number,
        message: message,
        gridCheck: gridCheck,
      },
      success: function (response) {
        if (response.trim() === "success") {
          formSuccess();
        } else {
          formError();
          submitMSG(false, response);
        }
      },
      error: function () {
        formError();
        submitMSG(false, "Failed to send message. Please try again later.");
      },
    });
  }

  function formSuccess() {
    $("#contactForm")[0].reset();
    submitMSG(true, "Message Submitted!");
  }

  function formError() {
    $("#contactForm")
      .removeClass()
      .addClass("shake animated")
      .one(
        "webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
        function () {
          $(this).removeClass();
        }
      );
  }

  function submitMSG(valid, msg) {
    if (valid) {
      var msgClasses = "h4 tada animated text-success";
    } else {
      var msgClasses = "h4 text-danger";
    }
    $("#msgSubmit").removeClass().addClass(msgClasses).text(msg);
  }
})(jQuery);
