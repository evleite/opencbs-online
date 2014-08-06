/*jslint browser: true*/
/*global $, angular*/
/*global $, app*/

app.controller('MyController', function ($scope, $filter) {
    "use strict";
    
    $scope.message = $filter('uppercase')('Oskar');
});

app.controller('ParentController', function ($scope) {
    "use strict";

    $scope.person = { greeted: false };

});

app.controller('ChildController', function ($scope) {
    "use strict";

    $scope.sayHello = function () {
        $scope.person.name = 'Ari Lerner';
        $scope.person.greeted = true;
    };

    $scope.sayGoodbye = function () {
        $scope.person.name = null;
        $scope.person.greeted = false;
    };

});

app.controller('FilterController', function ($scope) {
    "use strict";

    $scope.today = new Date();
});