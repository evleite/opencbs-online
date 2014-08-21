import UrlService = require("ts/services/UrlService");
import AuthenticationHolder = require("ts/models/AuthenticationHolder");

class AuthService {
    authenticationHolder: AuthenticationHolder;


    constructor(private $http: ng.IHttpService, private $q: ng.IQService, private urlService: UrlService) {}

    isAuthenticated(): boolean {
        if (this.authenticationHolder == null) {
            return false;
        }

        return this.authenticationHolder.isAuthenticated();
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
                    this.authenticationHolder = null;

                    // set the resolve promise false
                    req.resolve(false);
                } else {
                    this.authenticationHolder = new AuthenticationHolder(
                        data.accessToken, data.issuedAt, data.timesOut, data.userFullname);

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