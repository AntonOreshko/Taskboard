import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { Task } from './interfaces/task';
import { Note } from './interfaces/note';
import { TaskNewData } from './interfaces/task-new-data';
import { TaskEditData } from './interfaces/task-edit-data';
import { NoteNewData } from './interfaces/note-new-data';
import { NoteEditData } from './interfaces/note-edit-data';
import { Observable, Observer } from 'rxjs';
import { share, map } from 'rxjs/operators';
import { AuthorizedService } from '../core/authorized.service';

@Injectable({
  providedIn: 'root'
})
export class BoardItemsService extends AuthorizedService {

  public taskCreated: Observable<Task>;
  private _taskCreatedObserver: Observer<Task>;

  public taskChanged: Observable<Task>;
  private _taskChangedObserver: Observer<Task>;

  public taskDeleted: Observable<boolean>;
  private _taskDeletedObserver: Observer<boolean>;

  public noteCreated: Observable<Note>;
  private _noteCreatedObserver: Observer<Note>;

  public noteChanged: Observable<Note>;
  private _noteChangedObserver: Observer<Note>;

  public noteDeleted: Observable<boolean>;
  private _noteDeletedObserver: Observer<boolean>;

  constructor(private _httpClient: HttpClient,
                      _authService: AuthService) {
    super(_authService);

    this.taskCreated = Observable.create((observer: Observer<Task>) => {
      this._taskCreatedObserver = observer;
    }).pipe(share());

    this.taskChanged = Observable.create((observer: Observer<Task>) => {
      this._taskChangedObserver = observer;
    }).pipe(share());

    this.taskDeleted = Observable.create((observer: Observer<boolean>) => {
      this._taskDeletedObserver = observer;
    }).pipe(share());

    this.noteCreated = Observable.create((observer: Observer<Note>) => {
      this._noteCreatedObserver = observer;
    }).pipe(share());

    this.noteChanged = Observable.create((observer: Observer<Note>) => {
      this._noteChangedObserver = observer;
    }).pipe(share());

    this.noteDeleted = Observable.create((observer: Observer<boolean>) => {
      this._noteDeletedObserver = observer;
    }).pipe(share());
  }

  public getTasks(boardId: number): Observable<Task[]> {
    return this._httpClient.get<Task[]>(
      this._baseUrl + 'api/task/list/' + boardId,
      { headers : this.getHeaders() }
    );
  }

  public getTask(id: number): Observable<Task> {
    return this._httpClient.get<Task>(
      this._baseUrl + 'api/task/' + id,
      { headers : this.getHeaders() }
    );
  }

  public newTask(newTask: TaskNewData): Observable<Task> {
    return this._httpClient.post<Task>(
      this._baseUrl + 'api/task/add',
      newTask,
      { headers : this.getHeaders() }
    ).pipe(
      map<Task, Task>((task: Task): Task => {
        if (this._taskCreatedObserver !== undefined && this._taskCreatedObserver !== null) {
          this._taskCreatedObserver.next(task);
        }
        return task;
      })
    );
  }

  public editTask(editTask: TaskEditData): Observable<Task> {
    return this._httpClient.put<Task>(
      this._baseUrl + 'api/task/edit',
      editTask,
      { headers : this.getHeaders() }
    ).pipe(
      map<Task, Task>((task: Task): Task => {
        if (this._taskChangedObserver !== undefined && this._taskChangedObserver !== null) {
          this._taskChangedObserver.next(task);
        }
        return task;
      })
    );
  }

  public deleteTask(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(
      this._baseUrl + 'api/task/delete/' + id,
      { headers : this.getHeaders() }
    ).pipe(
      map<boolean, boolean>((result: boolean): boolean => {
        if (this._taskDeletedObserver !== undefined && this._taskDeletedObserver !== null) {
          this._taskDeletedObserver.next(result);
        }
        return result;
      })
    );
  }

  public getNotes(boardId: number): Observable<Note[]> {
    return this._httpClient.get<Note[]>(
      this._baseUrl + 'api/note/list/' + boardId,
      { headers : this.getHeaders() }
    );
  }

  public getNote(id: number): Observable<Note> {
    return this._httpClient.get<Note>(
      this._baseUrl + 'api/note/' + id,
      { headers : this.getHeaders() }
    );
  }

  public newNote(newNote: NoteNewData): Observable<Note> {
    return this._httpClient.post<Note>(
      this._baseUrl + 'api/note/add',
      newNote,
      { headers : this.getHeaders() }
    ).pipe(
      map<Note, Note>((note: Note): Note => {
        if (this._noteCreatedObserver !== undefined && this._noteCreatedObserver !== null) {
          this._noteCreatedObserver.next(note);
        }
        return note;
      })
    );
  }

  public editNote(editNote: NoteEditData): Observable<Note> {
    return this._httpClient.put<Note>(
      this._baseUrl + 'api/note/edit',
      editNote,
      { headers : this.getHeaders() }
    ).pipe(
      map<Note, Note>((note: Note): Note => {
        if (this._noteChangedObserver !== undefined && this._noteChangedObserver !== null) {
          this._noteChangedObserver.next(note);
        }
        return note;
      })
    );
  }

  public deleteNote(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(
      this._baseUrl + 'api/note/delete/' + id,
      { headers : this.getHeaders() }
    ).pipe(
      map<boolean, boolean>((result: boolean): boolean => {
        if (this._noteDeletedObserver !== undefined && this._noteDeletedObserver !== null) {
          this._noteDeletedObserver.next(result);
        }
        return result;
      })
    );
  }
}
