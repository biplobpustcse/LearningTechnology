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
<app-child (addItemEvent)="addItem($event)" />
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

Image optimization can be a complex topic, but Angular handles most of it for you, **with the NgOptimizedImage directive.**

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

