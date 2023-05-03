import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { Medic } from '../Medic';

@Component({
  selector: 'app-details-medic',
  templateUrl: './details-medic.component.html',
  styleUrls: ['./details-medic.component.css']
})

export class DetailsMedicComponent implements OnInit {
  public medicId!: number;
  public medics: Medic[] = [];
  public baseApiUrl: string = environment.apiUrL

  constructor(http: HttpClient, private route: ActivatedRoute, private router: Router) {
    http.get<Medic[]>(this.baseApiUrl + '/medic').subscribe(result => {
      this.medics = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.medicId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params) => {
        this.medicId = +params['id'];
      }
    )
  }

  onSelectNext() {
    this.medicId += 1;
    this.router.navigate(['details-medic', this.medicId]);
  }
}
