import { Component, Input } from '@angular/core';
import { HousingLocation } from '../housinglocation';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-housing-location',
  imports: [RouterModule],
  template: `
    <section class="listing">
    <a [routerLink]="['/details', housingLocation.id]">
      <img
        class="listing-photo"
        [src]="housingLocation.photo"
        alt="Exterior photo of {{ housingLocation.name }}"
        crossorigin
      />
      <h2 class="listing-heading">{{ housingLocation.name }}</h2>
      <p class="listing-location">{{ housingLocation.city }}, {{ housingLocation.state }}</p>
      </a>
    </section>
  `,
  styleUrls: ['./housing-location.component.css'],
  standalone: true,
})
export class HousingLocationComponent {
  @Input() housingLocation!: HousingLocation;
}
