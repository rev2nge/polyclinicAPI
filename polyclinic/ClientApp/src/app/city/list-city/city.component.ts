import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { City } from 'src/app/city/City'

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})

export class CityComponent {
  public cities: City[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<City[]>(this.baseApiUrl + '/city').subscribe(result => {
      this.cities = result;
    }, error => console.error(error));
  }
}
