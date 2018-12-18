import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BoardItemsFilterService } from '../board-items-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/PlaceToSearch';
import { DisplayOrder } from 'src/app/core/enums/DisplayOrder';
import { DisplaySize } from 'src/app/core/enums/DisplaySize';
import { BoardItemsToShow } from 'src/app/core/enums/BoardItemsToShow';

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

  public boardItemsToShowFilter: BoardItemsToShow;

  constructor(private _router: Router,
              private _activeRoute: ActivatedRoute,
              private _boardItemsFilterService: BoardItemsFilterService) { }

  ngOnInit() {
    this._boardId = this._activeRoute.parent.snapshot.params['id'];
    this.applyFilterValues();
  }

  public newTask() {
    this._router.navigate(['boarditems/' + this._boardId + '/new/task']);
  }

  public newNote() {
    this._router.navigate(['boarditems/' + this._boardId + '/new/note']);
  }

  public back() {
    this._router.navigate(['boards/list']);
  }

  private applyFilterValues() {
    this.textFilter = this._boardItemsFilterService.textFilter;
    this.placeToSearchFilter = this._boardItemsFilterService.placeToSearchFilter;
    this.displayOrderFilter = this._boardItemsFilterService.displayOrderFilter;
    this.displaySizeFilter = this._boardItemsFilterService.displaySizeFilter;
    this.boardItemsToShowFilter = this._boardItemsFilterService.boardItemsToShowFilter;
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

  public boardItemsToShowChanged(value: string) {
    console.log(value);
    this._boardItemsFilterService.onBoardItemsToShowChanged(BoardItemsToShow[value]);
  }
}
