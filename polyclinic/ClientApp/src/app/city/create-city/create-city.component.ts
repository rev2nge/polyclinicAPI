import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../../services/city.service';
import { City } from '../City';

@Component({
  selector: 'app-create-city',
  templateUrl: './create-city.component.html',
  styleUrls: ['./create-city.component.css']
})
export class CreateCityComponent implements OnInit {

  CreateCityRequest: City = {
    id: null,
    name: ''
  }

  @ViewChild('Form') createCityForm!: NgForm;
  constructor(private cityService: CityService,
              private router: Router,
              private fb: FormBuilder) { }

  ngOnInit() {
    //setTimeout(() => {
    //  this.createCityForm.controls['userName'].setValue('Default Value')
    //}, 1000);
  }

  CreateCity() {
    this.cityService.createCity(this.CreateCityRequest)
  }

  onBack()
  {
    this.router.navigate(['/city'])
  }

  onSubmit(Form: NgForm) {
    console.log('Congrats');
    console.log(this.createCityForm);
  }

}

