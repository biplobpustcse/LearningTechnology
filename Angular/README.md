## Welcome to the Angular tutorial- [Reference Link](https://angular.dev/tutorials/learn-angular)
You'll need to have basic familiarity with HTML, CSS and JavaScript to understand Angular.

#### 1. Components in Angular
Components are the foundational building blocks for any Angular application. Each component has three parts:

- TypeScript class
- HTML template
- CSS styles
```
import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    Hello Angular
  `,
  styles: `
    :host {
      color: blue;
    }
  `,
})
export class AppComponent {}
```
#### 2. Composing Components
You've learned to update the component template, component logic, and component styles, but how do you use a component in your application?

The selector property of the component configuration gives you a name to use when referencing the component in another template. You use the selector like an HTML tag, for example app-user would be <app-user /> in the template.
```
template: `<app-user />`,
imports: [UserComponent]
```
#### 3.1 Control Flow in Components - @if and @else
To express conditional displays in templates, Angular uses the @if template syntax.
```
import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  @if(isServerRunning){
    <span>Yes, the server is running</span>
  }
  @else{
  <span>Yes, the server is not running</span>
  }
  `,
})
export class AppComponent {
  isServerRunning: boolean = true;
}
```
#### 3.2 Control Flow in Components - @for
The syntax that enables repeating elements in a template is @for.
```
import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  @for(user of users; track user.id)
  {
    <p>{{user.name}}</p>
  }
  `,
})
export class AppComponent {
  users:any =[{id: 0, name: 'Sarah'}, {id: 1, name: 'Amy'}, {id: 2, name: 'Rachel'}, {id: 3, name: 'Jessica'}, {id: 4, name: 'Poornima'}];
}
```
> [!NOTE]
> The use of track is required; you may use the id or some other unique identifier.

#### 4. Property Binding in Angular
Property binding in Angular enables you to set values for properties of HTML elements, Angular components and more.
- Add a property called **isEditable** 
```
export class AppComponent {
    isEditable = true;
}
```
- Bind to **contentEditable**
Next, bind the contentEditable attribute of the div to the isEditable property by using the [] syntax.
```
@Component({
    ...
    template: `<div [contentEditable]="isEditable"></div>`,
})
```
**Full Code**
```
import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  styleUrls: ['app.component.css'],
  template: `
    <div [contentEditable]="isEditable"></div>
  `,
})
export class AppComponent {
  isEditable:boolean = true;
}
```
#### 5. Event handling
Event handling enables interactive features on web apps. It gives you the ability as a developer to respond to user actions like button presses, form submissions and more.

**In Angular you bind to events with the parentheses syntax ()**
```
@Component({
    ...
    template: `<button (click)="greet()">`
})
class AppComponent {
    greet() {
        console.log('Hello, there 👋');
    }
}
```

#### 6. Component Communication with @Input
Sometimes app development requires you to send data into a component. This data can be used to customize a component or perhaps **send information from a parent component to a child component.**
**interpolation syntax {{}}**
user.components.ts
```
@Component({
  ...
  template: `<p>The user's occupation is {{occupation}}</p>`
})

class UserComponent {
  @Input() occupation = '';
}
```
app.components.ts
```
@Component({
  ...
  template: `<app-user occupation="Angular Developer"></app-user>`
})
class AppComponent {}
```
#### 7. Component Communication with @Output
When working with components, it may be required to notify other components that something has happened. Perhaps a button has been clicked, an item has been added/removed from a list, or some other important update has occurred. In this scenario, components need **to communicate with parent components.**

Angular uses the @Output decorator to enable this type of behavior.

child.components.ts
```
import {Component, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-child',
  styles: `.btn { padding: 5px; }`,
  template: `
    <button class="btn" (click)="addItem()">Add Item</button>
  `,
})

export class ChildComponent {
    @Output() addItemEvent = new EventEmitter<number>();

    addItem() {
      this.addItemEvent.emit('🐢');
    }
}
```
app.components.ts
```
import {Component} from '@angular/core';
import {ChildComponent} from './child.component';

@Component({
  selector: 'app-root',
  template: `
    <app-child (addItemEvent)="addItem($event)" />
    <p>🐢 all the way down {{ items.length }}</p>
  `,
  imports: [ChildComponent],
})
export class AppComponent {
  items = new Array();

  addItem(item: string) {
    this.items.push(item);
  }
}
```
#### 8. Deferrable Views
Sometimes in app development, you end up with a lot of components that you need to reference in your app, but some of those don't need to be loaded right away for various reasons.

Maybe they are below the visible fold or are heavy components that aren't interacted with until later. In that case, we can load some of those resources later with deferrable views.

Add a @loading block to the @defer block. The @loading block is where you put html that will show while the deferred content is actively being fetched, but hasn't finished yet. The content in @loading blocks is eagerly loaded.
```
@defer {
  <comments />
} @placeholder {
  <p>Future comments</p>
} @loading {
  <p>Loading comments...</p>
}
```
#### 9. Optimizing images
Images are a big part of many applications, and can be a major contributor to application performance problems, including low Core Web Vitals scores.

**Image optimization can be a complex topic**, but Angular handles most of it for you, **with the NgOptimizedImage directive.**

**NgOptimizedImage to ensure your images are loaded efficiently.**
Import the NgOptimizedImage directive
```
import { NgOptimizedImage } from '@angular/common';
@Component({
  imports: [NgOptimizedImage],
  ...
})
```
**Update the src attribute to be ngSrc**

To enable the NgOptimizedImage directive, swap out the src attribute for ngSrc. This applies for both static image sources (i.e., src) and dynamic image sources (i.e., [src]).
```
import { NgOptimizedImage } from '@angular/common';
@Component({
template: `     ...
    <li>
      Static Image:
      <img ngSrc="/assets/logo.svg" alt="Angular logo" width="32" height="32" />
    </li>
    <li>
      Dynamic Image:
      <img [ngSrc]="logoUrl" [alt]="logoAlt" width="32" height="32" />
    </li>
    ...
  `,
imports: [NgOptimizedImage],
})
```
**Add width and height attributes**
Note that in the above code example, each image has both width and height attributes. In order to prevent layout shift, the NgOptimizedImage directive requires both size attributes on each image.

In situations where you can't or don't want to specify a static height and width for images, you can use the fill attribute to tell the image to act like a "background image", filling its containing element:
```
<div class="image-container"> //Container div has 'position: "relative"'
  <img ngSrc="www.example.com/image.png" fill />
</div>
```
Prioritize important images
One of the most important optimizations for loading performance is to prioritize any image which might be the "LCP element", which is the largest on-screen graphical element when the page loads. To optimize your loading times, make sure to add the priority attribute to your "hero image" or any other images that you think could be an LCP element.
```
<img ngSrc="www.example.com/image.png" height="600" width="800" priority />
```
Optional: Use an image loader
NgOptimizedImage allows you to specify an image loader, which tells the directive how to format URLs for your images. Using a loader allows you to define your images with short, relative URLs:
```
providers: [
  provideImgixLoader('https://my.base.url/'),
]
```
Final URL will be 'https://my.base.url/image.png'
```
<img ngSrc="image.png" height="600" width="800" />
```
Image loaders are for more than just convenience--they allow you to use the full capabilities of NgOptimizedImage.

#### 10. Routing Overview
For most apps, there comes a point where the app requires more than a single page. When that time inevitably comes, routing becomes a big part of the performance story for users.

As users perform application tasks, they need to move between the different views that you have defined.

To handle the navigation from one view to the next, you use the Angular **Router**. The **Router** enables navigation by interpreting a browser URL as an instruction to change the view.

**Create an app.routes.ts file**
Inside **app.routes.ts**, make the following changes:

1. Import Routes from the @angular/router package.
2. Export a constant called routes of type Routes, assign it [] as the value.
```
import {Routes} from '@angular/router';
export const routes: Routes = [];
```
**Add routing to provider**
In **app.config.ts**, configure the app to Angular Router with the following steps:

1. Import the provideRouter function from @angular/router.
2. Import routes from the ./app.routes.ts.
3. Call the provideRouter function with routes passed in as an argument in the providers array.
```
import {ApplicationConfig} from '@angular/core';
import {provideRouter} from '@angular/router';
import {routes} from './app.routes';
export const appConfig: ApplicationConfig = {
providers: [provideRouter(routes)],
};
```
**Import RouterOutlet in the component**
Finally, to make sure your app is ready to use the Angular Router, you need to tell the app where you expect the router to display the desired content. Accomplish that by using the RouterOutlet directive from @angular/router.

Update the template for AppComponent by adding <router-outlet />
```
import {RouterOutlet} from '@angular/router';
@Component({
...
template: `     <nav>
      <a href="/">Home</a>
      |
      <a href="/user">User</a>
    </nav>
    <router-outlet />
  `,
imports: [RouterOutlet],
})
export class AppComponent {}
```
![Route Menu](https://github.com/user-attachments/assets/86db05e0-36d1-4be4-a0ee-1dcba0143289)

Your app is now set up to use Angular Router. Nice work! 🙌
#### 11. Define a Route
Define a route in **app.routes.ts**

**path, title, component**
```
import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
export const routes: Routes = [
{
path: '',
title: 'App Home Page',
component: HomeComponent,
},
];
```
#### 12. Use RouterLink for Navigation
**In the app's current state, the entire page refreshes when we click on an internal link that exists within the app.** While this may not seem significant with a small app, this can have performance implications for larger pages with more content where users have to redownload assets and run calculations again.

We'll learn how to leverage the RouterLink directive to make the most use of Angular Router.
**Import RouterLink directive**
In **app.component.ts** add the RouterLink directive import to the existing import statement from @angular/router and add it to the imports array of your component decorator.
```
...
import { RouterLink, RouterOutlet } from '@angular/router';
@Component({
  imports: [RouterLink, RouterOutlet],
  ...
})
```
**Add a routerLink to template**
To use the RouterLink directive, replace the href attributes with routerLink. Update the template with this change.
```
import { RouterLink, RouterOutlet } from '@angular/router';
@Component({
  ...
  template: `
    ...
    <a routerLink="/">Home</a>
    <a routerLink="/user">User</a>
    ...
  `,
  imports: [RouterLink, RouterOutlet],
})
```
When you click on the links in the navigation now, you should not see any blinking and only the content of the page itself (i.e., router-outlet) being changed 🎉
#### 13. Forms Overview [More](https://angular.dev/tutorials/learn-angular/15-forms)
Forms are a big part of many apps because they enable your app to accept user input. Let's learn about how forms are handled in Angular.

- Create an input field
- Import FormsModule
- Add binding to the value of the input
The FormsModule has a directive called ngModel that binds the value of the input to a property in your class.
```
<label for="framework">
  Favorite Framework:
  <input id="framework" type="text" [(ngModel)]="favoriteFramework" />
</label>
```
> [!NOTE]
> The syntax [()] is known as "banana in a box" but it represents two-way binding: property binding and event binding. Learn more in the Angular docs about two-way data binding.
#### 14. Reactive Forms
When you want to manage your forms programmatically instead of relying purely on the template, reactive forms are the answer.
You'll learn how to set up reactive forms.
**Import ReactiveForms module**
In app.component.ts, import ReactiveFormsModule from @angular/forms and add it to the imports array of the component.
```
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  template: `
    <form>
      <label>Name
        <input type="text" />
      </label>
      <label>Email
        <input type="email" />
      </label>
      <button type="submit">Submit</button>
    </form>
  `,
  imports: [ReactiveFormsModule],
})
```
**Create the FormGroup object with FormControls**
Add FormControl and FormGroup to the import from @angular/forms so that you can create a FormGroup for each form, with the properties name and email as FormControls.
```
import {ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
...
export class AppComponent {
  profileForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
  });
}
```
**Link the FormGroup and FormControls to the form** [More](https://angular.dev/tutorials/learn-angular/17-reactive-forms)

Each FormGroup should be attached to a form using the [formGroup] directive.

In addition, each FormControl can be attached with the formControlName directive and assigned to the corresponding property. Update the template with the following form code:
```
<form [formGroup]="profileForm">
  <label>
    Name
    <input type="text" formControlName="name" />
  </label>
  <label>
    Email
    <input type="email" formControlName="email" />
  </label>
  <button type="submit">Submit</button>
</form>
```
**ReactiveFormsModule**
Another common scenario when working with forms is the need to validate the inputs to ensure the correct data is submitted.

Import Validators
```
import {ReactiveFormsModule, Validators} from '@angular/forms';
@Component({...})
export class AppComponent {}
```
**Add validation to form**

Every FormControl can be passed the Validators you want to use for validating the FormControl values. For example, if you want to make the name field in profileForm required then use Validators.required. For the email field in our Angular form, we want to ensure it's not left empty and follows a valid email address structure. We can achieve this by combining the Validators.required and Validators.email validators in an array. Update the name and email FormControl:
```
profileForm = new FormGroup({
  name: new FormControl('', Validators.required),
  email: new FormControl('', [Validators.required, Validators.email]),
});
```
#### 15. Creating an injectable service
Dependency injection (DI) in Angular is one of the framework's most powerful features. Consider dependency injection to be the ability for Angular to provide resources you need for your application at runtime. A dependency could be a service or some other resources.
```
import {Injectable} from '@angular/core';

export class CarService {
  cars = ['Sunflower GT', 'Flexus Sport', 'Sprout Mach One'];

  getCars(): string[] {
    return this.cars;
  }

  getCar(id: number) {
    return this.cars[id];
  }
}
```

#### 16. Inject-based dependency injection
Creating an injectable service is the first part of the dependency injection (DI) system in Angular. How do you inject a service into a component? Angular has a convenient function called inject() that can be used in the proper context.
```
import {Component, inject} from '@angular/core';
import {CarService} from './car.service';

@Component({
  selector: 'app-root',
  template: `<p>Car Listing: {{ display }}</p>`,
})
export class AppComponent {
  carService = inject(CarService);
  display = '';

  constructor() {
    this.display = this.carService.getCars().join(' ⭐️ ');
  }
}
```
#### 17. Constructor-based dependency injection
In previous activities you used the inject() function to make resources available, "providing" them to your components. The inject() function is one pattern and it is useful to know that there is another pattern for injecting resources called **constructor-based dependency injection.**
```
import {Component, inject} from '@angular/core';
import {CarService} from './car.service';

@Component({
  selector: 'app-root',
  template: `
    <p>Car Listing: {{ display }}</p>
  `,
})
export class AppComponent {
  display = '';

  constructor(private carService: CarService) {
    this.display = this.carService.getCars().join(' ⭐️ ');
  }
}
```
#### 18. Pipes
Pipes are functions that are used to transform data in templates. In general, pipes are "pure" functions that don't cause side effects. Angular has a number of helpful built-in pipes you can import and use in your components. You can also create a custom pipe.

To use a pipe in a template, include it in an interpolated expression. Check out this example:**UpperCasePipe,LowerCasePipe**
```
import {UpperCasePipe} from '@angular/common';
@Component({
...
import {Component} from '@angular/core';
import {UpperCasePipe} from '@angular/common';
import { LowerCasePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  template: `
  {{ username | uppercase}}<br>
  {{ username | lowercase}}
  `,
  imports: [UpperCasePipe, LowerCasePipe],
})
export class AppComponent {
  username = 'yOunGTECh';
}
```
#### 19. Formatting data with pipes
You can take your use of pipes even further by configuring them. Pipes can be configured by passing options to them.

**DecimalPipe, DatePipe, CurrencyPipe**
```
import {Component} from '@angular/core';
import {DecimalPipe, DatePipe, CurrencyPipe} from '@angular/common';

@Component({
  selector: 'app-root',
  template: `
    <ul>
      <li>Number with "decimal" {{ num | number:"3.1-2"}}</li>
      <li>Date with "date" {{ birthday | date}}</li>
       <li>Date with "date" {{ birthday | date:"fullDate"}}</li>
      <li>Currency with "currency" {{ cost | currency}}</li>
    </ul>
  `,
  imports: [DecimalPipe, DatePipe, CurrencyPipe],
})
export class AppComponent {
  num = 103.1234;
  birthday = new Date(2023, 3, 2);
  cost = 4560.34;
}
```
#### 20. Create a custom pipe
You can create custom pipes in Angular to fit your data transformation needs.

**Create the ReversePipe**
- In reverse.pipe.ts add the @Pipe decorator to the ReversePipe class and provide the following configuration:
- Implement the transform function
```
import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'reverse'
})
  
export class ReversePipe implements PipeTransform {
    transform(value: string): string {
        let reverse = '';
        for (let i = value.length - 1; i >= 0; i--) {
            reverse += value[i];
        }
        return reverse;
    }
}
```
**Use the ReversePipe in the template**
```
import {Component} from '@angular/core';
import {ReversePipe} from './reverse.pipe';

@Component({
  selector: 'app-root',
  template: `
    Reverse Machine: {{ word | reverse}}
  `,
  imports: [ReversePipe],
})
export class AppComponent {
  word = 'You are a champion';
}
```
#### 21. HTTP client 
Most front-end applications need to communicate with a server over the HTTP protocol, to download or upload data and access other back-end services. Angular provides a client HTTP API for Angular applications, the HttpClient service class in @angular/common/http.

Setting up HttpClient

**Providing HttpClient through dependency injection**
HttpClient is provided using the provideHttpClient helper function, which most apps include in the application providers in app.config.ts.
```
export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
  ]
};
```
## First Angular App - [Link](https://angular.dev/tutorials/first-app/01-hello-world)
In the Terminal pane of your IDE:

1. In your project directory, navigate to the first-app directory.

2. Run this command to install the dependencies needed to run the app.
```
npm install
```
3. Run this command to build and serve the default app.
```
ng serve
```
4. In a web browser on your development computer, open http://localhost:4200.

5. Confirm that the default web site appears in the browser.

6. You can leave ng serve running as you complete the next steps.



