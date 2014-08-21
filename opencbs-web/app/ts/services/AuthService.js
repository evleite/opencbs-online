define(["require", "exports", "ts/models/AuthenticationHolder"], function(require, exports, AuthenticationHolder) {
    var AuthService = (function () {
        function AuthService($http, $q, urlService) {
            this.$http = $http;
            this.$q = $q;
            this.urlService = urlService;
        }
        AuthService.prototype.isAuthenticated = function () {
            if (this.authenticationHolder == null) {
                return false;
            }

            return this.authenticationHolder.isAuthenticated();
        };

        AuthService.prototype.authenticate = function (username, password) {
            var _this = this;
            var req = this.$q.defer();
            var authPromise = this.$http.post(this.urlService.AUTHENTICATION_URL, { username: username, password: password });

            // when the request was successful
            authPromise.success(function (data, status, headers, config) {
                // check whether the response was succesful
                if (status !== 200) {
                    req.reject("Authentication request failed.");
                } else if (!data.isValid) {
                    req.reject("Authentication request is invalid.");
                } else if (!data.accessToken) {
                    _this.authenticationHolder = null;

                    // set the resolve promise false
                    req.resolve(false);
                } else {
                    _this.authenticationHolder = new AuthenticationHolder(data.accessToken, data.issuedAt, data.timesOut, data.userFullname);

                    // set the resolve promise true
                    req.resolve(true);
                }
            });

            // when the request was unsuccessful
            authPromise.error(function (data, status, headers, config) {
                req.reject("Authentication request is invalid.");
            });

            return req.promise;
        };
        return AuthService;
    })();

    
    return AuthService;
});
//# sourceMappingURL=AuthService.js.map
