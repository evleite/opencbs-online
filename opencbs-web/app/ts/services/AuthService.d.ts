import UrlService = require("ts/services/UrlService");
declare class AuthService {
    private $http;
    private $q;
    private urlService;
    public accessToken: string;
    public issuedAt: Date;
    constructor($http: any, $q: any, urlService: UrlService);
    public isAuthenticated(): boolean;
    public authenticate(username: string, password: string): ng.IPromise<boolean>;
}
export = AuthService;
