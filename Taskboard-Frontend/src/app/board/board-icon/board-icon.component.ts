import { Component, OnInit } from '@angular/core';
import { Board } from '../interfaces/board';

@Component({
  selector: 'app-board-icon',
  templateUrl: './board-icon.component.html',
  styleUrls: ['./board-icon.component.css']
})
export class BoardIconComponent implements OnInit {

  public board: Board;

  constructor() { }

  ngOnInit() {
    this.board = {
      id: 1,
      created: 'today',
      createdById: 1,
      name: 'Superboard',
      description: 'Superdescription'
    };
  }

}
