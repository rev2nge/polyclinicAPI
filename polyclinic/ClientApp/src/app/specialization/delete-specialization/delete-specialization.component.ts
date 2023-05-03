import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Specialization } from '../Specialization';

@Component({
  selector: 'app-delete-specialization',
  templateUrl: './delete-specialization.component.html',
  styleUrls: ['./delete-specialization.component.css']
})
export class DeleteSpecializationsComponent implements OnInit {
  public specializations: Specialization[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient) {
    http.get<Specialization[]>(this.baseApiUrl + 'delete-specialization').subscribe(result => {
      this.specializations = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
