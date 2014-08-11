define(["ts/app", "angular", "angular-route", "angular-mocks"], function (app, angular, angularRoute, angularMocks) {
    
    describe("Routes configuration Spec", function() {

        var scope;

        beforeEach(angularMocks.module("openCbs"));

        beforeEach(angularMocks.inject(function ($rootScope) {
                scope = $rootScope.$new();
            })

        );
       
        it("Login Route", function () {
            expect(false).toBe(false);
        });

        
        
        

    });
});
/*
*/

 