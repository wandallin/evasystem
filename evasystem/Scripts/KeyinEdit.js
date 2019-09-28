app.controller('KeyinEditCtrl', function ($scope, $http, ngDialog, AppsettingService) {
    $scope.result = {};
    $scope.KeyinId = $('#hdKeyinId').val();

    $scope.SearchParam = {
        StartDate: { Value: null, ShowFlag: false },
        EndDate: { Value: null, ShowFlag: false },
        ProductLine: { LevelTagId: 0 }
    }
    $scope.Tran = {
        StartDate: { Value: null, ShowFlag: false },
        EndDate: { Value: null, ShowFlag: false },
        ProductLine: { LevelTagId: 0 }
    }

 

    $scope.ClickOpenDate = function (DateValue) {
        var toDayMidnight = new Date();
        toDayMidnight.setDate(toDayMidnight.getDate() + 1);
        toDayMidnight.setHours(0, 0, 0, 0);

        DateValue.ShowFlag = true;
        DateValue.Value = toDayMidnight;
    }

    $scope.Init = function () {
        $scope.GetKeyinData();
    }

    $scope.GetKeyinData = function () {
        var postData = {
            KeyinId: $scope.KeyinId,
        };

        Init.LoadingStart();
        $http({
            url: AppsettingService.BaseURL + '/Func/GetKeyinData',
            data: postData,
            method: "POST",
        }).success(function (res) {
            if (res.Result) {
                Init.ShowInfoMsg("Success");
                console.log(res.Result)
                $scope.result = res.Result;
                $scope.Type = String(res.Result.Type);
                $scope.Status = String(res.Result.Status);
               
               
            }
            Init.LoadingEnd();
        }).error(function () {
            Init.ShowErrorMsg("server error");
            Init.LoadingEnd();
        });
    }

    $scope.update = function () {
        console.log($scope.Status)
    }

    $scope.Save = function () {
        var keyin = {
            name: $scope.name,
            classname: $scope.classname,
            grade: $scope.grade,
            phone: $scope.phone,
            quest: $scope.quest,
            money: $scope.money,
            type: $scope.type,
            status: $scope.transaction,
            contract: $scope.contract,
            askdate: $scope.formatDate($scope.SearchParam.StartDate.Value),
            trandate: $scope.formatDate($scope.Tran.StartDate.Value),
        };

        var postData = {
            data: keyin
        };

        Init.LoadingStart();
        $http({
            url: AppsettingService.BaseURL + '/Func/KeyinSave',
            data: postData,
            method: "POST",
        }).success(function (res) {
            console.log(res.Result)
            if (res.Result) {
                Init.ShowInfoMsg("Success");
                $scope.resetData();
            }
            Init.LoadingEnd();
        }).error(function () {
            Init.ShowErrorMsg("server error");
            Init.LoadingEnd();
        });
    }

    $scope.formatDate = function (date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [year, month, day].join('/');
    }
})