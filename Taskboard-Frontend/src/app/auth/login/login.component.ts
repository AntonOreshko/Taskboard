import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { LoginData } from '../interfaces/login-data';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      email : new FormControl('oreshko2010@gmail.com', [Validators.required, Validators.email]),
      password: new FormControl('eR8dHySL', [Validators.required]),
    });
  }

  login() {
    if (this.loginForm.valid) {
      this.authService.login(this.getLoginData());
    }
  }

  getLoginData(): LoginData {
    return {
      email: this.loginForm.controls['email'].value,
      password: this.loginForm.controls['password'].value,
    };
  }
}
