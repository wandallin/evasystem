app.controller('LoginCtrl', function ($scope, $http, ngDialog, AppsettingService) {
    $scope.username = "";
    $scope.password = "";

    // ========== 初始化資料 ==========
    $scope.InitData = function () {

    }

    $scope.Login = function () {
        var postData = {
            username: $scope.username,
            password: $scope.password
        };
        Init.LoadingStart();
        $http({
            url: AppsettingService.BaseURL + '/Home/Login',
            data: postData,
            method: "POST",
        }).success(function (res) {
            if (res == "True") {
                window.location = AppsettingService.BaseURL + "/func/Keyin";
            }
            else {
                Init.ShowErrorMsg('登入失敗');
            }
            Init.LoadingEnd();
        }).error(function () {
            Init.ShowErrorMsg("server error");
            Init.LoadingEnd();
        });
    }
})