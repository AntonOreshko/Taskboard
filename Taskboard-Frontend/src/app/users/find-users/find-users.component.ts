import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { Router } from '@angular/router';
import { User } from 'src/app/auth/interfaces/user';

@Component({
  selector: 'app-find-users',
  templateUrl: './find-users.component.html',
  styleUrls: ['./find-users.component.css']
})
export class FindUsersComponent implements OnInit {

  public users: User[] = [];

  constructor(private _usersService: UsersService,
              private _router: Router) {
  }

  ngOnInit() {
  }

  public searchUsers(filter: string) {
    if (filter.length >= 1) {
     this._usersService.searchUsers(filter).subscribe(
      this.onFindUsers.bind(this)
     );
    }
  }

  public onFindUsers(users: User[]) {
    console.log(users);
    this.users = users;
  }
}
