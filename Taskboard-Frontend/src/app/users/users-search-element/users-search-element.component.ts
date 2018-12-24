import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/auth/interfaces/user';

@Component({
  selector: 'app-users-search-element',
  templateUrl: './users-search-element.component.html',
  styleUrls: ['./users-search-element.component.css']
})
export class UsersSearchElementComponent implements OnInit {

  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

  public add() {

  }

}
