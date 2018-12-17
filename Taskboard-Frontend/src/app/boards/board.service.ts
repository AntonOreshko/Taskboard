import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Board } from './interfaces/board';
import { Observable, Observer } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { BoardNewData } from './interfaces/board-new-data';
import { BoardEditData } from './interfaces/board-edit-data';
import { map, share } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BoardService extends HttpService {

  public boardCreated: Observable<Board>;
  private _boardCreatedObserver: Observer<Board>;

  public boardChanged: Observable<Board>;
  private _boardChangedObserver: Observer<Board>;

  public boardDeleted: Observable<boolean>;
  private _boardDeletedObserver: Observer<boolean>;

  constructor(private _httpClient: HttpClient,
              private _authService: AuthService) {
    super();

    this.boardCreated = Observable.create((observer: Observer<Board>) => {
      this._boardCreatedObserver = observer;
    }).pipe(share());

    this.boardChanged = Observable.create((observer: Observer<Board>) => {
      this._boardChangedObserver = observer;
    }).pipe(share());

    this.boardDeleted = Observable.create((observer: Observer<boolean>) => {
      this._boardDeletedObserver = observer;
    }).pipe(share());
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

  public getBoard(id: number): Observable<Board> {
    return this._httpClient.get<Board>(
      this._baseUrl + 'api/board/' + id,
      { headers : this.getHeaders() }
    );
  }

  public newBoard(newBoard: BoardNewData): Observable<Board> {
    return this._httpClient.post<Board>(
      this._baseUrl + 'api/board/add',
      newBoard,
      { headers : this.getHeaders() }
    ).pipe(
      map<Board, Board>((board: Board): Board => {
        if (this._boardCreatedObserver !== undefined && this._boardCreatedObserver !== null) {
          this._boardCreatedObserver.next(board);
        }
        return board;
      })
    );
  }

  public editBoard(editBoard: BoardEditData): Observable<Board> {
    return this._httpClient.put<Board>(
      this._baseUrl + 'api/board/edit/',
      editBoard,
      { headers : this.getHeaders() }
    ).pipe(
      map<Board, Board>((board: Board): Board => {
        if (this._boardChangedObserver !== undefined && this._boardChangedObserver !== null) {
          this._boardChangedObserver.next(board);
        }
        return board;
      })
    );
  }

  public deleteBoard(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(
      this._baseUrl + 'api/board/delete/' + id,
      { headers : this.getHeaders() }
    ).pipe(
      map<boolean, boolean>((result: boolean): boolean => {
        if (this._boardDeletedObserver !== undefined && this._boardDeletedObserver !== null) {
          this._boardDeletedObserver.next(result);
        }
        return result;
      })
    );
  }
}
