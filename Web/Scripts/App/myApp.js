angular.module('App', ['AngularDemo.EmpAddController',
                       'AngularDemo.AddressController',
                       'AngularDemo.DeleteController'
])

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Home/AddEmployee',
        controller: 'EmpAddCtrl',
    });
    $routeProvider.when('/Edit', {
        templateUrl: '/Home/EditEmployee',
        controller: 'EditCtrl'
    });
    $routeProvider.when('/Delete', {
        templateUrl: '/Home/DeleteEmployee',
        controller: 'DeleteCtrl'
    });
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(false).hashPrefix('!');

}]);

//Add Employee Controller
angular.module('AngularDemo.EmpAddController', ['ngRoute'])
.controller('EmpAddCtrl', function ($scope, $http) {

    $scope.EmpAddressList = {};
    $http.get('/Home/ShowEmpList').success(function (data) {
        $scope.EmpAddressList = data;
      
    });


    $scope.EmpDetailsModel =
     {
         EmpID: '',
         EmpName: '',
         EmpPhone: ''
     };

    $scope.EmpAddressModel =
    {
        Address1: '',
        Address2: '',
        Address3: ''
    };

    $scope.EmployeeViewModel = {
        empDetailModel: $scope.EmpDetailsModel,
        empAddressModel: $scope.EmpAddressModel
    };


    $scope.AddEmployee = function () {
        //debugger;
        $.ajax({
            url: '/Home/AddEmpDetails',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            traditional: true,
            data: JSON.stringify({ EmployeeViewModelClient: $scope.EmployeeViewModel }),
            success: function (data) {
                $scope.EmpAddressList.push(data[0]);
                $scope.$apply();
                //$scope.$apply();
                alert("Record is been added");
            }
        });
    };
});


//Address Controller
angular.module('AngularDemo.AddressController', ['ngRoute'])
.controller('EditCtrl', function ($scope, $http) {
    $scope.Message = "Edit in Part 2 is coming soon";
});

angular.module('AngularDemo.DeleteController', ['ngRoute'])
.controller('DeleteCtrl', function ($scope, $http) {
    $scope.Message = "Delete in Part 2 is coming soon";
});

