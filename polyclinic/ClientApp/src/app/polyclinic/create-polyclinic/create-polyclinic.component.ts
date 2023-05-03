import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-polyclinic',
  templateUrl: './create-polyclinic.component.html',
  styleUrls: ['./create-polyclinic.component.css']
})
export class CreatePolyclinicComponent implements OnInit {
  @ViewChild('Form') createPolyclinicForm!: NgForm;
  constructor(private router: Router,
              private fb: FormBuilder) { }


  ngOnInit() {
    setTimeout(() => {
      this.createPolyclinicForm.controls['userName'].setValue('Default Value')
    }, 1000);
  }

  onBack()
  {
    this.router.navigate(['/polyclinic'])
  }

  onSubmit(Form: NgForm) {
    console.log('Congrats');
    console.log(this.createPolyclinicForm);
  }

}

