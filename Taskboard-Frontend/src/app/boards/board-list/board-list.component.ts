import { Component, OnInit, OnDestroy } from '@angular/core';
import { BoardService } from '../board.service';
import { Board } from '../interfaces/board';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css']
})
export class BoardListComponent implements OnInit, OnDestroy {

  public boards: Board[];

  private _subscriptions: Subscription[] = [];

  constructor(private _boardService: BoardService) { }

  public ngOnInit() {
    // subscribe on events
    this._subscriptions.push(this._boardService.boardDeleted.subscribe(this.onBoardDeleted.bind(this)));

    this._boardService.getBoards().subscribe(
      boards => {
        this.boards = boards;
        console.log(this.boards);
      },
      error => {

      }
    );
  }

  public ngOnDestroy(): void {
    this._subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }

  private onBoardDeleted(result: boolean) {
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
