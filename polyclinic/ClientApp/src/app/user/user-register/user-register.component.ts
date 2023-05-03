import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserForRegister } from 'src/app/model/user';
import { AlertifyService } from '../../services/alertify.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})

export class UserRegisterComponent implements OnInit {

  registerationForm!: FormGroup;
  user!: UserForRegister;
  userSubmitted!: boolean;
  constructor(private fb: FormBuilder,
              private authService: AuthService,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createRegisterationForm();
  }

  createRegisterationForm() {
    this.registerationForm = this.fb.group({
      userName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, Validators.required],
      mobile: [null, [Validators.required, Validators.maxLength(10)]]
    }, { validators: this.passwordMatchingValidatior });
  }

  passwordMatchingValidatior(fg: FormGroup): Validators {
    return fg.get('password')?.value === fg.get('confirmPassword')?.value 
  }

  //onSubmit() {
  //  console.log(this.registerationForm.value);
  //  this.userSubmitted = true;

  //  if (this.registerationForm.valid) {
  //    // this.user = Object.assign(this.user, this.registerationForm.value);
  //    this.authService.registerUser(this.userData()).subscribe(() => {
  //      this.onReset();
  //      this.alertify.success('Congrats, you are successfully registered');
  //    });
  //  }
  //}

  onSubmit() {
    console.log(this.registerationForm.value);
    this.userSubmitted = true;

    if (this.registerationForm.valid) {
      // this.user = Object.assign(this.user, this.registerationForm.value);
      this.authService.registerUser(this.userData()).subscribe(() => {
        this.onReset();
        this.alertify.success('Congrats, you are successfully registered');
      });
    }
  }

  onReset() {
    this.userSubmitted = false;
    this.registerationForm.reset();
  }

  userData(): UserForRegister {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value
    };
  }
 
  get userName() {
    return this.registerationForm.get('userName') as FormControl;
  }
  get email() {
    return this.registerationForm.get('email') as FormControl;
  }
  get password() {
    return this.registerationForm.get('password') as FormControl;
  }
  get confirmPassword() {
    return this.registerationForm.get('confirmPassword') as FormControl;
  }
  get mobile() {
    return this.registerationForm.get('mobile') as FormControl;
  }

}
