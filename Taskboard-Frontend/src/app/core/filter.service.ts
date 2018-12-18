import { PlaceToSearch } from './enums/PlaceToSearch';
import { DisplayOrder } from './enums/DisplayOrder';
import { DisplaySize } from './enums/DisplaySize';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { BoardItem } from '../board-items/interfaces/board-item';

export class FilterService {

  public textFilter: string;

  public placeToSearchFilter: PlaceToSearch = PlaceToSearch.Everywhere;

  public displayOrderFilter: DisplayOrder = DisplayOrder.ByCreationDate_ASC;

  public displaySizeFilter: DisplaySize = DisplaySize.Medium;

  public textFilterChanged: Observable<string>;
  protected _textFilterChangedObserver: Observer<string>;

  public placeToSearchFilterChanged: Observable<PlaceToSearch>;
  protected _placeToSearchFilterChangedObserver: Observer<PlaceToSearch>;

  public displayOrderFilterChanged: Observable<DisplayOrder>;
  protected _displayOrderFilterChangeObserver: Observer<DisplayOrder>;

  public displaySizeFilterChanged: Observable<DisplaySize>;
  protected _displaySizeFilterChangedObserver: Observer<DisplaySize>;

  constructor() {

    this.textFilter = '';

    this.textFilterChanged = Observable.create((observer: Observer<string>) => {
      this._textFilterChangedObserver = observer;
    }).pipe(share());

    this.placeToSearchFilterChanged = Observable.create((observer: Observer<PlaceToSearch>) => {
      this._placeToSearchFilterChangedObserver = observer;
    }).pipe(share());

    this.displayOrderFilterChanged = Observable.create((observer: Observer<DisplayOrder>) => {
      this._displayOrderFilterChangeObserver = observer;
    }).pipe(share());

    this.displaySizeFilterChanged = Observable.create((observer: Observer<DisplaySize>) => {
      this._displaySizeFilterChangedObserver = observer;
    }).pipe(share());
  }

  public onFilterChanged(filter: string) {
    this.textFilter = filter;
    if (this._textFilterChangedObserver !== undefined) {
      this._textFilterChangedObserver.next(filter);
    }
  }

  public onPlaceToSearchChanged(placeToSearch: PlaceToSearch) {
    this.placeToSearchFilter = placeToSearch;
    if (this._placeToSearchFilterChangedObserver !== undefined) {
      this._placeToSearchFilterChangedObserver.next(placeToSearch);
    }
  }

  public onDisplayOrderChanged(displayOrder: DisplayOrder) {
    this.displayOrderFilter = displayOrder;
    if (this._displayOrderFilterChangeObserver !== undefined) {
      this._displayOrderFilterChangeObserver.next(displayOrder);
    }
  }

  public onDisplaySizeChanged(displaySize: DisplaySize) {
    this.displaySizeFilter = displaySize;
    if (this._displaySizeFilterChangedObserver !== undefined) {
      this._displaySizeFilterChangedObserver.next(displaySize);
    }
  }

  public getDisplayOrderFunc() {
    switch (this.displayOrderFilter) {
      case DisplayOrder.ByCreationDate_ASC:
        return (i1: BoardItem, i2: BoardItem): number => {
          if (i1.created > i2.created) { return 1; }
          if (i2.created > i1.created) { return -1; }
          return 0;
        };
      case DisplayOrder.ByCreationDate_DESC:
        return (i1: BoardItem, i2: BoardItem): number => {
          if (i1.created > i2.created) { return -1; }
          if (i2.created > i1.created) { return 1; }
          return 0;
        };
      case DisplayOrder.ByName_ASC:
        return (i1: BoardItem, i2: BoardItem): number => {
          if (i1.name > i2.name) { return 1; }
          if (i2.name > i1.name) { return -1; }
          return 0;
        };
      case DisplayOrder.ByName_DESC:
        return (i1: BoardItem, i2: BoardItem): number => {
          if (i1.name > i2.name) { return -1; }
          if (i2.name > i1.name) { return 1; }
          return 0;
        };
    }
  }
}
