import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BoardFilterService } from '../board-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/place-to-search.enum';
import { DisplayOrder } from 'src/app/core/enums/display-order.enum';
import { DisplaySize } from 'src/app/core/enums/display-size.enum';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrls: ['./board-menu.component.css']
})
export class BoardMenuComponent implements OnInit {

  public textFilter: string;

  public placeToSearchFilter: PlaceToSearch;

  public displayOrderFilter: DisplayOrder;

  public displaySizeFilter: DisplaySize;

  constructor(private _router: Router,
              private _boardFilterService: BoardFilterService) { }

  public newBoard() {
    this._router.navigate(['boards/new']);
  }

  ngOnInit() {
    this.applyFilterValues();
  }

  private applyFilterValues() {
    this.textFilter = this._boardFilterService.textFilter;
    this.placeToSearchFilter = this._boardFilterService.placeToSearchFilter;
    this.displayOrderFilter = this._boardFilterService.displayOrderFilter;
    this.displaySizeFilter = this._boardFilterService.displaySizeFilter;
  }

  public textFilterChange(value: string) {
    console.log(value);
    this._boardFilterService.onFilterChanged(value);
  }

  public placeToSearchChanged(value: string) {
    console.log(value);
    this._boardFilterService.onPlaceToSearchChanged(PlaceToSearch[value]);
  }

  public displayOrderChanged(value: string) {
    console.log(value);
    this._boardFilterService.onDisplayOrderChanged(DisplayOrder[value]);
  }

  public displaySizeChanged(value: string) {
    console.log(value);
    this._boardFilterService.onDisplaySizeChanged(DisplaySize[value]);
  }
}
