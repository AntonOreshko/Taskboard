import { Component, OnInit, OnDestroy } from '@angular/core';
import { BoardService } from '../board.service';
import { Board } from '../interfaces/board';
import { Subscription } from 'rxjs';
import { BoardFilterService } from '../board-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/PlaceToSearch';
import { DisplayOrder } from 'src/app/core/enums/DisplayOrder';
import { DisplaySize } from 'src/app/core/enums/DisplaySize';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css']
})
export class BoardListComponent implements OnInit, OnDestroy {

  private _boards: Board[] = [];

  public displayBoards: Board[] = [];

  private _subscriptions: Subscription[] = [];

  constructor(private _boardService: BoardService,
              private _boardFilterService: BoardFilterService) { }

  public ngOnInit() {

    this._subscriptions.push(this._boardService.boardDeleted.subscribe(
      this.onBoardDeleted.bind(this))
    );

    this._subscriptions.push(this._boardFilterService.filterChanged.subscribe(
      this.onFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardFilterService.placeToSearchChanged.subscribe(
      this.onPlaceToSearchChanged.bind(this))
    );

    this._subscriptions.push(this._boardFilterService.displayOrderChanged.subscribe(
      this.onDisplayOrderChanged.bind(this))
    );

    this._subscriptions.push(this._boardFilterService.displaySizeChanged.subscribe(
      this.onDisplaySizeChanged.bind(this))
    );

    this._subscriptions.push(this._boardService.getBoards().subscribe(
      this.onGetBoardsList.bind(this))
    );
  }

  public ngOnDestroy(): void {
    this._subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }

  private onGetBoardsList(boards: Board[]) {
    this._boards = boards;
    console.log(this._boards);
    this.setDisplayBoards();
  }

  private onBoardDeleted(result: boolean) {
    this._boardService.getBoards().subscribe(
      this.onGetBoardsList.bind(this)
    );
  }

  public setDisplayBoards() {

    this.displayBoards = [];

    for (let i = 0; i < this._boards.length; i++) {
      if (this._boardFilterService.applyAllFilters(this._boards[i])) {
        this.displayBoards.push(this._boards[i]);
      }
    }

    this.displayBoards = this.displayBoards.sort(this._boardFilterService.getDisplayOrderFunc());
  }

  private onFilterChanged(value: string) {
    this.setDisplayBoards();
  }

  private onPlaceToSearchChanged(value: PlaceToSearch) {
    this.setDisplayBoards();
  }

  private onDisplayOrderChanged(value: DisplayOrder) {
    this.setDisplayBoards();
  }

  private onDisplaySizeChanged(value: DisplaySize) {
    this.setDisplayBoards();
  }
}
