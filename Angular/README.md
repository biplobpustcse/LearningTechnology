## Welcome to the Angular tutorial
You'll need to have basic familiarity with HTML, CSS and JavaScript to understand Angular.

#### Components in Angular
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
#### Composing Components
You've learned to update the component template, component logic, and component styles, but how do you use a component in your application?

The selector property of the component configuration gives you a name to use when referencing the component in another template. You use the selector like an HTML tag, for example app-user would be <app-user /> in the template.
```
template: `<app-user />`,
imports: [UserComponent]
```
#### Control Flow in Components - @if and @else
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
