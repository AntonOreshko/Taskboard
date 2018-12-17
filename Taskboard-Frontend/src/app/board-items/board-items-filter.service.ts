import { Injectable } from '@angular/core';
import { PlaceToSearch } from '../core/enums/PlaceToSearch';
import { DisplayOrder } from '../core/enums/DisplayOrder';
import { DisplaySize } from '../core/enums/DisplaySize';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BoardItemsFilterService {

  public filter: string;

  public placeToSearch: PlaceToSearch = PlaceToSearch.Everywhere;

  public displayOrder: DisplayOrder = DisplayOrder.ByCreationDate_ASC;

  public displaySize: DisplaySize = DisplaySize.Medium;

  public itemsToShow: BoardItemsToShow = BoardItemsToShow.All;

  public filterChanged: Observable<string>;
  private _filterChangedObserver: Observer<string>;

  public placeToSearchChanged: Observable<PlaceToSearch>;
  private _placeToSearchChangedObserver: Observer<PlaceToSearch>;

  public displayOrderChanged: Observable<DisplayOrder>;
  private _displayOrderChangeObserver: Observer<DisplayOrder>;

  public displaySizeChanged: Observable<DisplaySize>;
  private _displaySizeChangedObserver: Observer<DisplaySize>;

  public itemsToShowChanged: Observable<BoardItemsToShow>;
  private _itemsToShowChangedObserver: Observer<BoardItemsToShow>;

  constructor() {
    this.filterChanged = Observable.create((observer: Observer<string>) => {
      this._filterChangedObserver = observer;
    }).pipe(share());

    this.placeToSearchChanged = Observable.create((observer: Observer<PlaceToSearch>) => {
      this._placeToSearchChangedObserver = observer;
    }).pipe(share());

    this.displayOrderChanged = Observable.create((observer: Observer<DisplayOrder>) => {
      this._displayOrderChangeObserver = observer;
    }).pipe(share());

    this.displaySizeChanged = Observable.create((observer: Observer<DisplaySize>) => {
      this._displaySizeChangedObserver = observer;
    }).pipe(share());

    this.itemsToShowChanged = Observable.create((observer: Observer<BoardItemsToShow>) => {
      this._itemsToShowChangedObserver = observer;
    }).pipe(share());
  }

  public onFilterChanged(filter: string) {
    this.filter = filter;
    if (this._filterChangedObserver !== undefined) {
      this._filterChangedObserver.next(filter);
    }
  }

  public onPlaceToSearchChanged(placeToSearch: PlaceToSearch) {
    this.placeToSearch = placeToSearch;
    if (this._placeToSearchChangedObserver !== undefined) {
      this._placeToSearchChangedObserver.next(placeToSearch);
    }
  }

  public onDisplayOrderChanged(displayOrder: DisplayOrder) {
    this.displayOrder = displayOrder;
    if (this._displayOrderChangeObserver !== undefined) {
      this._displayOrderChangeObserver.next(displayOrder);
    }
  }

  public onDisplaySizeChanged(displaySize: DisplaySize) {
    this.displaySize = displaySize;
    if (this._displaySizeChangedObserver !== undefined) {
      this._displaySizeChangedObserver.next(displaySize);
    }
  }

  public onItemsToShowChanged(itemsToShow: BoardItemsToShow) {
    this.itemsToShow = itemsToShow;
    if (this._itemsToShowChangedObserver !== undefined) {
      this._itemsToShowChangedObserver.next(itemsToShow);
    }
  }

}
