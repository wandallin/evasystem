app.controller('KeyinCtrl', function ($scope, $http, ngDialog, AppsettingService) {
    $scope.type = '1';
    $scope.transaction = '0';

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

    }

    $scope.Save = function () {
        var keyin = {
            name: $scope.name,
            classname: $scope.class,
            phone: $scope.phone,
            quest: $scope.quest,
            type: $scope.type,
            status: $scope.transaction,
            askdate: $scope.formatDate($scope.SearchParam.StartDate.Value),
            trandate: $scope.formatDate($scope.Tran.StartDate.Value),
        };

        var postData = {
            data: keyin
        };
        console.log(postData)
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

    $scope.resetData = function () {
        $scope.name = '';
        $scope.class = '';
        $scope.phone = '';
        $scope.quest = '';
        $scope.type = '1';
        $scope.transaction = '0';
        $scope.SearchParam = {
            StartDate: { Value: null, ShowFlag: false },
            EndDate: { Value: null, ShowFlag: false },
            ProductLine: { LevelTagId: 0 }
        };
        $scope.Tran = {
            StartDate: { Value: null, ShowFlag: false },
            EndDate: { Value: null, ShowFlag: false },
            ProductLine: { LevelTagId: 0 }
        };
    }
})