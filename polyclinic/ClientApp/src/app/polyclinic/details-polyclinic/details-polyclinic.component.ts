import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { Polyclinic } from '../Polyclinic';

@Component({
  selector: 'app-details-polyclinic',
  templateUrl: './details-polyclinic.component.html',
  styleUrls: ['./details-polyclinic.component.css']
})

export class DetailsPolyclinicComponent implements OnInit {
  public polyclinicId!: number;
  public polyclinics: Polyclinic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient, private route: ActivatedRoute, private router: Router) {
    http.get<Polyclinic[]>(this.baseApiUrl + '/polyclinic').subscribe(result => {
      this.polyclinics = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.polyclinicId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params) => {
        this.polyclinicId = +params['id'];
      }
    )
  }

  onSelectNext() {
    this.polyclinicId += 1;
    this.router.navigate(['details-polyclinic', this.polyclinicId]);
  }
}
