import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RegisterData } from '../Interfaces/register-data';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor() { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'fullname': new FormControl(null, Validators.required),
      'password': new FormControl(null, Validators.required),
      'confirmPassword': new FormControl(null, Validators.required)
    }, this.confirmPasswordValidator);
  }

  confirmPasswordValidator(group: FormGroup) {
    if (group.controls['password'].value !== group.controls['confirmPassword'].value) {
      return  {'passwordsAreNotEqual' : true };
    }
    return null;
  }

  register() {
    console.log(this.registerForm);

    const registerData: RegisterData = {
      email: this.registerForm.controls['email'].value,
      fullname: this.registerForm.controls['fullname'].value,
      password: this.registerForm.controls['password'].value
    };
  }

}
