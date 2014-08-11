/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../../typings/requirejs/require.d.ts" />
export declare class OpenCbs {
    public app: ng.IModule;
    constructor(app: ng.IModule);
    public addController(name: string, controllerFn: Function): void;
    public addControllerInline(name: string, inlineAnnotatedConstructor: any[]): void;
    public addService(name: string, serviceFn: Function): void;
    public startUp(): void;
    public configure(): void;
}
