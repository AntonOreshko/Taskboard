import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizedService } from '../core/authorized.service';
import { AuthService } from '../auth/auth.service';
import { Observable, Observer } from 'rxjs';
import { Subtask } from './interfaces/subtask';
import { share, map } from 'rxjs/operators';
import { SubtaskNewData } from './interfaces/subtask-new-data';
import { SubtaskEditData } from './interfaces/subtask-edit-data';

@Injectable({
  providedIn: 'root'
})
export class SubtasksService extends AuthorizedService {

  public subtaskCreated: Observable<Subtask>;
  private _subtaskCreatedObserver: Observer<Subtask>;

  public subtaskChanged: Observable<Subtask>;
  private _subtaskChangedObserver: Observer<Subtask>;

  public subtaskDeleted: Observable<boolean>;
  private _subtaskDeletedObserver: Observer<boolean>;

  constructor(private _httpClient: HttpClient,
                      _authService: AuthService) {
    super(_authService);

    this.subtaskCreated = Observable.create((observer: Observer<Subtask>) => {
      this._subtaskCreatedObserver = observer;
    }).pipe(share());

    this.subtaskChanged = Observable.create((observer: Observer<Subtask>) => {
      this._subtaskChangedObserver = observer;
    }).pipe(share());

    this.subtaskDeleted = Observable.create((observer: Observer<boolean>) => {
      this._subtaskDeletedObserver = observer;
    }).pipe(share());
  }

  public getSubtasks(taskId: number): Observable<Subtask[]> {
    return this._httpClient.get<Subtask[]>(
      this._baseUrl + 'api/subtask/list/' + taskId,
      { headers: this.getHeaders() }
    );
  }

  public getSubtask(id: number): Observable<Subtask> {
    return this._httpClient.get<Subtask>(
      this._baseUrl + 'api/subtask/' + id,
      { headers: this.getHeaders() }
    );
  }

  public newSubtask(newSubtask: SubtaskNewData): Observable<Subtask> {
    return this._httpClient.post<Subtask>(
      this._baseUrl + 'api/subtask/add',
      newSubtask,
      { headers : this.getHeaders() }
    ).pipe(
      map<Subtask, Subtask>((subtask: Subtask): Subtask => {
        if (this._subtaskCreatedObserver !== undefined && this._subtaskCreatedObserver !== null) {
          this._subtaskCreatedObserver.next(subtask);
        }
        return subtask;
      })
    );
  }

  public editSubtask(editSubtask: SubtaskEditData): Observable<Subtask> {
    return this._httpClient.put<Subtask>(
      this._baseUrl + 'api/subtask/edit',
      editSubtask,
      { headers : this.getHeaders() }
    ).pipe(
      map<Subtask, Subtask>((subtask: Subtask): Subtask => {
        if (this._subtaskChangedObserver !== undefined && this._subtaskChangedObserver !== null) {
          this._subtaskChangedObserver.next(subtask);
        }
        return subtask;
      })
    );
  }

  public deleteSubtask(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(
      this._baseUrl + 'api/subtask/delete/' + id,
      { headers : this.getHeaders() }
    ).pipe(
      map<boolean, boolean>((result: boolean): boolean => {
        if (this._subtaskDeletedObserver !== undefined && this._subtaskDeletedObserver !== null) {
          this._subtaskDeletedObserver.next(result);
        }
        return result;
      })
    );
  }

}
