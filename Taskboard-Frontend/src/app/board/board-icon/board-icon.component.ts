import { Component, OnInit, Input } from '@angular/core';
import { Board } from '../interfaces/board';

@Component({
  selector: 'app-board-icon',
  templateUrl: './board-icon.component.html',
  styleUrls: ['./board-icon.component.css']
})
export class BoardIconComponent implements OnInit {

  @Input() board: Board;

  constructor() { }

  ngOnInit() {

  }

  public open() {

  }

  public edit() {

  }

  public remove() {

  }
}
