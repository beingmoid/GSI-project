# GSI-project# Backend

## Connection String
> Set connection string in appsettings.json for Production and appsettings.Development.json for Development enviroment.

## Migration

### Create Migration
	Add-Migration <file-name> -v -Project DAL -Context ApplicationContext

> Keep file name with date and time e.g. 200112311325

### Update Migration
     Update-Database -v -Project DAL -Context ApplicationContext 

### Remove Last Migration
    Remove-Migration -Project DAL -Context ApplicationContext 

### Remove Migration From Database
> If migration(s) are updated in database and need to be removed run following command with last good migration Id, e.g. 20191003163242_201910032121.
> Please note this should be removed from all databases where it is applied.

	Update-Database <LastGoodMigration> -Context GamaContext

# Frontend
Run `npm install`

## Development server
Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.
 
## Code scaffolding
Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build
Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests
Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests
Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help
To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
