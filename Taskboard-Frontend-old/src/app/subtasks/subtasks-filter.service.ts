import { Injectable } from '@angular/core';
import { FilterService } from '../core/filter.service';
import { Subtask } from './interfaces/subtask';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs/operators';
import { CompletionStatus } from '../core/enums/completion-status.enum';

@Injectable({
  providedIn: 'root'
})
export class SubtasksFilterService extends FilterService {

  public completionStatusFilter: CompletionStatus = CompletionStatus.All;

  public completionStatusFilterChanged: Observable<CompletionStatus>;
  protected _completionStatusFilterChangedObserver: Observer<CompletionStatus>;

  constructor() {
    super();

    this.completionStatusFilterChanged = Observable.create((observer: Observer<CompletionStatus>) => {
      this._completionStatusFilterChangedObserver = observer;
    }).pipe(share());
  }

  public onCompletionStatusChanged(completionStatus: CompletionStatus) {
    this.completionStatusFilter = completionStatus;
    if (this._completionStatusFilterChangedObserver !== undefined) {
      this._completionStatusFilterChangedObserver.next(completionStatus);
    }
  }

  public applyAllFilters(subtask: Subtask): boolean {
    return super.applyAllFilters(subtask) &&
           this.applyCompletionStatusFilter(subtask);
  }

  public applyCompletionStatusFilter(subtask: Subtask) {
    switch (this.completionStatusFilter) {
      case CompletionStatus.All:
        return true;
      case CompletionStatus.Complete:
        return subtask.completed;
      case CompletionStatus.Incomplete:
        return !subtask.completed ;
    }
  }
}
