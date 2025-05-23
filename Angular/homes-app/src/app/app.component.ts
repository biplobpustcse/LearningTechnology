import {Component} from '@angular/core';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterModule,HomeComponent],
  template: `
    <main>
    <a [routerLink]="['/']">
      <header class="brand-name">
        <img classs="brand-logo" src="assets/logo.svg" alt="Logo" aria-hidden="true" />
      </header>
    </a>
    <section class="content">
      <router-outlet></router-outlet>
    </section>
    </main>
  `,
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'homes';
}
