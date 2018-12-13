import { Injectable } from '@angular/core';
import { RegisterData } from './interfaces/register-data';
import { LoginData } from './interfaces/login-data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserData } from './interfaces/user-data';
import { HttpService } from '../core/http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends HttpService {

  private _token: string;

  private _userData: UserData;

  constructor(private _httpClient: HttpClient) {
    super();
    this._token = null;
  }

  public register(data: RegisterData): Observable<any> {
    const observable = this._httpClient.post(this._baseUrl + 'api/auth/register', data, { headers: this.getHeaders() });
      observable.subscribe(
        response => {
          this._userData = response['userDto'];
        }
      );
    return observable;
  }

  public login(data: LoginData) {
    const observable = this._httpClient.post(this._baseUrl + 'api/auth/login', data, { headers: this.getHeaders() });
      observable.subscribe(
        response => {
          this._token = response['token'];
          this._userData = response['userDto'];
        }
      );
    return observable;
  }

  public logout() {
    this._token = null;
  }

  public isAuthenticated(): boolean {
    return this._token !== null;
  }

  public getToken(): string {
    return this._token;
  }
}
