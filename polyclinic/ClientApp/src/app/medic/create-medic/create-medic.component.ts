import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-medic',
  templateUrl: './create-medic.component.html',
  styleUrls: ['./create-medic.component.css']
})
export class CreateMedicComponent implements OnInit {
  @ViewChild('Form') createMedicForm!: NgForm;
  constructor(private router: Router) { }

  ngOnInit() {
    setTimeout(() => {
      this.createMedicForm.controls['userName'].setValue('Default Value')
    }, 1000);
  }


  onBack()
  {
    this.router.navigate(['/medic'])
  }

  onSubmit(Form: NgForm) {
    console.log('Congrats');
    console.log(this.createMedicForm);
  }
}

