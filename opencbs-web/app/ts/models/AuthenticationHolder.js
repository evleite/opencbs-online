define(["require", "exports"], function(require, exports) {
    var AuthenticationHolder = (function () {
        function AuthenticationHolder(accessToken, issuedAt, timesOut, userFullname) {
            this.accessToken = accessToken;
            this.issuedAt = issuedAt;
            this.timesOut = timesOut;
            this.userFullname = userFullname;
        }
        AuthenticationHolder.prototype.isAuthenticated = function () {
            // if no accessToken, user is not authenticated
            if (this.accessToken == null) {
                return false;
            }

            // if there is no setting for updated, user is not authenticated
            if (this.timesOut == null) {
                return false;
            }

            if (this.timesOut.getTime() < Date.now()) {
                return true;
            }

            // default the user is not authenticated
            return false;
        };
        return AuthenticationHolder;
    })();
    
    return AuthenticationHolder;
});
//# sourceMappingURL=AuthenticationHolder.js.map
