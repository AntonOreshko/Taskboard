import { Component, OnInit } from '@angular/core';
import { PlaceToSearch } from 'src/app/core/enums/place-to-search.enum';
import { DisplayOrder } from 'src/app/core/enums/display-order.enum';
import { DisplaySize } from 'src/app/core/enums/display-size.enum';
import { Router, ActivatedRoute } from '@angular/router';
import { SubtasksFilterService } from '../subtasks-filter.service';
import { CompletionStatus } from 'src/app/core/enums/completion-status.enum';

@Component({
  selector: 'app-subtasks-menu',
  templateUrl: './subtasks-menu.component.html',
  styleUrls: ['./subtasks-menu.component.css']
})
export class SubtasksMenuComponent implements OnInit {

  private _taskId: number;

  private _boardId: number;

  public textFilter: string;

  public placeToSearchFilter: PlaceToSearch;

  public displayOrderFilter: DisplayOrder;

  public displaySizeFilter: DisplaySize;

  public completionStatusFilter: CompletionStatus;

  constructor(private _router: Router,
              private _activeRoute: ActivatedRoute,
              private _subtasksFilterService: SubtasksFilterService) { }

  ngOnInit() {

    this._taskId = this._activeRoute.parent.snapshot.params['taskId'];
    this._boardId = this._activeRoute.parent.snapshot.params['boardId'];

    this.applyFilterValues();
  }

  public newSubtask() {
    this._router.navigate(['boards/' + this._boardId + '/elements/tasks/' + this._taskId + '/subtasks/new']);
  }

  public back() {
    this._router.navigate(['boards/' + this._boardId + '/elements/list']);
  }

  private applyFilterValues() {
    this.textFilter = this._subtasksFilterService.textFilter;
    this.placeToSearchFilter = this._subtasksFilterService.placeToSearchFilter;
    this.displayOrderFilter = this._subtasksFilterService.displayOrderFilter;
    this.displaySizeFilter = this._subtasksFilterService.displaySizeFilter;
    this.completionStatusFilter = this._subtasksFilterService.completionStatusFilter;
  }

  public textFilterChange(value: string) {
    console.log(value);
    this._subtasksFilterService.onFilterChanged(value);
  }

  public placeToSearchChanged(value: string) {
    console.log(value);
    this._subtasksFilterService.onPlaceToSearchChanged(PlaceToSearch[value]);
  }

  public displayOrderChanged(value: string) {
    console.log(value);
    this._subtasksFilterService.onDisplayOrderChanged(DisplayOrder[value]);
  }

  public displaySizeChanged(value: string) {
    console.log(value);
    this._subtasksFilterService.onDisplaySizeChanged(DisplaySize[value]);
  }

  public completionStatusChanged(value: string) {
    console.log(value);
    this._subtasksFilterService.onCompletionStatusChanged(CompletionStatus[value]);
  }
}
