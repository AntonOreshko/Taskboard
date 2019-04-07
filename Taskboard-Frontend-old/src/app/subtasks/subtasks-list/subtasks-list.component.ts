import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subtask } from '../interfaces/subtask';
import { Subscription } from 'rxjs';
import { SubtasksService } from '../subtasks.service';
import { SubtasksFilterService } from '../subtasks-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/place-to-search.enum';
import { DisplayOrder } from 'src/app/core/enums/display-order.enum';
import { DisplaySize } from 'src/app/core/enums/display-size.enum';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-subtasks-list',
  templateUrl: './subtasks-list.component.html',
  styleUrls: ['./subtasks-list.component.css']
})
export class SubtasksListComponent implements OnInit, OnDestroy {

  private _subtasks: Subtask[] = [];

  public displayedSubtasks: Subtask[] = [];

  private _subscriptions: Subscription[] = [];

  private _taskId: number;

  constructor(private _subtasksService: SubtasksService,
              private _activeRoute: ActivatedRoute,
              private _subtasksFilterService: SubtasksFilterService) { }

  public ngOnInit() {

    this._taskId = this._activeRoute.parent.snapshot.params['taskId'];

    this._subscriptions.push(this._subtasksService.subtaskDeleted.subscribe(
      this.onSubtaskDeleted.bind(this))
    );

    this._subscriptions.push(this._subtasksFilterService.textFilterChanged.subscribe(
      this.onTextFilterChanged.bind(this))
    );

    this._subscriptions.push(this._subtasksFilterService.placeToSearchFilterChanged.subscribe(
      this.onPlaceToSearchChanged.bind(this))
    );

    this._subscriptions.push(this._subtasksFilterService.displayOrderFilterChanged.subscribe(
      this.onDisplayOrderChanged.bind(this))
    );

    this._subscriptions.push(this._subtasksFilterService.displaySizeFilterChanged.subscribe(
      this.onDisplaySizeChanged.bind(this))
    );

    this._subscriptions.push(this._subtasksFilterService.completionStatusFilterChanged.subscribe(
      this.onCompletionStatusFilterChanged.bind(this))
    );

    this._subscriptions.push(this._subtasksService.getSubtasks(this._taskId).subscribe(
      this.onGetSubtasksList.bind(this))
    );
  }

  public ngOnDestroy(): void {
    this._subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }

  private onGetSubtasksList(subtasks: Subtask[]) {
    this._subtasks = subtasks;
    console.log(this._subtasks);
    this.setDisplayedSubtasks();
  }

  private onSubtaskDeleted() {
    this._subtasksService.getSubtasks(this._taskId).subscribe(
      this.onGetSubtasksList.bind(this)
    );
  }

  public setDisplayedSubtasks() {

    this.displayedSubtasks = [];

    for (let i = 0; i < this._subtasks.length; i++) {
      if (this._subtasksFilterService.applyAllFilters(this._subtasks[i])) {
        this.displayedSubtasks.push(this._subtasks[i]);
      }
    }

    this.displayedSubtasks = this.displayedSubtasks.sort(this._subtasksFilterService.getDisplayOrderFunc());
  }

  private onTextFilterChanged() {
    this.setDisplayedSubtasks();
  }

  private onPlaceToSearchChanged() {
    this.setDisplayedSubtasks();
  }

  private onDisplayOrderChanged() {
    this.setDisplayedSubtasks();
  }

  private onDisplaySizeChanged() {
    this.setDisplayedSubtasks();
  }

  private onCompletionStatusFilterChanged() {
    this.setDisplayedSubtasks();
  }
}
