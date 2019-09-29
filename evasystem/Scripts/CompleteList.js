app.controller('CompleteListCtrl', function ($scope, $http, ngDialog, AppsettingService) {
    $scope.Init = function () {
        $scope.GetCompleteListData();
    }

    $scope.GetCompleteListData = function () {
        $http({
            url: AppsettingService.BaseURL + '/Func/GetCompleteListData',
            method: "POST",
        }).success(function (res) {
            Init.LoadingStart();
            $scope.KeyinList = res.Result;
            Init.LoadingEnd();
        }).error(function () {
            Init.ShowErrorMsg("server error");
            Init.LoadingEnd();
        });
    }
})

app.filter('KeyinTrandate', function () {
    return function (data) {
        return data == '1970-01-01T00:00:00' ? '' : data;
    }
});
