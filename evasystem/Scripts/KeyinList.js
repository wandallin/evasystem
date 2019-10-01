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

    $scope.delete = function (keyinId) {
        var checkDelete = confirm('確定刪除');

        if (checkDelete) {
            var postData = {
                KeyinId: keyinId
            }
            $http({
                url: AppsettingService.BaseURL + '/Func/DeleteKeyinData',
                data: postData,
                method: "POST",
            }).success(function (res) {
                Init.LoadingStart();
                Init.ShowInfoMsg("Success");
                $scope.GetKeyinListData();
                Init.LoadingEnd();
            }).error(function () {
                Init.ShowErrorMsg("server error");
                Init.LoadingEnd();
            });
        }
    }
})

app.filter('KeyinType', function () {
    return function (data) {
        var colorArr = ['未輸入', '無效', 'A單', 'B單' ,'可追追看'];
        var intStatus = parseInt(data);
        return colorArr[intStatus];
    }
});

app.filter('KeyinStatus', function () {
    return function (data) {
        var colorArr = ['未成交', '成交'];
        var intStatus = parseInt(data);
        return colorArr[intStatus];
    }
});

app.filter('KeyinTrandate', function () {
    return function (data) {
        return data == '1970-01-01T00:00:00' ? '' : data;
    }
});
