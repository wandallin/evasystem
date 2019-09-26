app.controller('KeyinListCtrl', function ($scope, $http, ngDialog, AppsettingService) {
    $scope.Init = function () {
        $scope.GetKeyinListData();
    }

    $scope.GetKeyinListData = function () {
        $http({
            url: AppsettingService.BaseURL + '/Func/GetKeyinListData',
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

app.filter('KeyinType', function () {
    return function (Type) {
        var colorArr = ['未輸入', '無效', 'A單', 'B單'];
        var intStatus = parseInt(Type);
        return colorArr[intStatus];
    }
});

app.filter('KeyinStatus', function () {
    return function (Type) {
        var colorArr = ['未成交', '成交'];
        var intStatus = parseInt(Type);
        return colorArr[intStatus];
    }
});