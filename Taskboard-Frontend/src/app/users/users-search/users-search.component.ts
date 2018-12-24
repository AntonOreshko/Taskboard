import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { Router } from '@angular/router';
import { User } from 'src/app/auth/interfaces/user';
import { UserWithContactStatus } from '../interfaces/user-with-contact-status';

@Component({
  selector: 'app-users-search',
  templateUrl: './users-search.component.html',
  styleUrls: ['./users-search.component.css']
})
export class UsersSearchComponent implements OnInit {

  public users: UserWithContactStatus[] = [];

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
    } else {
      this.users = [];
    }
  }

  public onFindUsers(users: UserWithContactStatus[]) {
    console.log(users);
    this.users = users;
  }
}
