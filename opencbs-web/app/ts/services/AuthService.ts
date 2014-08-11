import UrlService = require("ts/services/UrlService");

class AuthService {

    accessToken: string = null;
    issuedAt: Date = null;

    //static $inject = ["$http", "$q", "UrlService"];

    constructor(private $http: ng.IHttpService, private $q: ng.IQService, private urlService: UrlService) {
        
    }

    isAuthenticated () : boolean{
        return this.accessToken != null;
    }

    authenticate(username: string, password: string): ng.IPromise<boolean> {
        var req: ng.IDeferred<{}> = this.$q.defer();
        var authPromise: any = this.$http.post(this.urlService.AUTHENTICATION_URL, { username: username, password: password });

        // when the request was successful
        authPromise.success(
            (data: any, status: number, headers: any, config: any): void => {
                
                // check whether the response was succesful
                if (status !== 200) {
                    req.reject("Authentication request failed.");
                } // check whether the data was valid
                else if (!data.isValid) {
                    req.reject("Authentication request is invalid.");
                } // request seems to have gone correct, check the result
                else if (!data.accessToken) {
                    this.accessToken = null;
                    this.issuedAt = null;
                    // set the resolve promise false
                    req.resolve(false);
                } else {
                    this.accessToken = data.accessToken;
                    this.issuedAt = data.issuedAt;
                    // set the resolve promise true
                    req.resolve(true);
                }
            });

        // when the request was unsuccessful
        authPromise.error(
            (data: any, status: number, headers: any, config: any): void => {
                req.reject("Authentication request is invalid.");
            });

        return req.promise;
    }
}

export = AuthService;