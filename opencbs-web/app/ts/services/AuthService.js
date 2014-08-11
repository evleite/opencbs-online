define(["require", "exports"], function(require, exports) {
    var AuthService = (function () {
        //static $inject = ["$http", "$q", "UrlService"];
        function AuthService($http, $q, urlService) {
            this.$http = $http;
            this.$q = $q;
            this.urlService = urlService;
            this.accessToken = null;
            this.issuedAt = null;
        }
        AuthService.prototype.isAuthenticated = function () {
            return this.accessToken != null;
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
                    _this.accessToken = null;
                    _this.issuedAt = null;

                    // set the resolve promise false
                    req.resolve(false);
                } else {
                    _this.accessToken = data.accessToken;
                    _this.issuedAt = data.issuedAt;

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
