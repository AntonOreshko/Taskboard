import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Board } from './interfaces/board';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { BoardNewData } from './interfaces/board-new-data';

@Injectable({
  providedIn: 'root'
})
export class BoardService extends HttpService {

  constructor(private _httpClient: HttpClient,
              private _authService: AuthService,
              private _router: Router) {
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

  public getBoards(): Observable<Board[]> {
    return this._httpClient.get<Board[]>(this._baseUrl + 'api/board/list', { headers : this.getHeaders() });
  }

  public newBoard(newBoard: BoardNewData): Observable<Board> {
    return this._httpClient.post<Board>(this._baseUrl + 'api/board/add', newBoard, { headers : this.getHeaders() });
  }
}
