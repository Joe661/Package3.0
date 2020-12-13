var ApiUrl='http://localhost:5000';

var app = angular.module('PackageApp', ['ngRoute']);

app.config(function($httpProvider) {
$httpProvider.defaults.useXDomain = true;
delete $httpProvider.defaults.headers
.common['X-Requested-With'];
});
 
app.controller('UplaodController', function ($scope, $route) { $scope.$route = $route; })
app.controller('InExShowController', function ($scope, $route) { $scope.$route = $route; })
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

app.config(['$routeProvider',
         function($routeProvider) {
            $routeProvider.
               when('/default', {
                  templateUrl: 'default.html',
                  controller: 'UplaodController'
               }).
               when('/inexshow', {
                  templateUrl: 'inexshow.html',
                  controller: 'InExShowController'
               }).
               otherwise({
                  redirectTo: '/default'
               });
         }]);

/* app.config(function ($routeProvider) {
    $routeProvider.
        when('/default', {
            templateUrl: 'default.html',
            controller: 'UplaodController'
        }).
        when('/inexshow', {
            templateUrl: 'inexshow.html',
            controller: 'InExShowController'
        }).
        otherwise({
            redirectTo: '/default'
        });
}); */ 

app.controller("AppController", function ($scope, $http) {
    // 父级接收  
    $scope.$on('page', function (event, data) {
        $scope.page = data;
    });

    $scope.GetMenuList = function () {
        $http.get(ApiUrl+'/api/menu').then(
            function (data) {
                $scope.menulist = data.data;
        })
		
		$scope.$broadcast('config.ApiUrl', ApiUrl);
    }

    $scope.GetMenuList();
})
 