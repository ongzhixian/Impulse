# AngularSpa

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.7.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

Generate SomeComponent in a folder:

`ng generate component plainsight/SomeComponent --module=demo-app `

Generate SomeComponent in a folder without putting files in a folder of its own:

`ng generate component plainsight/FlatComponent --module=demo-app --flat`

See the difference below:

```
D:\Project\CLIENTAPP\SRC\APP\PLAINSIGHT
│   flat-component.component.css
│   flat-component.component.html
│   flat-component.component.spec.ts
│   flat-component.component.ts
│
└───some-component
        some-component.component.css
        some-component.component.html
        some-component.component.spec.ts
        some-component.component.ts
```

## Sub-application scaffolding

ZX: My current recommendation for defining sub-application in one Angular application.
    Definition: An Angular application is typically scaffold using `ng generate application`
    Sub-applications should be defined in `.angular-cli.json` file.

tldr;

Assuming creating an application call Demo.

```
copy app.module.ts demo-app.module.ts
copy index.html demo-index.html
copy main.tx demo-main.ts

Create a new app under apps section in `.angular-cli.json`
- Add/Change name
- Change outDir
- Change index
- Change main
- Change prefix
- Any other definitions as needed

ng generate component demo/App --module=demo-app --app=demo

ng generate component demo/pages/Home --module=demo-app --app=demo
ng generate component demo/pages/News --module=demo-app --app=demo
ng generate component demo/pages/Contact --module=demo-app --app=demo
ng generate component demo/pages/About --module=demo-app --app=demo

ng generate component demo/ui_components/NavMenu --module=demo-app --app=demo

```

ZX: Critique -- The scaffolding is probably meant to get something quick-and-dirty up and running.
                Defining sub-applications is probably left as an exercise for advanced developers.

1.  Copy required application bootstrap files:
    
    ```
    copy app.module.ts demo-app.module.ts
    copy index.html demo-index.html
    copy main.tx demo-main.ts
    ```
    
    Create a application module `<app_name>-app.module.ts` (copy/clone from elsewhere)

2.  Create a new app under apps section in `.angular-cli.json`

- Add/Change name
- Change outDir
- Change index
- Change main
- Change prefix
- Any other definitions as needed

3.  Create a application component

`ng generate component demo/App --module=demo-app --app=demo`

4.  Create pages under `demo/pages` folder

```
ng generate component demo/pages/Home --module=demo-app --app=demo
ng generate component demo/pages/News --module=demo-app --app=demo
ng generate component demo/pages/Contact --module=demo-app --app=demo
ng generate component demo/pages/About --module=demo-app --app=demo


ng generate component demo/pages/Login --module=demo-app --app=demo
ng generate component demo/pages/Privacy --module=demo-app --app=demo

ng generate service demo/services/AuthenticationService --module=demo-app --app=demo
ng generate service demo/guards/AuthenticationGuard --module=demo-app --app=demo

```

5.  Create any UI components under `demo/ui_components` folder

```
ng generate component demo/ui_components/NavMenu --module=demo-app --app=demo
```

```
D:\Project\CLIENTAPP\SRC
+---app (ZX: Yes, I know. This is misleading)
|   +---demo
|   |   +---app
|   |   +---pages
|   |   |   +---about
|   |   |   +---contact
|   |   |   +---home
|   |   |   \---news
|   |   \---ui-components
|   |       \---nav-menu

ZX: The first app  is kind of misleading.
    This is probably better read as Angular application; applications below sub-applications.
    But we do not want to write sub-applications everywhere.
    Remember! Scaffolding is intend for a certain common(?) workflow.
    I do not think sub-applications is part of that defined common workflow.
```


## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
