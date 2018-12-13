import { Injectable } from '@angular/core';
import { RegisterData } from './interfaces/register-data';
import { LoginData } from './interfaces/login-data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserData } from './interfaces/user-data';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _baseUrl = 'http://localhost:50000/';

  private _headers: HttpHeaders;

  private _token: string;

  private _userData: UserData;

  constructor(private _httpClient: HttpClient,
              private _router: Router) {
    this._headers = new HttpHeaders(
      {'Content-Type': 'application/json'},
    );
    this._token = null;
  }

  public register(data: RegisterData) {
    this._httpClient.post(this._baseUrl + 'api/auth/register', data, { headers: this._headers })
      .subscribe(
        response => {
          this._userData = response['userDto'];
          this._router.navigate(['login']);
        },
        error => {

        }
      );
  }

  public login(data: LoginData) {
    this._httpClient.post(this._baseUrl + 'api/auth/login', data, { headers: this._headers })
      .subscribe(
        response => {
          this._token = response['token'];
          this._userData = response['userDto'];
          this._router.navigate(['home']);
        },
        error => {

        }
      );
  }

  public logout() {
    this._token = null;
    this._router.navigate(['login']);
  }

  public isAuthenticated(): boolean {
    return this._token !== null;
  }

  public getToken(): string {
    return this._token;
  }
}
