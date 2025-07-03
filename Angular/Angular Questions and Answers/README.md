## Angular Questions and Answers.

**🔰 Beginner Level**

**1. What is Angular?**

Angular is a TypeScript-based open-source front-end web application framework developed by Google for building single-page applications (SPAs). It follows the MVC (Model-View-Controller) architecture and supports modular development.

**2. What are Components in Angular?**

Components are the building blocks of Angular applications. A component controls a part of the UI and consists of:

- A TypeScript class (.ts)
- An HTML template (.html)
- Optional CSS styles (.css)
- A metadata decorator (@Component)

**3. What is a Module in Angular?**

An Angular Module (NgModule) is a container that groups related components, directives, pipes, and services. The root module is typically AppModule.

**4. What is Data Binding?**

Data binding in Angular connects the component logic and the view. Types include:

- Interpolation: {{ value }}
- Property Binding: [property]="value"
- Event Binding: (event)="handler()"
- Two-way Binding: [(ngModel)]="value"

**5. What is Dependency Injection in Angular?**

Dependency Injection (DI) is a design pattern used by Angular to supply components with their dependencies (like services). Angular has a hierarchical injector system for managing DI.

**6. What are Directives?**

Directives are classes that add behavior to elements in Angular templates.

- **Structural Directives:** change the DOM layout (e.g., *ngIf, *ngFor)
- **Attribute Directives:** change the appearance/behavior (e.g., ngClass, ngStyle)

**7. What is Routing in Angular?**

Routing allows navigation between different views/components using URL paths. It’s configured in app-routing.module.ts using RouterModule.

**8. What is the difference between ngIf and ngSwitch?**

- ***ngIf:** Conditionally adds or removes a DOM element.
- **ngSwitch:** Switches between multiple possible elements.

**9. What is the Angular CLI?**

Angular CLI is a command-line interface tool for creating, building, testing, and deploying Angular apps. 

Example:
```
ng new my-app
ng serve
ng generate component user
```

**10. What is the purpose of package.json in Angular?**

It contains metadata about the Angular project and dependencies required to run the app.

#### 🚀 Intermediate Level
**11. Explain Lifecycle Hooks in Angular.**

Angular components have lifecycle hooks such as:

- ngOnInit(): Initialization logic.
- ngOnChanges(): Called when input properties change.
- ngOnDestroy(): Cleanup before component is destroyed.
- ngAfterViewInit(), ngAfterContentInit(): DOM/content projected is initialized.

**12. What is a Service in Angular?**

A service is a class with specific functionality (e.g., data fetching) that can be injected into components using DI.

**13. What is the difference between Observable and Promise?**

- Promise: Emits a single value; not cancellable.
- Observable: Emits multiple values over time; supports operators; cancellable using unsubscribe().

**14. What is Lazy Loading?**

Lazy loading is a technique to load feature modules only when needed, improving performance. Implemented via Angular’s router.

**15. How does Angular handle forms?**

- **Template-driven forms**: Simpler; suitable for small forms.
- **Reactive forms:** More scalable and dynamic; uses FormControl, FormGroup, FormBuilder.

**16. What is a Pipe in Angular?**

Pipes transform data in templates. Example:

```
{{ dateValue | date:'short' }}
```
Custom pipes can be created using @Pipe.

**17. What are Guards in Angular?**

Guards are used to control access to routes:

- CanActivate
- CanDeactivate
- Resolve
- CanLoad

**18. What is ChangeDetectionStrategy?**

Controls how Angular detects changes:

- **Default**: Checks all components.
- **OnPush:** Checks only when @Input properties change or events are triggered.

#### 👨‍💻 Advanced Level

**19. What is Ahead-of-Time (AOT) compilation?**

AOT compiles Angular templates at build time instead of runtime. Improves performance and catches errors early.

**20. What is the difference between ngOnInit and Constructor?**

- **Constructor:** Used for dependency injection and initial class setup.
- **ngOnInit**: Ideal for initializing component logic and fetching data.

**21. How do you handle State Management in Angular?**

Options include:

- Services with BehaviorSubject
- NgRx (Redux pattern)
- Akita
- NGXS

**22. Explain HttpClientModule.**

Used to make HTTP requests. It supports Observables and is configured in AppModule:

```
import { HttpClientModule } from '@angular/common/http';
```

**23. What is a Resolver in Angular?**

A Resolver is used to pre-fetch data before navigating to a route. Implemented using Resolve<T> interface.

**24. What is the role of trackBy in** *ngFor?

Improves performance by tracking items using a unique identifier, preventing unnecessary DOM re-renders.

```
*ngFor="let item of items; trackBy: trackById"
```
**25. How to optimize an Angular application?**

- Lazy loading modules
- OnPush change detection
- AOT compilation
- Minification and tree-shaking
- Using trackBy in *ngFor
- Avoid unnecessary subscriptions
