import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { RegisterData } from '../interfaces/register-data';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email : new FormControl('oreshko2010@gmail.com', [Validators.required, Validators.email]),
      fullname: new FormControl('Anton Oreshko', [Validators.required]),
      password: new FormControl('eR8dHySL', [Validators.required]),
      confirmPassword: new FormControl('eR8dHySL', [Validators.required])
    });
  }

  confirmPasswordValidator(group: FormGroup) {
    if (group.controls['password'].value !== group.controls['confirmPassword'].value) {
      return  {'passwordsAreNotEqual' : true };
    }
    return null;
  }

  register() {
    if (this.registerForm.valid) {
      this.authService.register(this.getRegisterData());
    }
  }

  getRegisterData(): RegisterData {
    return {
      email: this.registerForm.controls['email'].value,
      fullname: this.registerForm.controls['fullname'].value,
      password: this.registerForm.controls['password'].value,
    };
  }
}
