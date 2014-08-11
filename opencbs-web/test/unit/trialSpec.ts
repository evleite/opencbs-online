declare var define: RequireDefine;

define([], () => {
    describe('Test Unit Test - RequireJS',  () => {
        it('Contains passing spec', () =>  {
            expect(true).toBe(true);
            expect("").toBe("");
        });
    });

}); 