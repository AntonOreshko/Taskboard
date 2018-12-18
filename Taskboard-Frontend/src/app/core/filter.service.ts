import { PlaceToSearch } from './enums/PlaceToSearch';
import { DisplayOrder } from './enums/DisplayOrder';
import { DisplaySize } from './enums/DisplaySize';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { BoardItem } from '../board-items/interfaces/board-item';

export class FilterService {

  public filter: string;

  public placeToSearch: PlaceToSearch = PlaceToSearch.Everywhere;

  public displayOrder: DisplayOrder = DisplayOrder.ByCreationDate_ASC;

  public displaySize: DisplaySize = DisplaySize.Medium;

  public filterChanged: Observable<string>;
  protected _filterChangedObserver: Observer<string>;

  public placeToSearchChanged: Observable<PlaceToSearch>;
  protected _placeToSearchChangedObserver: Observer<PlaceToSearch>;

  public displayOrderChanged: Observable<DisplayOrder>;
  protected _displayOrderChangeObserver: Observer<DisplayOrder>;

  public displaySizeChanged: Observable<DisplaySize>;
  protected _displaySizeChangedObserver: Observer<DisplaySize>;

  constructor() {

    this.filter = '';

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

  public getDisplayOrderFunc() {
    switch (this.displayOrder) {
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
