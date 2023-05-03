import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-specialization',
  templateUrl: './create-specialization.component.html',
  styleUrls: ['./create-specialization.component.css']
})
export class CreateSpecializationComponent implements OnInit {
  @ViewChild('Form') createSpecializationForm!: NgForm;
  constructor(private router: Router) { }

  ngOnInit() {
    setTimeout(() => {
      this.createSpecializationForm.controls['userName'].setValue('Default Value')
    }, 1000);
  }

  onBack() {
    this.router.navigate(['/specialization'])
  }

  onSubmit(Form: NgForm) {
    console.log('Congrats');
    console.log(this.createSpecializationForm);
  }
}





