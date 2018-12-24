import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/auth/interfaces/user';

@Component({
  selector: 'app-user-contacts-element',
  templateUrl: './user-contacts-element.component.html',
  styleUrls: ['./user-contacts-element.component.css']
})
export class UserContactsElementComponent implements OnInit {

  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

  public add() {

  }

}
