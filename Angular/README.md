## Welcome to the Angular tutorial
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



