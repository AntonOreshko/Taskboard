import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Board } from './interfaces/board';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { BoardNewData } from './interfaces/board-new-data';
import { BoardEditData } from './interfaces/board-edit-data';

@Injectable({
  providedIn: 'root'
})
export class BoardService extends HttpService {

  constructor(private _httpClient: HttpClient,
              private _authService: AuthService) {
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
    return this._httpClient.get<Board[]>(
      this._baseUrl + 'api/board/list',
      { headers : this.getHeaders() }
    );
  }

  public newBoard(newBoard: BoardNewData): Observable<Board> {
    return this._httpClient.post<Board>(
      this._baseUrl + 'api/board/add',
      newBoard,
      { headers : this.getHeaders() }
    );
  }

  public getBoard(id: number): Observable<Board> {
    return this._httpClient.get<Board>(
      this._baseUrl + 'api/board/' + id,
      { headers : this.getHeaders() }
    );
  }

  public editBoard(id: number, editBoard: BoardEditData): Observable<Board> {
    return this._httpClient.put<Board>(
      this._baseUrl + 'api/board/edit/' + id,
      editBoard,
      { headers : this.getHeaders() }
    );
  }

}
