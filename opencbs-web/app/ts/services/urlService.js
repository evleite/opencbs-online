define(["require", "exports"], function(require, exports) {
    var UrlService = (function () {
        function UrlService() {
            this.BASE_URL = "/api";
            this.AUTHENTICATION_URL = this.BASE_URL + "/security/authenticate";
        }
        return UrlService;
    })();

    
    return UrlService;
});
//# sourceMappingURL=UrlService.js.map
