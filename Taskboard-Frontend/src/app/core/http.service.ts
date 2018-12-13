import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  protected _baseUrl = 'http://localhost:50000/';

  protected _headers: HttpHeaders;

  constructor() {
    this._headers = new HttpHeaders(
      {'Content-Type': 'application/json'},
    );
  }

  public getHeaders(): HttpHeaders {
    return this._headers;
  }
}
