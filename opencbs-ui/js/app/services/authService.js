

//app.factory('authService', function ($http) {
var AuthService = function($http, $q, urlService){
    var accessToken = null;
    var issuedAt = null;

    this.isAuthenticated = function () {
        return !(accessToken == null);
    };

    this.authenticate = function (credentials) {
        var req = $q.defer();
        var url = urlService.AUTHENTICATION_URL;
        var authPromise = $http.post(urlService.AUTHENTICATION_URL, credentials);
        
        // when the request was successful
        authPromise.success(function (data, status, headers, config) {
            //{"accessToken":null,"isValid":true,"message":"Authentication failed.","issuedAt":null}
            //{"accessToken":"NDvgwbXTZNX0EchmZhrdMZemQSW21egm","isValid":true,"message":"Authentication successful.","issuedAt":"2014-07-29T13:05:30.9300000+02:00"}

            // check whether the response was succesful
            if (status != 200) {
                req.reject('Authentication request failed.');
            } // check whether the data was valid
            else if (!data.isValid) {
                req.reject('Authentication request is invalid.');
            } // request seems to have gone correct, check the result
            else if (!data.accessToken) {
                accessToken = null;
                issuedAt = null;
                // set the resolve promise false
                req.resolve(false);
            }
            else {
                accessToken = data.accessToken;
                issuedAt = data.issuedAt;
                // set the resolve promise true
                req.resolve(true);                
            }
        });

        // when the request was unsuccessful
        authPromise.error(function (data, status, headers, config) {
            req.reject('Authentication request is invalid.');
        });

        return req.promise;
    }


}