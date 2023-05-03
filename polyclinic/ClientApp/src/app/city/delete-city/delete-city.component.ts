import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { City } from 'src/app/city/City'

@Component({
  selector: 'app-delete-city',
  templateUrl: './delete-city.component.html',
  styleUrls: ['./delete-city.component.css']
})
export class DeleteCityComponent implements OnInit {
  public cities: City[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<City[]>(this.baseApiUrl + 'delete-city').subscribe(result => {
      this.cities = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
