import { Component, OnInit, Input } from '@angular/core';
import { Board } from '../interfaces/board';
import { Router } from '@angular/router';
import { BoardService } from '../board.service';

@Component({
  selector: 'app-board-icon',
  templateUrl: './board-icon.component.html',
  styleUrls: ['./board-icon.component.css']
})
export class BoardIconComponent implements OnInit {

  @Input() board: Board;

  constructor(private _router: Router,
              private _boardService: BoardService) {
  }

  ngOnInit() {

  }

  public open() {
    this._router.navigate(['boarditems', this.board.id, 'list']);
  }

  public edit() {
    this._router.navigate(['boards/edit', this.board.id]);
  }

  public remove() {
    this._boardService.deleteBoard(this.board.id)
      .subscribe(response => {
        console.log(response);
      });
  }
}
