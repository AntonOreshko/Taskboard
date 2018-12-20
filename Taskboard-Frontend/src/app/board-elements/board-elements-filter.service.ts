import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { FilterService } from '../core/filter.service';
import { Task } from './interfaces/task';
import { BoardElementsToShow } from '../core/enums/board-elements-to-show.enum';
import { Descriptable } from '../core/interfaces/descriptable';
import { Completable } from '../core/interfaces/completable';
import { CompletionStatus } from '../core/enums/completion-status.enum';
import { BoardElement } from './interfaces/board-element';

@Injectable({
  providedIn: 'root'
})
export class BoardElementsFilterService extends FilterService {

  public completionStatusFilter: CompletionStatus = CompletionStatus.All;

  public boardElementsToShowFilter: BoardElementsToShow = BoardElementsToShow.All;

  public completionStatusFilterChanged: Observable<CompletionStatus>;
  protected _completionStatusFilterChangedObserver: Observer<CompletionStatus>;

  public boardElementsToShowFilterChanged: Observable<BoardElementsToShow>;
  protected _boardElementsToShowFilterChangedObserver: Observer<BoardElementsToShow>;

  constructor() {
    super();

    this.completionStatusFilterChanged = Observable.create((observer: Observer<CompletionStatus>) => {
      this._completionStatusFilterChangedObserver = observer;
    }).pipe(share());

    this.boardElementsToShowFilterChanged = Observable.create((observer: Observer<BoardElementsToShow>) => {
      this._boardElementsToShowFilterChangedObserver = observer;
    }).pipe(share());
  }

  public onBoardElementsToShowChanged(boardElementsToShow: BoardElementsToShow) {
    this.boardElementsToShowFilter = boardElementsToShow;
    if (this._boardElementsToShowFilterChangedObserver !== undefined) {
      this._boardElementsToShowFilterChangedObserver.next(boardElementsToShow);
    }
  }

  public onCompletionStatusChanged(completionStatus: CompletionStatus) {
    this.completionStatusFilter = completionStatus;
    if (this._completionStatusFilterChangedObserver !== undefined) {
      this._completionStatusFilterChangedObserver.next(completionStatus);
    }
  }

  public applyAllFilters(boardElement: BoardElement): boolean {
    return super.applyAllFilters(boardElement) &&
           this.applyCompletionStatusFilter(boardElement) &&
           this.applyBoardElementFilter(boardElement);
  }

  public applyCompletionStatusFilter(boardElement: BoardElement) {
    switch (this.completionStatusFilter) {
      case CompletionStatus.All:
        return true;
      case CompletionStatus.Complete:
        return this.isCompletable(boardElement) && (<Completable><unknown>boardElement).completed;
      case CompletionStatus.Incomplete:
        return this.isCompletable(boardElement) && !(<Completable><unknown>boardElement).completed ;
    }
  }

  public applyBoardElementFilter(boardElement: BoardElement): boolean {
    switch (this.boardElementsToShowFilter) {
      case BoardElementsToShow.All:
        return true;
      case BoardElementsToShow.Notes:
        return this.isNote(boardElement);
      case BoardElementsToShow.Tasks:
        return this.isTask(boardElement);
    }
  }

  private isCompletable(boardElement: BoardElement) {
    return typeof boardElement['completed'] === 'boolean';
  }

  private isTask(boardElement: any): boolean {
    return typeof boardElement['completed'] === 'boolean';
  }

  private isNote(boardElement: any): boolean {
    return typeof boardElement['completed'] === 'undefined';
  }
}
