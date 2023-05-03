import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Specialization } from '../Specialization';

@Component({
  selector: 'app-specialization',
  templateUrl: './specialization.component.html',
  styleUrls: ['./specialization.component.css']
})

export class SpecializationComponent {
  public specializations: Specialization[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Specialization[]>(this.baseApiUrl + '/specialization').subscribe(result => {
      this.specializations = result;
    }, error => console.error(error));
  }
}
