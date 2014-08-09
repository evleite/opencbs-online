import UrlService = require("ts/services/UrlService");

class AuthService {

    accessToken: string = null;
    issuedAt: Date = null;

    constructor(private $http, private $q, private urlService: UrlService) {

    }

    isAuthenticated () : boolean{
        return this.accessToken != null;
    }

    authenticate(username: string, password: string): ng.IPromise<boolean> {
        var req = this.$q.defer();
        var url = this.urlService.AUTHENTICATION_URL;
        var authPromise = this.$http.post(this.urlService.AUTHENTICATION_URL, { username: username, password: password });

        // when the request was successful
        authPromise.success(
            (data, status, headers, config) => {
                //{"accessToken":null,"isValid":true,"message":"Authentication failed.","issuedAt":null}
                //{"accessToken":"NDvgwbXTZNX0EchmZhrdMZemQSW21egm","isValid":true,"message":"Authentication successful.","issuedAt":"2014-07-29T13:05:30.9300000+02:00"}

                // check whether the response was succesful
                if (status != 200) {
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
                }
                else {
                    this.accessToken = data.accessToken;
                    this.issuedAt = data.issuedAt;
                    // set the resolve promise true
                    req.resolve(true);
                }
            });

        // when the request was unsuccessful
        authPromise.error(
            (data, status, headers, config) => {
                req.reject("Authentication request is invalid.");
            });

        return req.promise;
    }
}

export = AuthService;