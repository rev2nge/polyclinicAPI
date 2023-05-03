import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Medic } from '../Medic';

@Component({
  selector: 'app-medic',
  templateUrl: './medic.component.html',
  styleUrls: ['./medic.component.css']
})

export class MedicComponent {
  public medics: Medic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Medic[]>(this.baseApiUrl + '/medic').subscribe(result => {
      this.medics = result;
    }, error => console.error(error));
  }
}
