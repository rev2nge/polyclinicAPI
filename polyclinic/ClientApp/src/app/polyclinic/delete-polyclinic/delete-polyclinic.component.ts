import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Polyclinic } from '../Polyclinic';

@Component({
  selector: 'app-delete-polyclinic',
  templateUrl: './delete-polyclinic.component.html',
  styleUrls: ['./delete-polyclinic.component.css']
})
export class DeletePolyclinicComponent implements OnInit {
  public polyclinics: Polyclinic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Polyclinic[]>(this.baseApiUrl + 'delete-polyclinic.').subscribe(result => {
      this.polyclinics = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
