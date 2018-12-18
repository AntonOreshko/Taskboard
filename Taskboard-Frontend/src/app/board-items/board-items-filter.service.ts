import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { FilterService } from '../core/filter.service';
import { Task } from './interfaces/task';
import { BoardItem } from './interfaces/board-item';
import { PlaceToSearch } from '../core/enums/PlaceToSearch';
import { BoardItemsToShow } from '../core/enums/BoardItemsToShow';
import { Note } from './interfaces/note';

@Injectable({
  providedIn: 'root'
})
export class BoardItemsFilterService extends FilterService {

  public boardItemsToShowFilter: BoardItemsToShow = BoardItemsToShow.All;

  public boardItemsToShowFilterChanged: Observable<BoardItemsToShow>;
  protected _boardItemsToShowFilterChangedObserver: Observer<BoardItemsToShow>;

  constructor() {
    super();
    this.boardItemsToShowFilterChanged = Observable.create((observer: Observer<BoardItemsToShow>) => {
      this._boardItemsToShowFilterChangedObserver = observer;
    }).pipe(share());
  }

  public onBoardItemsToShowChanged(itemsToShow: BoardItemsToShow) {
    this.boardItemsToShowFilter = itemsToShow;
    if (this._boardItemsToShowFilterChangedObserver !== undefined) {
      this._boardItemsToShowFilterChangedObserver.next(itemsToShow);
    }
  }

  public applyTextFilter(item: BoardItem): boolean {
    const nameContains = item.name.includes(this.textFilter);
    let descriptionContains = false;
    if (item.description !== undefined && item.description !== null) {
      descriptionContains = item.description.includes(this.textFilter);
    }

    switch (this.placeToSearchFilter) {
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
    if (this.textFilter.length > 0) {
      textFilterResult = this.applyTextFilter(item);
    }
    return textFilterResult && this.applyBoardItemFilter(item);
  }

  public applyBoardItemFilter(boardItem: BoardItem): boolean {
    switch (this.boardItemsToShowFilter) {
      case BoardItemsToShow.All:
        return true;
      case BoardItemsToShow.Completed:
        if (this.isTask(boardItem)) {
          return (boardItem as Task).completed;
        }
        return false;
      case BoardItemsToShow.Incomplete:
        if (this.isTask(boardItem)) {
          return !(boardItem as Task).completed;
        }
        return false;
      case BoardItemsToShow.Notes:
        return this.isNote(boardItem);
      case BoardItemsToShow.Tasks:
        return this.isTask(boardItem);
    }
  }

  private isTask(boardItem: BoardItem) {
    return typeof boardItem['completed'] === 'boolean';
  }

  private isNote(boardItem: BoardItem) {
    return typeof boardItem['completed'] === 'undefined';
  }
}
