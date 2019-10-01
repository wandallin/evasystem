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
                $scope.SearchParam.StartDate.Value = res.Result.Askdate == '1970-01-01T00:00:00' ? null : res.Result.Askdate ;
                $scope.Tran.StartDate.Value = res.Result.Trandate == '1970-01-01T00:00:00' ? null : res.Result.Trandate ;
               
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

    $scope.Cancel = function () {
        window.location.href = "/func/KeyinList";
    }

    $scope.Save = function () {
        var keyin = {
            id: $scope.KeyinId,
            name: $scope.result.Name,
            classname: $scope.result.Classname,
            grade: $scope.result.Grade,
            phone: $scope.result.Phone,
            quest: $scope.result.Quest,
            money: $scope.result.Money,
            keyintype: $scope.Type,
            status: $scope.Status,
            contract: $scope.result.Contract,
            askdate: $scope.formatDate($scope.SearchParam.StartDate.Value),
            trandate: $scope.formatDate($scope.Tran.StartDate.Value),
        };

        var postData = {
            data: keyin
        };

        Init.LoadingStart();
        $http({
            url: AppsettingService.BaseURL + '/Func/KeyinEditSave',
            data: postData,
            method: "POST",
        }).success(function (res) {
            console.log(res.Result)
            if (res.Result) {
                Init.ShowInfoMsg("Success");
                window.location.href = "/func/KeyinList";
            } else {
                Init.ShowInfoMsg("Error");
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