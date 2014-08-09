class UrlService {

    BASE_URL: string = "http://localhost:12007/api";

    AUTHENTICATION_URL:string = this.BASE_URL + "/security/authenticate";
}

export = UrlService;