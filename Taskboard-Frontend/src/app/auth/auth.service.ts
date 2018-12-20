import { Injectable } from '@angular/core';
import { RegisterData } from './interfaces/register-data';
import { LoginData } from './interfaces/login-data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './interfaces/user';
import { HttpService } from '../core/http.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends HttpService {

  private _token: string;

  private _userData: User;

  constructor(private _httpClient: HttpClient) {
    super();
    this._token = null;
  }

  public register(data: RegisterData): Observable<any> {
    return this._httpClient.post(this._baseUrl + 'api/auth/register', data, { headers: this.getHeaders() })
      .pipe(
        map(
          (response: any) => {
            this._userData = response['userDto'];
          }
        )
      );
  }

  public login(data: LoginData) {
    return this._httpClient.post(this._baseUrl + 'api/auth/login', data, { headers: this.getHeaders() })
      .pipe(
        map(
          (response: any) => {
            this._token = response['token'];
            this._userData = response['userDto'];
            localStorage.setItem('token', this._token);
          }
        )
      );
  }

  public logout() {
    this._token = null;
    localStorage.removeItem('token');
  }

  public isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  public getToken(): string {
    if (this._token === null) {
      this._token = localStorage.getItem('token');
    }
    return this._token;
  }
}
