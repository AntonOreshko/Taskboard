import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { FilterService } from '../core/filter.service';
import { Task } from './interfaces/task';
import { BoardItem } from './interfaces/board-item';
import { PlaceToSearch } from '../core/enums/PlaceToSearch';
import { BoardItemsToShow } from '../core/enums/BoardItemsToShow';

@Injectable({
  providedIn: 'root'
})
export class BoardItemsFilterService extends FilterService {

  public itemsToShow: BoardItemsToShow = BoardItemsToShow.All;

  public itemsToShowChanged: Observable<BoardItemsToShow>;
  protected _itemsToShowChangedObserver: Observer<BoardItemsToShow>;

  constructor() {
    super();
    this.itemsToShowChanged = Observable.create((observer: Observer<BoardItemsToShow>) => {
      this._itemsToShowChangedObserver = observer;
    }).pipe(share());
  }

  protected onItemsToShowChanged(itemsToShow: BoardItemsToShow) {
    this.itemsToShow = itemsToShow;
    if (this._itemsToShowChangedObserver !== undefined) {
      this._itemsToShowChangedObserver.next(itemsToShow);
    }
  }

  public applyTextFilter(item: BoardItem): boolean {
    const nameContains = item.name.includes(this.filter);
    let descriptionContains = false;
    if (item.description !== undefined && item.description !== null) {
      descriptionContains = item.description.includes(this.filter);
    }

    switch (this.placeToSearch) {
      case PlaceToSearch.Everywhere:
        return nameContains || descriptionContains;
      case PlaceToSearch.Name:
        return nameContains;
      case PlaceToSearch.Description:
        return descriptionContains;
    }
  }

  public applyAllFilters(item: BoardItem): boolean {
    let textFilterResult = true;
    if (this.filter.length > 0) {
      textFilterResult = this.applyTextFilter(item);
    }
    return textFilterResult && this.applyBoardItemFilter(item);
  }

  public applyBoardItemFilter(boardItem: BoardItem): boolean {
    switch (this.itemsToShow) {
      case BoardItemsToShow.All:
        return true;
      case BoardItemsToShow.Completed:
        if (boardItem as Task) {
          return (boardItem as Task).completed;
        }
        return false;
      case BoardItemsToShow.Incomplete:
        if (boardItem as Task) {
          return !(boardItem as Task).completed;
        }
        return false;
      case BoardItemsToShow.Notes:
        return !(boardItem as Task);
      case BoardItemsToShow.Tasks:
        return (boardItem as Task) !== null;
    }
  }
}
