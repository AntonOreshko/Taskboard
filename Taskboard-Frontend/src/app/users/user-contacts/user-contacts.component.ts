import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/auth/interfaces/user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-user-contacts',
  templateUrl: './user-contacts.component.html',
  styleUrls: ['./user-contacts.component.css']
})
export class UserContactsComponent implements OnInit {

  public users: User[] = [];

  constructor(private _usersService: UsersService) {
  }

  ngOnInit() {
    this._usersService.getContacts().subscribe(
      this.onFindContacts.bind(this)
    );
  }

  public searchUsers(filter: string) {
    if (filter.length >= 1) {
     this._usersService.searchContacts(filter).subscribe(
      this.onFindContacts.bind(this)
     );
    } else {
      this._usersService.getContacts().subscribe(
        this.onFindContacts.bind(this)
      );
    }
  }

  public onFindContacts(users: User[]) {
    console.log(users);
    this.users = users;
  }
}
