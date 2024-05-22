

(function () {
    var app = angular.module("SundusEx", ['ngResource', 'ngTable', 'ngCookies', 'ngSanitize', 'ngMap'])

    app.service("currencyDelimiterService",
        function () {
            this.formatCurrency = function (Num) {
                Num += '';
                Num = Num.replace(/,/g, '');

                x = Num.split('.');
                x1 = x[0];

                x2 = x.length > 1 ? '.' + x[1] : '';

                //--http://dotnetgyaan.blogspot.co.ke/2012/01/add-comma-automatically-while-entering.html
                //var rgx = /(\d)((\d)(\d{2}?)+)$/;
                var rgx = /(\d)((\d{3}?)+)$/;

                while (rgx.test(x1))
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');

                return x1 + x2;
            }
        }); 

    app.service("msgsuccess",
        function () {
            this.msgsuccess = function (message) {
                notifier.show('Sucsess!', message, 'success', 'assets/icons/shield.gif', 6000);
            }
        });

    app.service("msgerr",
        function () {
            this.msgerr = function (message) {
                notifier.show('Error!', message, 'danger', 'assets/icons/cancel.gif', 6000);
            }
        });


    app.service("errmsg",
        function () {
            this.errmsg = function (message) {
                notifier.show('Error!', message, 'danger', 'assets/icons/cancel.gif', 6000);
            }
        });
    app.service("succmsg",
        function () {
            this.succmsg = function (message) {
                notifier.show('Sucsess!', message, 'success', 'assets/icons/shield.gif', 6000);
            }
        });

    app.controller("LoginCtrl",
        [
            '$scope', '$http', '$window', 'succmsg', 'errmsg',
            function ($scope, $http, $window, succmsg, errmsg) {
                $scope.loading = false; 

                $scope.Login = function () {

                    $scope.loading = true;
                    $scope.DisableButton = true;

                    $scope.showErrorResponseMessage = false;
                    $scope.showSuccessResponseMessage = false;
                    $scope.errorResponseMessage = "";
                    $scope.DisableButton = false;


                    if ($scope.UserName === "") {
                        errmsg.errmsg("Please enter your username");
                       
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }

                    if ($scope.Password === "") {
                        errmsg.errmsg("Please enter your password.");
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }

                    var args = {
                        UserName: $scope.UserName,
                        Password: $scope.Password
                    }

                    $http({
                        method: "POST",
                        url: "SundusEx.asmx/Login",
                        dataType: 'json',
                        responseType: 'json',
                        data: JSON.stringify(args),
                        headers: { "Content-Type": "application/json" }
                    }).then(function (response) {
                        if (response.status.toString() === "200") {
                            // check for error messages
                            $http.post("SundusEx.asmx/CheckForErrorMessages")
                                .then(function success(response) {

                                    var errorMessage = response.data.Message;
                                    if (errorMessage !== "") {
                                        errmsg.errmsg(errorMessage)
                                        $scope.DisableButton = false;
                                        $scope.loading = false;

                                    } else {
                                        succmsg.succmsg("Login successfull")
                                        $scope.loading = false;
                                        $window.location.href = "/HLogin.aspx";
                                    }

                                    $scope.loading = false;
                                },
                                    function error(response) {
                                        //console.log(response);
                                    });
                        }
                    });
                }


            }
        ]);

    app.controller("AllStaffCtrl",
        [
            "$scope", "$http", "$resource", "NgTableParams", "$window", 'msgsuccess', 'msgerr',
            function ($scope, $http, $resource, NgTableParams, $window, msgsuccess, msgerr) {
                $scope.loading = true;
                $scope.StaffID = "0";
                $scope.StaffName = ""; 
                $scope.Email = "";
                $scope.NationalID = "";  
                $scope.RoleID = "0"; 
                $scope.EmploymentStatusID = "1";
                $scope.PhoneNumber = +254;

                $scope.DisableButton = false;

                getAllStaff(); 

                getRoles(); 


                function getAllStaff() {
                    var Api = $resource("SundusEx.asmx/GetAllStaff");
                    $scope.tableParams = new NgTableParams({},
                        {
                            getData: function (params) {
                                return Api.query(params.url()).$promise.then(function (data) {
                                    params.total(data.length); // recal. page nav 

                                    $scope.loading = false;
                                    $scope.Staff = data;

                                    if (Object.keys($scope.Staff).length > 0) {
                                        $scope.tableParams = new NgTableParams({}, { dataset: $scope.Staff });
                                    }
                                    return data;
                                });
                            }
                        });

                }
                 
                function getRoles() {
                    $http.post('SundusEx.asmx/GetRoles')
                        .then(function (response) {
                            $scope.Roles = response.data;
                        }).finally(function () {
                        });
                } 

                // close Job modal
                $scope.closeModal = function () {
                    $scope.loading = false;
                    $scope.StaffID = "0";
                    $scope.StaffName = ""; 
                    $scope.Email = "";
                    $scope.NationalID = ""; 
                    $scope.RoleID = "0"; 
                    $scope.EmploymentStatusID = "1";
                    $scope.PhoneNumber = +254;
                    $scope.DisableButton = false; 
                }



                $scope.saveStaffDetails = function () {

                    $scope.DisableButton = true;
                    $scope.loading = true;

                    $scope.showErrorResponseMessage = false;
                    $scope.showSuccessResponseMessage = false;
                    $scope.errorResponseMessage = "";


                    if ($scope.StaffName === "") {
                        msgerr.msgerr("Please enter the Name");
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }
                    
                    if ($scope.NationalID === "") {
                        msgerr.msgerr("Please enter the National ID");
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }

                    if ($scope.Email === "") {
                        msgerr.msgerr("Please enter the email.");
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }

                    if ($scope.PhoneNumber === "") {
                        msgerr.msgerr("Please enter the Phone number");
                        $scope.DisableButton = false;
                        $scope.loading = false;
                        return;
                    }

                    var args = {}

                    args = {
                        StaffID: $scope.StaffID,
                        StaffName: $scope.StaffName,
                        Email: $scope.Email,
                        NationalID: $scope.NationalID,
                        PhoneNumber: $scope.PhoneNumber,
                        RoleID: $scope.RoleID,
                        EmploymentStatusID: $scope.EmploymentStatusID,
                    }

                    $http(
                        {
                            method: 'POST',
                            url: 'SundusEx.asmx/SaveStaffDetails',
                            dataType: 'json',
                            responseType: 'json',
                            data: JSON.stringify(args),
                            headers: { "Content-Type": "application/json" }
                        }).then(function (response) {
                            $scope.loading = false;
                            $scope.StaffID = "0";
                            $scope.StaffName = "";
                            $scope.Email = "";
                            $scope.NationalID = "";
                            $scope.RoleID = "0";
                            $scope.EmploymentStatusID = "1";
                            $scope.PhoneNumber = +254; 
                            msgsuccess.msgsuccess("saved Successfully");
                            $scope.DisableButton = false;
                            getAllStaff();

                        },
                            function error(response) {

                                $scope.loading = false;

                                let errorMessage = (angular.isObject(response)
                                    ? (angular.isObject(response.data)
                                        ? ('Message' in response.data ? response.data.Message : response.Message)
                                        : response.data)
                                    : response);

                                if (errorMessage.includes("You do not have an active session")) {
                                    $window.location.href = "/Logout.aspx";
                                }

                                msgerr.msgerr(errorMessage);
                                $scope.DisableButton = false;
                            });
                }

                $scope.showAddStaffModal = function () {
                    $scope.loading = false;
                    $scope.StaffID = "0";
                    $scope.StaffName = "";
                    $scope.Email = "";
                    $scope.NationalID = "";
                    $scope.RoleID = "0";
                    $scope.EmploymentStatusID = "1";
                    $scope.PhoneNumber = +254;
                    $scope.DisableButton = false; 
                }

                $scope.ShowEditStaff = function (Staff) {
                    $scope.StaffID = Staff.StaffID;
                    $scope.StaffName = Staff.StaffName; 
                    $scope.Email = Staff.Email;
                    $scope.NationalID = Staff.NationalID;
                    $scope.PhoneNumber = Staff.PhoneNumber;
                    $scope.RoleID = Staff.RoleID; 
                    $scope.EmploymentStatusID = Staff.EmploymentStatusID; 
                    $scope.PhoneNumber = Staff.PhoneNumber; 

                    $scope.loading = false; 
                    $scope.DisableButton = false;
                }


                $scope.deleteStaff = function () {

                    $scope.DisableButton = true;
                    $scope.loading = true;

                    var args = {}

                    args = {
                        StaffID: $scope.StaffID
                    }


                    $http(
                        {
                            method: 'POST',
                            url: 'SundusEx.asmx/DeleteStaff',
                            dataType: 'json',
                            responseType: 'json',
                            data: JSON.stringify(args),
                            headers: { "Content-Type": "application/json" }
                        }).then(function (response) {
                            $scope.loading = false;
                            $scope.StaffID = "0";
                            $scope.StaffName = "";
                            $scope.Email = "";
                            $scope.NationalID = "";
                            $scope.RoleID = "0";
                            $scope.EmploymentStatusID = "1";
                            $scope.PhoneNumber = +254;
                            $scope.DisableButton = false; 
                            msgsuccess.msgsuccess("Deleted successfully");
                            $scope.DisableButton = false;
                            getAllStaff();

                        },
                            function error(response) {

                                $scope.loading = false;

                                let errorMessage = (angular.isObject(response)
                                    ? (angular.isObject(response.data)
                                        ? ('Message' in response.data ? response.data.Message : response.Message)
                                        : response.data)
                                    : response);

                                if (errorMessage.includes("You do not have an active session")) {
                                    $window.location.href = "/Logout.aspx";
                                }

                                msgerr.msgerr(errorMessage);
                                $scope.showErrorResponseMessage = true;
                                $scope.successMessage = '';
                                $scope.showSuccessMessage = false;
                                $scope.DisableButton = false;
                            });
                }

            }
        ]);

})();