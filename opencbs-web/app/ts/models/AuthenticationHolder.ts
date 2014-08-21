class AuthenticationHolder {

    constructor(public accessToken: string, public issuedAt: Date, public timesOut: Date, public userFullname: string) { }

    isAuthenticated(): boolean {
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
    }
}
export = AuthenticationHolder;