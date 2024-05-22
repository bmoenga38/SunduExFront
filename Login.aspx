<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="SunduFront.Login" %>
<!doctype html>
<html lang="zxx">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="webassets/css/bootstrap.min.css">
    <link rel="stylesheet" href="webassets/css/aos.css">
    <link rel="stylesheet" href="webassets/css/animate.min.css">
    <link rel="stylesheet" href="webassets/css/meanmenu.min.css">
    <link rel="stylesheet" href="webassets/css/remixicon.css">
    <link rel="stylesheet" href="webassets/css/flaticon.css">
    <link rel="stylesheet" href="webassets/css/odometer.min.css">
    <link rel="stylesheet" href="webassets/css/owl.carousel.min.css">
    <link rel="stylesheet" href="webassets/css/owl.theme.default.min.css">
    <link rel="stylesheet" href="webassets/css/magnific-popup.min.css">
    <link rel="stylesheet" href="webassets/css/style.css">
    <link rel="stylesheet" href="webassets/css/navbar.css">
    <link rel="stylesheet" href="webassets/css/footer.css">
    <link rel="stylesheet" href="webassets/css/dark.css">
    <link rel="stylesheet" href="webassets/css/responsive.css">
    <title>Sundus Exchange </title>
    <link rel="icon" type="image/png" href="webassets/images/sundus.svg">

       <!-- [Template CSS Files] -->
    <link rel="stylesheet" href="assets/css/style.css" id="main-style-link">
    <link rel="stylesheet" href="assets/css/style-preset.css">
    <link rel="stylesheet" href="assets/css/plugins/notifier.css">
    <!-- Angular js -->
    <script src="assets/js/angular.min.js"></script>
    <%--         <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.1/angular.min.js"></script> --%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.1/angular-cookies.js"></script>
    <script data-require="angular-animate@1.6.*" data-semver="1.6.5" src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-animate.min.js"></script>
    <script data-require="angular-touch@1.6.*" data-semver="1.6.2" src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.2/angular-touch.js"></script>
    <script data-require="ui-bootstrap@*" data-semver="2.5.0" src="https://cdn.rawgit.com/angular-ui/bootstrap/gh-pages/ui-bootstrap-tpls-2.5.0.js"></script>
    <%-- <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/angular-datatables/0.6.2/angular-datatables.min.js"></script> --%>
    <%-- <script src="dist/js/angular-datatables.min.js"></script> --%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular-resource/1.6.4/angular-resource.min.js" integrity="sha256-yvd+Dzk092nYfH39BvnCKokWueNXS7P4FEZgc0/B2Rg=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.4/angular-sanitize.min.js" integrity="sha256-Rzludu7Q/VP9RNPGzKR5zLimtMWLqdPIYCgwrM75xVI=" crossorigin="anonymous"></script>

    <%-- ngTable --%>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ng-table/1.0.0/ng-table.min.css" integrity="sha256-sygdFLmCBqmo0USUOnXKAzy2s6PcgJr2eTTcJMpLQ4Y=" crossorigin="anonymous" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/ng-table/1.0.0/ng-table.min.js" integrity="sha256-7JSMGT2kEU80Rl0c6iwp5M6DyufxwRvQtwVvQvkgUUM=" crossorigin="anonymous"></script>--%>
    <link rel="stylesheet" href="https://unpkg.com/ng-table@2.0.2/bundles/ng-table.min.css">
    <script src="https://unpkg.com/ng-table@2.0.2/bundles/ng-table.min.js"></script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC5UAAN7XyCB9r67VWoZ3_oRpHZa0hhn_M&libraries=places"></script>
    <script src="https://rawgit.com/allenhwkim/angularjs-google-maps/master/build/scripts/ng-map.js"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.9/angular.min.js"></script>--%>



    <%-- Lodash --%>
    <script src="https://cdn.jsdelivr.net/npm/lodash@4.17.15/lodash.min.js" integrity="sha256-VeNaFBVDhoX3H+gJ37DpT/nTuZTdjYro9yBruHjVmoQ=" crossorigin="anonymous"></script>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.27/dist/sweetalert2.all.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.27/dist/sweetalert2.min.css" rel="stylesheet">
</head>
    
<body ng-app="SundusEx" data-pc-preset="preset-1" data-pc-sidebar-caption="true" data-pc-direction="ltr" data-pc-theme_contrast="" data-pc-theme="light">


    <div class="login-area ptb-100">
        <div class="container">
            <div class="login-form"  ng-controller="LoginCtrl" ng-cloak>
                <h2>Login Here</h2>
                <p>Welcome Back, Login To Your Account</p>
                <form>
                    <div class="form-group">
                        <label>Your email address</label>
                        <input type="text" class="form-control" placeholder="Your email address" id="floatingInput" ng-model="UserName" >
                    </div>
                    <div class="form-group">
                        <label>Your password</label>
                        <input type="text" class="form-control" placeholder="Your password" id="floatingInput1" ng-model="Password">
                    </div>
                    <div class="row align-items-center">
                        <div class="col-lg-6 col-md-6 col-sm-6 remember-me-wrap">
                            <p>
                                <input type="checkbox" id="customCheckc1">
                                <label for="test2">Remember me</label>
                            </p>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 lost-your-password-wrap">
                            <a href="ForgotPassword.aspx" class="lost-your-password">Forgot your password?</a>
                        </div>
                    </div>
                    <button type="submit" class="default-btn">Login Now</button>
                    <div class="account-text">
                        <span>Don’t have an account? <a href="Register.aspx">Create Account</a></span>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <footer class="footer-area pt-100">
        <div class="copyright-area">
            <div class="container">
                <div class="copyright-area-content">
                    <p>
                        Copyright @
                        <script data-cfasync="false"
                            src="../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script>
                        <script>document.write(new Date().getFullYear())</script> Sundus Exchange All Rights Reserved by
                        <a href="https://brycode.co.ke/" target="_blank">
                            HexTech
                        </a>
                    </p>
                </div>
            </div>
        </div>
    </footer>


    <script src="webassets/js/jquery.min.js"></script>
    <script src="webassets/js/bootstrap.bundle.min.js"></script>
    <script src="webassets/js/jquery.meanmenu.js"></script>
    <script src="webassets/js/owl.carousel.min.js"></script>
    <script src="webassets/js/jquery.appear.js"></script>
    <script src="webassets/js/odometer.min.js"></script>
    <script src="webassets/js/jquery.magnific-popup.min.js"></script>
    <script src="webassets/js/TweenMax.min.js"></script>
    <script src="webassets/js/ScrollMagic.min.js"></script>
    <script src="webassets/js/aos.js"></script>
    <script src="webassets/js/jquery.ajaxchimp.min.js"></script>
    <script src="webassets/js/form-validator.min.js"></script>
    <script src="webassets/js/contact-form-script.js"></script>
    <script src="webassets/js/wow.min.js"></script>
    <script src="webassets/js/main.js"></script>
</body>


</html>