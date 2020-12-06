var ApiUrl='http://localhost:5000';

var app = angular.module('LoginApp', ['ngRoute']);

app.config(function($httpProvider) {
$httpProvider.defaults.useXDomain = true;
delete $httpProvider.defaults.headers
.common['X-Requested-With'];
});
 app.controller('LoginController', function ($scope, $http) {
    $scope.GetUserId = function () {
        $http({
            method: 'GET',
            url: ApiUrl+'/api/user/'+$scope.username
        }).then(function success(response) {
            if (response.data.userName !=''||response.data.userName!=null) {
                location.href = "app.html"
            }
            else {
                alert("用户信息不存在")
            }
        }, function errorCallback(response) {
            alert("出现异常请查看日志");
            console.log(response)
        });
    }
	
	
}); 

