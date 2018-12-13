import { Component, OnInit } from '@angular/core';
import { BoardService } from '../board.service';
import { Board } from '../interfaces/board';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css']
})
export class BoardListComponent implements OnInit {

  public boards: Board[];

  constructor(private _boardService: BoardService) { }

  ngOnInit() {
    this._boardService.getBoards().subscribe(
      boards => {
        this.boards = boards;
        console.log(this.boards);
      },
      error => {

      }
    );
  }

}
