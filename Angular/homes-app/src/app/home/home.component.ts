import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HousingLocationComponent } from '../housing-location/housing-location.component';
import { HousingLocation } from '../housinglocation';
import { HousingService } from '../housing.service';

@Component({
  selector: 'app-home',
  imports: [CommonModule, HousingLocationComponent],
  template: `
    <section>
      <form>
        <input type="text" placeholder="Filter by city" #filter />
        <button class="primary" type="button" (click)="filterResults(filter.value)">Search</button>
      </form>
    </section>
    <section class="results">
      <app-housing-location *ngFor="let housingLocation of filteredLocationList" 
      [housingLocation]="housingLocation">
      </app-housing-location>
    </section>
  `,
  styleUrls: ['./home.component.css'],
  standalone: true,
})
export class HomeComponent {
  housingLocationList: HousingLocation[] = [];
  filteredLocationList: HousingLocation[] = [];
  
  constructor(housingService: HousingService) {
    this.housingLocationList = housingService.getAllHousingLocations();
    this.filteredLocationList = this.housingLocationList;
  }
  filterResults(text: string) {
    if (!text) {
      this.filteredLocationList = this.housingLocationList;
      return;
    }
    this.filteredLocationList = this.housingLocationList.filter((location) =>
      location.city.toLowerCase().includes(text.toLowerCase())
    );
  }
}
