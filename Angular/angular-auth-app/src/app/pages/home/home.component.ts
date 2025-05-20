import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { HousingService } from '../../services/housing.service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  housingLocationList: any[] = [];
  filteredLocationList: any[] = [];
  constructor(private auth: AuthService,private housingService: HousingService) {
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

  logout() {
    this.auth.logout();
  }
}
