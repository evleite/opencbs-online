# opencbs-online

Online Core Banking Solution for microfinance based upon OpenCBS. The core of OpenCBS is wrapped in a JSON API which handles all the interaction with core-functionality and database. The interface is a Angular-SPA, which interacts with the API. This system has the advantage of one single core wrapper which can be used by other interfaces as well.

## Compatibility
OpenCBS Online is compatible with the database of the original OpenCBS Windows application. The code however is altered and it is not possible to directly compile the original project and place the resulting DLL's in OpenCBS Online. Core functionality is changed to make sure it operates save within the multi-threaded and stateless environment of the web.

## IDE
Development is done in Visual Studio 2013 (free version is enough) with some additional (free) plugins:
- Web Essentials 2013 (needed)
- NuUnit Test Runner (optional)
- Nancy Templates (optional)

## Projects
The system consists of the following projects:
* opencbs-service: JSON API as a wrapper around the core functionality
* opencbs-web: Angular SPA as web interface
* opencbs-service.Tests: Unit tests for opencbs-service
* opencbs-service.Tests.Core: Unit tests for the original OpenCBS core functionality changed for this project
* opencbs-service.IntegrationTests: Full integration tests for opencbs-service

### opencbs-service
The opencbs-service is built as a JSON API on the NancyFX framework written in C# / .NET as is the core. 
DAO: Dapper
DI: StructureMap 3
Logger: NLog

### opencbs-web
Angular SPA application which uses TypeScript to write JavaScript. 
Libraries used:
* RequireJS
* Bootstrap
* Jasmine

Frameworks used:
* Bower for client-side package management
* NPM for server-side package management
* TSD for typescript (*d.ts) file management
* Jasmine as Test Runner (SpecRunner.html allows for debugging TypeScript)

### IIS Express Setup
opencbs-web and opencbs-service need to run on the same server and port to make sure the AJAX calls are allowed. To facilitate this the projects are configured to have both run on the same port (12007). opencbs-service runs on http://localhost:12007/api and opencbs-web on http://localhost:12007/ (root);

## Environment setup
Setting up the environment for development has some requirements.

### Visual Studio
Web Essentials plugin to configure TypeScript to built in AMD mode.
NUnit Test Adapter to allow running tests in the Test Explorer.

### JavaScript
For the Angular development environment the folowing steps are needed:
* Install NodeJS so you have NPM
* Install GIT (required for Bower)
On a command line:
* npm install -g bower
* npm install -g grunt
* npm install -g grunt-cli
* npm install -g karma
* npm install -g karma-cli
* npm install tsd -g
* grunt install
* bower install
* tsd reinstall
* grunt

The last four commands are actually not needed as all the files used are checked in. If you want to make sure all the packages are properly downloaded and installed you can savely run these commands. They are based on versioned configuration files.

