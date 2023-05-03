import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Medic } from 'src/app/medic/Medic'

@Component({
  selector: 'app-delete-medic',
  templateUrl: './delete-medic.component.html',
  styleUrls: ['./delete-medic.component.css']
})
export class DeleteMedicComponent implements OnInit {
  public medics: Medic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Medic[]>(this.baseApiUrl + 'delete-medic.').subscribe(result => {
      this.medics = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
