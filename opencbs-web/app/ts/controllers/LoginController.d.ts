import AuthService = require("ts/services/AuthService");
export declare class LoginController {
    private $scope;
    private $location;
    private authService;
    constructor($scope: any, $location: any, authService: AuthService);
    public login(username: string, password: string): void;
}
