import { Component, OnInit, Input } from '@angular/core';
import { Board } from '../interfaces/board';
import { Router } from '@angular/router';

@Component({
  selector: 'app-board-icon',
  templateUrl: './board-icon.component.html',
  styleUrls: ['./board-icon.component.css']
})
export class BoardIconComponent implements OnInit {

  @Input() board: Board;

  constructor(private _router: Router) { }

  ngOnInit() {

  }

  public open() {

  }

  public edit() {
    this._router.navigate(['boards/edit/' + this.board.id]);
  }

  public remove() {

  }
}
