import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Polyclinic } from '../Polyclinic';

@Component({
  selector: 'app-polyclinic',
  templateUrl: './polyclinic.component.html',
  styleUrls: ['./polyclinic.component.css']
})

export class PolyclinicComponent {
  public polyclinics: Polyclinic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Polyclinic[]>(this.baseApiUrl + '/polyclinic').subscribe(result => {
      this.polyclinics = result;
      console.log(result);
    }, error => console.error(error));
  }
}

