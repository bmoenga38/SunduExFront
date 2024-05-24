<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="SunduFront.home" %>

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

      <!-- Angular js -->
    <script src="assets/js/angular.min.js"></script>
    <%-- <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.1/angular.min.js"></script> --%>
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
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>

<body>



    <div class="topbar-area">
        <div class="container-fluid">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-6">
                    <ul class="topbar-information">
                        <li>
                            <a href="tel:+0925206969">+0925 206 969  +0924 441 051</a>
                        </li>

                        <li>
                            <a href="mailto:info@sundusexchange.com">info@sundusexchange.com</a>
                        </li>
                    </ul>
                </div>
                <div class="col-lg-6 col-md-6">
                    <ul class="topbar-action">
                        <li>
                            <a href="#">Open 7:30AM-5:00 PM</a>
                        </li>
                        <li>
                            <a href="#">Sunday & Holidays: Closed</a>
                        </li>
                        <li class="dropdown language-option">
                            <button class="dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-haspopup="true"
                                aria-expanded="false">
                                <i class="ri-global-line"></i>
                                <span class="lang-name"></span>
                            </button>
                            <div class="dropdown-menu language-dropdown-menu">
                                <a class="dropdown-item" href="#">
                                    <img src="webassets/images/uk.png" alt="flag">
                                    English
                                </a>
                                <a class="dropdown-item" href="#">
                                    <img src="webassets/images/china.png" alt="flag">
                                    简体中文
                                </a>
                                <a class="dropdown-item" href="#">
                                    <img src="webassets/images/uae.png" alt="flag">
                                    العربيّة
                                </a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>


    <div class="navbar-area">
        <div class="main-responsive-nav">
            <div class="container">
                <div class="main-responsive-menu">
                    <div class="logo">
                        <a href="index.aspx">
                            <img src="webassets/images/logo.png" class="black-logo" alt="image">
                            <img src="webassets/images/logo-2.png" class="white-logo" alt="image">
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="main-navbar">
            <div class="container-fluid">
                <nav class="navbar navbar-expand-md navbar-light">
                    <a class="navbar-brand" href="index.aspx">
                        <img src="webassets/images/logo.png" class="black-logo" alt="image">
                        <img src="webassets/images/logo-2.png" class="white-logo" alt="image">
                    </a>
                    <div class="collapse navbar-collapse mean-menu" id="navbarSupportedContent">
                        <ul class="navbar-nav ms-auto">

                            <li class="nav-item">
                                <a href="index.aspx" class="nav-link">Home</a>
                            </li>

                            <li class="nav-item">
                                <a href="Services.aspx" class="nav-link">Services</a>
                            </li>

                            <li class="nav-item">
                                <a href="AboutUs.aspx" class="nav-link">About Us</a>
                            </li>


                            <li class="nav-item">
                                <a href="ContactHQ.aspx" class="nav-link">Contact</a>
                            </li>


                        </ul>
                    </div>
                </nav>
            </div>
        </div>
        <!-- <div class="others-option-for-responsive">
            <div class="container">
                <div class="dot-menu">
                    <div class="inner">
                        <div class="circle circle-one"></div>
                        <div class="circle circle-two"></div>
                        <div class="circle circle-three"></div>
                    </div>
                </div>
                <div class="container">
                    <div class="option-inner">

                    </div>
                </div>
            </div>
        </div> -->
    </div>


    <div class="main-hero-area">
        <div class="container-fluid">
            <div class="row align-items-center">
                <div class="col-lg-8 col-md-12" data-aos="fade-right" data-aos-delay="50" data-aos-duration="500"
                    data-aos-once="true">
                    <div class="main-hero-content">
                        <span><i class="ri-lock-line"></i> Simple. Quick. Secure</span>
                        <h1>Fast & Reliable, Money Transfer Limited</h1>
                        <div class="banner-btn">
                            <a href="ContactHQ.aspx" class="default-btn">Send Now</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-12" data-aos="fade-left" data-aos-delay="50" data-aos-duration="500"
                    data-aos-once="true">
                     <form class="money-transfer-form-two">
                        <div class="money-transfer-content">
                            <div class="form-group">
                                <label>You Send</label>
                                <input type="text" class="form-control" autocomplete="off" value="25,040">
                                <div class="dropdown amount-currency-select">
                                    <button class="dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                        aria-haspopup="true" aria-expanded="true">
                                        <img src="webassets/images/currency-flag/GBP.png" alt="flag">
                                        <span class="currency-name"></span>
                                    </button>
                                    <div class="dropdown-menu currency-dropdown-menu">
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/GBP.png" alt="flag">
                                            GBP
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/EUR.png" alt="flag">
                                            EUR
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/AED.png" alt="flag">
                                            AED
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/AUD.png" alt="flag">
                                            AUD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/CAD.png" alt="flag">
                                            CAD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/JPY.png" alt="flag">
                                            JPY
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/MYR.png" alt="flag">
                                            MYR
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/NZD.png" alt="flag">
                                            NZD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/TRY.png" alt="flag">
                                            TRY
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/USD.png" alt="flag">
                                            USD
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <ul class="amount-currency-info">
                                <li class="d-flex justify-content-between align-items-center">
                                    <div class="info-icon">
                                        <i class="ri-subtract-line"></i>
                                    </div>
                                    <div class="info-left">
                                        <b>22.07 GBP</b>
                                    </div>
                                    <div class="info-right">
                                        <div class="dropdown amount-currency-select">
                                            <button class="dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                                aria-haspopup="true" aria-expanded="true">
                                                <span class="currency-name"></span>
                                            </button>
                                            <div class="dropdown-menu currency-dropdown-menu">
                                                <a class="dropdown-item" href="#">Low Cost Transfer</a>
                                                <a class="dropdown-item" href="#">Easy Transfer</a>
                                                <a class="dropdown-item" href="#">Advanced Transfer</a>
                                            </div>
                                        </div>
                                        <span class="fee-text">fee</span>
                                    </div>
                                </li>
                                <li class="d-flex justify-content-between align-items-center">
                                    <div class="info-icon">
                                        <i class="ri-pause-line"></i>
                                    </div>
                                    <div class="info-left">
                                        <span>63,1547 GBP</span>
                                    </div>
                                    <div class="info-right">
                                        <span>Amount Will Convert</span>
                                    </div>
                                </li>
                                <li class="d-flex justify-content-between align-items-center">
                                    <div class="info-icon">
                                        <i class="ri-close-fill"></i>
                                    </div>
                                    <div class="info-left">
                                        <strong>1.0539874 <i class="flaticon-graph"></i></strong>
                                    </div>
                                    <div class="info-right">
                                        <span>Guaranted Rate (4 hrs)</span>
                                    </div>
                                </li>
                            </ul>
                            <div class="form-group">
                                <label>Recipient Gets</label>
                                <input type="text" class="form-control" autocomplete="off" value="14,02433.25">
                                <div class="dropdown amount-currency-select">
                                    <button class="dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                        aria-haspopup="true" aria-expanded="true">
                                        <img src="webassets/images/currency-flag/EUR.png" alt="flag">
                                        <span class="currency-name"></span>
                                    </button>
                                    <div class="dropdown-menu currency-dropdown-menu">
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/EUR.png" alt="flag">
                                            EUR
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/GBP.png" alt="flag">
                                            GBP
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/AED.png" alt="flag">
                                            AED
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/AUD.png" alt="flag">
                                            AUD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/CAD.png" alt="flag">
                                            CAD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/JPY.png" alt="flag">
                                            JPY
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/MYR.png" alt="flag">
                                            MYR
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/NZD.png" alt="flag">
                                            NZD
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/TRY.png" alt="flag">
                                            TRY
                                        </a>
                                        <a class="dropdown-item" href="#">
                                            <img src="webassets/images/currency-flag/USD.png" alt="flag">
                                            USD
                                        </a>
                                    </div>
                                </div>
                                <div class="lock-icon">
                                    <i class="ri-lock-line"></i>
                                </div>
                            </div>
                            <div class="amount-delivery-time">
                                <span>Delivery Time: <b>By August 23th</b></span>
                            </div>
                            <ul class="amount-btn-group">
                                <li>
                                    <a href="compare-pricing.html" class="default-btn">Compare Price</a>
                                </li>
                                <li>
                                    <button type="button" class="optional-btn">Get Started</button>
                                </li>
                            </ul>
                        </div>
                    </form> 
                </div>
            </div>
        </div>
        <div class="main-hero-shape">
            <img src="webassets/images/main-banner/shape-3.png" alt="image">
        </div>
        <div class="main-hero-shape-2">
            <img src="webassets/images/main-banner/yellow.png" alt="image">
        </div>
    </div>


    <div class="getting-started-area-with-transparent ptb-100">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-12">
                    <div class="getting-started-content" data-aos="fade-right" data-aos-delay="50"
                        data-aos-duration="500" data-aos-once="true">
                        <span>Getting Started</span>
                        <h3>Get Set Up And Start Sending</h3>
                        <div class="getting-started-accordion">
                            <div class="accordion" id="GettingAccordion">
                                <div class="accordion-item">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse"
                                        data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        1. Register with Ease!
                                    </button>
                                    <div id="collapseOne" class="accordion-collapse collapse show"
                                        data-bs-parent="#GettingAccordion">
                                        <div class="accordion-body">
                                            <p>
                                                Join us today and start your forex journey hassle-free.
                                            </p>
                                        </div>
                                    </div>
                                </div>

                                <div class="accordion-item">
                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                        data-bs-target="#collapseThree" aria-expanded="false"
                                        aria-controls="collapseThree">
                                        2. Set Up A Transfer
                                    </button>
                                    <div id="collapseThree" class="accordion-collapse collapse"
                                        data-bs-parent="#GettingAccordion">
                                        <div class="accordion-body">
                                            <p>Set up your transfer quickly and securely.</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                        data-bs-target="#collapseFour" aria-expanded="false"
                                        aria-controls="collapseFour">
                                        3. Pay For Your Transfer
                                    </button>
                                    <div id="collapseFour" class="accordion-collapse collapse"
                                        data-bs-parent="#GettingAccordion">
                                        <div class="accordion-body">
                                            <p>Make your payment swiftly and securely.</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                        data-bs-target="#collapseFive" aria-expanded="false"
                                        aria-controls="collapseFive">
                                        4. All Done
                                    </button>
                                    <div id="collapseFive" class="accordion-collapse collapse"
                                        data-bs-parent="#GettingAccordion">
                                        <div class="accordion-body">
                                            <p>Congratulations, your transaction is complete!</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-12">
                    <div class="getting-started-image" data-aos="fade-left" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <img src="webassets/images/getting-started/banner_bg.png" alt="laptop-image">
                        <div class="video-view" data-speed="0.08" data-revert="true">
                            <a href="https://www.youtube.com/watch?v=uwt1lGKQM18&t=3s" class="video-btn popup-youtube">
                                <i class="ri-play-circle-line"></i>
                            </a>
                        </div>
                        <div class="getting-shape">
                            <img src="webassets/images/getting-started/yellow.png" alt="image">
                        </div>
                        <div class="getting-shape-2">
                            <img src="webassets/images/getting-started/shape-2.png" alt="image">
                        </div>
                        <div class="getting-shape-3">
                            <img src="webassets/images/getting-started/shape-3.png" alt="image">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="global-transfers-area pt-100 pb-75">
        <div class="container">
            <div class="section-title">
                <span>Global Transfers</span>
                <h2>We Charge As Little As Possible. No Subscription Fee</h2>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-3 col-sm-6">
                    <div class="single-global-transfers-card" data-aos="fade-up" data-aos-delay="50"
                        data-aos-duration="500" data-aos-once="true">
                        <div class="icon">
                            <i class="flaticon-envelope"></i>
                        </div>
                        <h3>Inexpensive and hassle-free money transfers.</h3>
                        <p>Transfer funds globally with ease and at an affodable cost compared to traditional banks.</p>
                        <a href="ContactHQ.aspx" class="global-btn">Send Money</a>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-global-transfers-card" data-aos="fade-up" data-aos-delay="60"
                        data-aos-duration="600" data-aos-once="true">
                        <div class="icon">
                            <i class="flaticon-money-transfer"></i>
                        </div>
                        <h3>Spend Abroad Without The Hidden Fees</h3>
                        <p>Exchange and spend money abroad without worrying about hidden fees eating into your funds.
                        </p>
                        <a href="GettingStarted.aspx" class="global-btn">Get Started</a>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-global-transfers-card" data-aos="fade-up" data-aos-delay="70"
                        data-aos-duration="700" data-aos-once="true">
                        <div class="icon">
                            <i class="flaticon-income"></i>
                        </div>
                        <h3>Access Global Payments Seamlessly</h3>
                        <p>Seamlessly accept payments worldwide in multiple currencies as if you were a local business.
                        </p>
                        <a href="HelpCenter.aspx" class="global-btn">Available Accounts</a>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-global-transfers-card" data-aos="fade-up" data-aos-delay="80"
                        data-aos-duration="800" data-aos-once="true">
                        <div class="icon">
                            <i class="flaticon-conversion"></i>
                        </div>
                        <h3>Convert And Hold Currencies Efficiently</h3>
                        <p>Efficiently handle diverse currencies for smoother global transactions.</p>
                        <a href="HelpCenter.aspx" class="global-btn">See All Currencies</a>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <div class="why-choose-us-area ptb-100">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-12">
                    <div class="why-choose-us-image">
                        <div class="row align-items-center">
                            <div class="col-lg-6 col-sm-6">
                                <div class="choose-image" data-aos="fade-down" data-aos-delay="50"
                                    data-aos-duration="500" data-aos-once="true">
                                    <img src="webassets/images/why-choose-us/chose-us-1.png" alt="image">
                                </div>
                            </div>
                            <div class="col-lg-6 col-sm-6">
                                <div class="choose-image mb-25" data-aos="fade-left" data-aos-delay="50"
                                    data-aos-duration="500" data-aos-once="true">
                                    <img src="webassets/images/why-choose-us/chose-us-2.png" alt="image">
                                </div>
                                <div class="choose-image" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                                    data-aos-once="true">
                                    <img src="webassets/images/why-choose-us/choose-us-3.png" alt="image">
                                </div>
                            </div>
                        </div>
                        <div class="choose-shape" data-speed="0.08" data-revert="true">
                            <img src="webassets/images/why-choose-us/shape-1.png" alt="image">
                        </div>
                        <div class="choose-shape-2" data-speed="0.08" data-revert="true">
                            <img src="webassets/images/why-choose-us/shape-2.png" alt="image">
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-12">
                    <div class="why-choose-us-content with-padding-left" data-aos="fade-left" data-aos-delay="50"
                        data-aos-duration="500" data-aos-once="true">
                        <span>Why Choose Us</span>
                        <h3>Moving And Living Abroad Just Got Simpler Get Paid Like A Local</h3>
                        <p>
                            Transfer funds affordably and conveniently, outperforming traditional banks.
                            Exchange currencies without worrying about concealed charges.
                            Seamlessly move money across borders for salaries and more.
                        </p>

                        <ul class="choose-us-list">
                            <li>
                                <i class="ri-checkbox-circle-line"></i>
                                Affordable and effortless money transfers
                            </li>
                            <li>
                                <i class="ri-checkbox-circle-line"></i>
                                Fee-free spending abroad
                            </li>
                            <li>
                                <i class="ri-checkbox-circle-line"></i>
                                Seamless cross-border transactions
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="benefits-area pt-100 pb-75">
        <div class="container">
            <div class="section-title">
                <span>Your Benefits</span>
                <h2>Simplify Currency Exchange and Money Management</h2>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="30" data-aos-duration="300"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-1.png" alt="image">
                            </div>
                            <h3>Global Coverage</h3>
                            <p>Send and receive money internationally with ease. Our global network ensures broad
                                coverage, so you can exchange
                                currencies with ease no matter where you are.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="40" data-aos-duration="400"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-2.png" alt="image">
                            </div>
                            <h3>Lowest Fee</h3>
                            <p>We pride ourselves on offering the lowest fees in the industry. Enjoy cost-effective
                                money transfers without worrying
                                about excessive charges eating into your funds.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-3.png" alt="image">
                            </div>
                            <h3>Simple Transfer Methods</h3>
                            <p>Our platform provides user-friendly and straightforward transfer methods, making it easy
                                for you to send and receive
                                money hassle-free. Say goodbye to complicated processes and hello to simplicity.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="60" data-aos-duration="600"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-4.png" alt="image">
                            </div>
                            <h3>Instant Processing</h3>
                            <p>Experience lightning-fast processing times with our instant transfer feature. Your
                                transactions are completed swiftly,
                                ensuring that your funds reach their destination promptly.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="70" data-aos-duration="700"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-5.png" alt="image">
                            </div>
                            <h3>Bank-level Security</h3>
                            <p>Rest assured that your transactions are safeguarded by bank-level security measures. We
                                prioritize the protection of
                                your financial information, providing you with peace of mind throughout every
                                transaction.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="single-benefits-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="benefits-content">
                            <div class="benefits-image">
                                <img src="webassets/images/benefits/benefits-6.png" alt="image">
                            </div>
                            <h3>Global 24/7 Support</h3>
                            <p>Our dedicated support team is available around the clock to assist you with any queries
                                or concerns. Whether you need
                                help with a transaction or have general inquiries, we're here to provide you with
                                reliable support whenever you need it.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="features-area pt-100">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-4 col-md-12">
                    <div class="features-image" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <img src="webassets/images/features/features-3.png" alt="image">
                        <div class="features-shape">
                            <img src="webassets/images/features/shape-1.png" alt="image">
                        </div>
                    </div>
                </div>
                <div class="col-lg-8 col-md-12">
                    <div class="features-content-wrap" data-aos="fade-left" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <span>Our Features</span>
                        <h3>Fast & Reliable, Money Transfer Limited</h3>
                        <p>Our platform provides a seamless experience for managing your finances abroad. From
                            transferring funds to exchanging
                            currencies, we offer reliable solutions to meet your needs, ensuring a smooth and efficient
                            process from start to
                            finish.</p>
                        <div class="row justify-content-center">
                            <div class="col-lg-6 col-md-6">
                                <div class="single-features-box" data-aos="fade-up" data-aos-delay="50"
                                    data-aos-duration="500" data-aos-once="true">
                                    <div class="icon">
                                        <i class="flaticon-clock"></i>
                                    </div>
                                    <h3>Faster And Affordable </h3>
                                    <ul class="list">
                                        <li><i class="ri-checkbox-circle-line">
                                            </i> Send money quickly and affordably to your loved ones.
                                        </li>
                                        <li><i class="ri-checkbox-circle-line"></i> Enjoy low fees and competitive
                                            exchange rates for every transaction.
                                        </li>
                                    </ul>
                                </div>

                            </div>
                            <div class="col-lg-6 col-md-6">
                                <div class="single-features-box" data-aos="fade-up" data-aos-delay="50"
                                    data-aos-duration="500" data-aos-once="true">
                                    <div class="icon">
                                        <i class="flaticon-shield"></i>
                                    </div>
                                    <h3>Trusted & Secure</h3>
                                    <ul class="list">
                                        <li><i class="ri-checkbox-circle-line"></i> Your security is our top priority.
                                            We employing advanced encryption to ensure the
                                            safety of your transactions.</li>
                                        <li><i class="ri-checkbox-circle-line"></i> Your personal and financial
                                            information is safe with us.</li>
                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


  <div class="coverage-area pt-100 pb-75">
        <div class="container">
            <div class="section-title">
                <span>We Are Covering</span>
                <h2>Get These Local Account Details Pay Just Like Pay A Local</h2>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="10" data-aos-duration="100"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-1.png" alt="image">
                            </div>
                            <h3>British Pound</h3>
                            <p>Explore our coverage for the British Pound currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="20" data-aos-duration="200"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-2.png" alt="image">
                            </div>
                            <h3>Euro EU</h3>
                            <p>Explore our coverage for the Euro EU currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="30" data-aos-duration="300"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-3.png" alt="image">
                            </div>
                            <h3>US Dollar</h3>
                            <p>Explore our coverage for the US Dollar currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="40" data-aos-duration="400"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-4.png" alt="image">
                            </div>
                            <h3>Kuwait Dinar</h3>
                            <p>Explore our coverage for the Kuwait Dinar currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-5.png" alt="image">
                            </div>
                            <h3>Australian Dollar</h3>
                            <p>Explore our coverage for the Australian Dollar currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="60" data-aos-duration="600"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/arab-flag.png" alt="image">
                            </div>
                            <h3>Dirham United Arab</h3>
                            <p>Explore our coverage for the Arab Dirham currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="70" data-aos-duration="700"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/Saudi-Arabia.png" alt="image">
                            </div>
                            <h3>Arabia SAD</h3>
                            <p>Explore our coverage for the Arabia SAD currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/coverage-8.png" alt="image">
                            </div>
                            <h3>Singapore Dollar</h3>
                            <p>Explore our coverage for the Singapore Dollar currency.</p>
                        </div>
                    </div>
                </div>
                <!-- additional flags -->
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/kenyan-flag.png" alt="image">
                            </div>
                            <h3>Kenyan KSHS</h3>
                            <p>Explore our coverage for the Kenyan Shilling currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/uganda-flag.png" alt="image">
                            </div>
                            <h3>Uganda UGX</h3>
                            <p>Explore our coverage for the Ugandan Shilling currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/eritria-flag.png" alt="image">
                            </div>
                            <h3>Eritrean ERN</h3>
                            <p>Explore our coverage for the Eritrean Nakfa currency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="single-coverage-card" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <div class="content">
                            <div class="coverage-image">
                                <img src="webassets/images/coverage/sudan-flag.png" alt="image">
                            </div>
                            <h3>Sudanese SDG</h3>
                            <p>Explore our coverage for the Sudanese pound currency.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="coverage-shape">
            <img src="webassets/images/coverage/shape-1.png" alt="image">
        </div>
        <div class="coverage-shape-2">
            <img src="webassets/images/coverage/shape-2.png" alt="image">
        </div>
    </div>


    <div class="review-area ptb-100">
        <div class="container">
            <div class="section-title">
                <span>Customer Reviews</span>
                <h2>Join Over 4,000 Satisfied Customers Who Trust Our Services</h2>
            </div>
            <div class="review-slides owl-carousel owl-theme">
                <div class="single-review-box" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                    data-aos-once="true">
                    <ul class="review-rating">
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                    </ul>
                    <p>Outstanding service! Sundus Exchange has simplified currency exchange for me. Their platform is
                        user-friendly and efficient. I highly recommend it to anyone needing currency exchange services.
                    </p>
                    <div class="reviewquote-image">
                        <img src="webassets/images/quote-icon.png" alt="image">
                    </div>
                    <div class="review-info">
                        <h3>Thomoson Piterson</h3>
                        <span>Sundus Exchange Partner</span>
                    </div>
                </div>
                <div class="single-review-box" data-aos="fade-up" data-aos-delay="60" data-aos-duration="600"
                    data-aos-once="true">
                    <ul class="review-rating">
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                    </ul>
                    <p>Impressive experience with Sundus Exchange! Their Business ~ customer support is top-notch, and
                        their
                        exchange rates are competitive. I've been using their services for years and have never been
                        disappointed.
                    </p>
                    <div class="reviewquote-image">
                        <img src="webassets/images/quote-icon.png" alt="image">
                    </div>
                    <div class="review-info">
                        <h3>Maxwel Warner</h3>
                        <span>Sundus Exchange Partner</span>
                    </div>
                </div>
                <div class="single-review-box" data-aos="fade-up" data-aos-delay="70" data-aos-duration="700"
                    data-aos-once="true">
                    <ul class="review-rating">
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                        <li><i class="ri-star-line"></i></li>
                    </ul>
                    <p>Exceptional service quality! Sundus Exchange provides fast and reliable currency exchange
                        services. Their
                        rates are transparent, and the entire process is seamless. Highly recommended!
                    </p>
                    <div class="reviewquote-image">
                        <img src="webassets/images/quote-icon.png" alt="image">
                    </div>
                    <div class="review-info">
                        <h3>John Terry</h3>
                        <span>Sundus Exchange Partner</span>
                    </div>
                </div>
            </div>
            <div class="review-optional-content">
                <p>But don’t just take our word for it - check out what our customers have to say about their experience
                    with us: <b>Excellent</b> <span>Based on 25 reviews</span></p>
            </div>
        </div>

    </div>


    <div class="overview-area ptb-100">
        <div class="container">
            <div class="overview-content" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                data-aos-once="true">
                <span>Connect Us</span>
                <h3>Sending International Business Payments or Sending Money To Family Overseas? Sundus Exchange Are
                    Your Fast And
                    Simple Solution.</h3>
                <ul class="overview-btn-group">
                    <li>
                        <a href="HelpCenter.aspx" class="default-btn">Personal Account</a>
                    </li>
                    <li>
                        <a href="HelpCenter.aspx" class="optional-btn">Business Account</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="overview-shape">
            <img src="webassets/images/overview/shape-1.png" alt="image">
        </div>
        <div class="overview-shape-2">
            <img src="webassets/images/overview/shape-2.png" alt="image">
        </div>
    </div>


    <footer class="footer-area pt-100">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-3 col-md-6">
                    <div class="single-footer-widget" data-aos="fade-up" data-aos-delay="50" data-aos-duration="500"
                        data-aos-once="true">
                        <div class="widget-logo">
                            <img src="webassets/images/logo.png" class="black-logo" alt="image">
                            <img src="webassets/images/logo-2.png" class="white-logo" alt="image">
                        </div>
                        <p>To get exclusive updates and benefits.</p>
                        <form class="newsletter-form" data-bs-toggle="validator">
                            <input type="email" class="input-newsletter" placeholder="Enter email" name="EMAIL" required
                                autocomplete="off">
                            <button type="submit" class="default-btn">Subscribe</button>
                            <div id="validator-newsletter" class="form-result"></div>
                        </form>
                        <ul class="widget-social">
                            <li>
                                <a href="https://web.facebook.com/SundusPay/?_rdc=1&_rdr" target="_blank">
                                    <i class="ri-facebook-fill"></i>
                                </a>
                            </li>
                            <li>
                                <a href="https://twitter.com/sunduspay" target="_blank">
                                    <i class="ri-twitter-fill"></i>
                                </a>
                            </li>
                            <li>
                                <a href="https://www.instagram.com/sunduspayofficial/" target="_blank">
                                    <i class="ri-instagram-line"></i>
                                </a>
                            </li>
                            <li>
                                <a href="https://www.linkedin.com/sunduspay" target="_blank">
                                    <i class="ri-linkedin-line"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="single-footer-widget ps-5" data-aos="fade-up" data-aos-delay="60"
                        data-aos-duration="600" data-aos-once="true">
                        <h3>Company And Team</h3>
                        <ul class="quick-links">
                            <li><a href="#">Saturday: 7:30A.M-2:30 P.M</a></li>
                            <li><a href="index.aspx">Our Company</a></li>
                            <li><a href="AboutUs.aspx">About Us</a></li>
                            <li><a href="HelpCenter.aspx">Affiliates And Partnerships</a></li>


                        </ul>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="single-footer-widget ps-5" data-aos="fade-up" data-aos-delay="70"
                        data-aos-duration="700" data-aos-once="true">
                        <h3>Resources</h3>
                        <ul class="quick-links">
                            <li><a href="HelpCenter.aspx">Security</a></li>
                            <li><a href="Faq.aspx">FAQ's</a></li>
                            <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="ContactHQ.aspx">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="single-footer-widget" data-aos="fade-up" data-aos-delay="80" data-aos-duration="800"
                        data-aos-once="true">
                        <h3>Contact Info</h3>
                        <ul class="info-links">
                            <li><span>Location:</span>Hai Malakia. Atlabara Near Hass Petroleum JUBA.</li>
                            <li><span>Email:</span>
                                <a href="mailto:info@sundusexchange.com">info@sundusexchange.com</a>
                            </li>
                            <li><span>Phone:</span><a href="tel:0925206969">0925 206 969</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
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


    <div class="go-top">
        <i class="ri-arrow-up-s-line"></i>
    </div>


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