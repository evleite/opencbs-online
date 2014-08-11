define(["require", "exports"], function(require, exports) {
    console.debug("Load [UrlService]");

    var UrlService = (function () {
        function UrlService() {
            this.BASE_URL = "http://localhost:12007/api";
            this.AUTHENTICATION_URL = this.BASE_URL + "/security/authenticate";
        }
        return UrlService;
    })();

    
    return UrlService;
});
//# sourceMappingURL=UrlService.js.map
