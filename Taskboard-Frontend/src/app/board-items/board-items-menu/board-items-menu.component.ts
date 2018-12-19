import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BoardItemsFilterService } from '../board-items-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/place-to-search.enum';
import { DisplayOrder } from 'src/app/core/enums/display-order.enum';
import { DisplaySize } from 'src/app/core/enums/display-size.enum';
import { BoardElementsToShow } from 'src/app/core/enums/board-elements-to-show.enum';
import { CompletionStatus } from 'src/app/core/enums/completion-status.enum';

@Component({
  selector: 'app-board-items-menu',
  templateUrl: './board-items-menu.component.html',
  styleUrls: ['./board-items-menu.component.css']
})
export class BoardItemsMenuComponent implements OnInit {

  private _boardId: number;

  public textFilter: string;

  public placeToSearchFilter: PlaceToSearch;

  public displayOrderFilter: DisplayOrder;

  public displaySizeFilter: DisplaySize;

  public completionStatusFilter: CompletionStatus;

  public boardElementsToShowFilter: BoardElementsToShow;

  constructor(private _router: Router,
              private _activeRoute: ActivatedRoute,
              private _boardItemsFilterService: BoardItemsFilterService) { }

  ngOnInit() {
    this._boardId = this._activeRoute.parent.snapshot.params['boardId'];
    this.applyFilterValues();
  }

  public newTask() {
    this._router.navigate(['boards/' + this._boardId + '/elements/new/task']);
  }

  public newNote() {
    this._router.navigate(['boards/' + this._boardId + '/elements/new/note']);
  }

  public back() {
    this._router.navigate(['boards/list']);
  }

  private applyFilterValues() {
    this.textFilter = this._boardItemsFilterService.textFilter;
    this.placeToSearchFilter = this._boardItemsFilterService.placeToSearchFilter;
    this.displayOrderFilter = this._boardItemsFilterService.displayOrderFilter;
    this.displaySizeFilter = this._boardItemsFilterService.displaySizeFilter;
    this.completionStatusFilter = this._boardItemsFilterService.completionStatusFilter;
    this.boardElementsToShowFilter = this._boardItemsFilterService.boardElementsToShowFilter;
  }

  public textFilterChange(value: string) {
    console.log(value);
    this._boardItemsFilterService.onFilterChanged(value);
  }

  public placeToSearchChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onPlaceToSearchChanged(PlaceToSearch[value]);
  }

  public displayOrderChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onDisplayOrderChanged(DisplayOrder[value]);
  }

  public displaySizeChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onDisplaySizeChanged(DisplaySize[value]);
  }

  public completionStatusChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onCompletionStatusChanged(CompletionStatus[value]);
  }

  public boardElementsToShowChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onBoardElementsToShowChanged(BoardElementsToShow[value]);
  }
}
