import { Injectable } from '@angular/core';
import { AuthorizedService } from '../core/authorized.service';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { Observable, Observer } from 'rxjs';
import { User } from '../auth/interfaces/user';
import { share, map } from 'rxjs/operators';
import { UserEditData } from './interfaces/user-edit-data';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends AuthorizedService {

  public userChanged: Observable<User>;
  private _userChangedObserver: Observer<User>;

  constructor(private _httpClient: HttpClient,
    _authService: AuthService) {

    super(_authService);
    this.userChanged = Observable.create((observer: Observer<User>) => {
      this._userChangedObserver = observer;
    }).pipe(share());
  }

  public getUser(): Observable<User> {
    return this._httpClient.get<User>(
      this._baseUrl + 'api/users/info',
      { headers : this.getHeaders() }
    );
  }

  public editUser(editUser: UserEditData): Observable<User> {
    return this._httpClient.put<User>(
      this._baseUrl + 'api/users/edit',
      editUser,
      { headers: this.getHeaders() }
    ).pipe(
      map<User, User>((user: User): User => {
        if (this._userChangedObserver !== undefined && this._userChangedObserver != null) {
          this._userChangedObserver.next(user);
        }
        return user;
      })
    );
  }

  public searchUsers(filter: string): Observable<User[]> {
    return this._httpClient.get<User[]>(
      this._baseUrl + 'api/users/search/' + filter,
      { headers: this.getHeaders() }
    );
  }
}
