///<amd-dependency path="jquery"/>
///<amd-dependency path="jquery.bootstrap"/>
///<amd-dependency path="spin"/>
///<amd-dependency path="ladda"/>

import AuthService = require("ts/services/AuthService");

console.debug("Load [LoginController]");

interface ILoginControllerScope extends ng.IScope {
    authenticationResult: string;
    login(username: string, password: string): void;
    loginForm: ng.IFormController;
    vm: ILoginControllerScope;
}

export class LoginController {

    // inject dependencies
    //static $inject = ["$scope", "$location", "AuthService"];
        
    constructor(private $scope, private $location, private authService: AuthService) {
        console.log("Instantiate [LoginController]");
        $scope.vm = this;
    }

    login(username: string, password: string): void {
        var Ladda = require("ladda");

        // reset the submitted flag
        this.$scope.loginForm.submitted = false;
        // check whether the form is valid
        if (!this.$scope.loginForm.$valid) {
            this.$scope.loginForm.submitted = true;
            return;
        } 
        
        // if the for is valid continue
        var btnLoginSubmit: Element  = document.getElementById("btnLoginSubmit");
        var l: Ladda.ILaddaButton = Ladda.create(btnLoginSubmit);
        l.start();
        // authenticate using promise
        this.authService.authenticate(username, password)
            .then((result) => {
                // successful authentication process, check the result
                if (result) {
                    // login valid
                    this.$scope.authenticationResult = null;
                    this.$location.path("/").replace();
                }
                else {
                    // login failed
                    this.$scope.authenticationResult = "Login failed";
                }
                l.stop();
            }, (err) => {
                // authentication process threw an error
                this.$scope.authenticationResult = err;
                l.stop();
            });
    }   
}