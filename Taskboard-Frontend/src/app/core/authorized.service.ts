import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { AuthService } from '../auth/auth.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthorizedService extends HttpService {

  constructor(protected _authService: AuthService) {
    super();
  }

  public getHeaders(): HttpHeaders {
    let headers = super.getHeaders();
    const token = this._authService.getToken();
    if (token !== null) {
      headers = headers.append('Authorization', 'Bearer ' + token);
    }
    return headers;
  }
}
