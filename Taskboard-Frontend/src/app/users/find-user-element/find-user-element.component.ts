import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/auth/interfaces/user';

@Component({
  selector: 'app-find-user-element',
  templateUrl: './find-user-element.component.html',
  styleUrls: ['./find-user-element.component.css']
})
export class FindUserElementComponent implements OnInit {

  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

  public add() {

  }

}
