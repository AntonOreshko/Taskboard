import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { RegisterData } from '../interfaces/register-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private _authService: AuthService,
              private _router: Router) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email : new FormControl('oreshko2010@gmail.com', [Validators.required, Validators.email]),
      fullname: new FormControl('Anton Oreshko', [Validators.required]),
      password: new FormControl('password', [Validators.required]),
      confirmPassword: new FormControl('password', [Validators.required])
    }, [this.confirmPasswordValidator]);
  }

  confirmPasswordValidator(group: FormGroup) {
    if (group.controls['password'].value !== group.controls['confirmPassword'].value) {
      return  {'passwordsAreNotEqual' : true };
    }
    return null;
  }

  register() {
    if (this.registerForm.valid) {
      this._authService.register(this.getRegisterData())
        .subscribe(
          response => {
            this._router.navigate(['login']);
          },
          error => {

          }
        );
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
