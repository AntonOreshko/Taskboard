import { Component, OnInit, OnDestroy, Type } from '@angular/core';
import { Task } from '../interfaces/task';
import { Note } from '../interfaces/note';
import { Subscription } from 'rxjs';
import { BoardElementsService } from '../board-elements.service';
import { ActivatedRoute } from '@angular/router';
import { TaskIconComponent } from '../task-icon/task-icon.component';
import { NoteIconComponent } from '../note-icon/note-icon.component';
import { BoardElementData } from '../interfaces/board-element-data';
import { BoardElementsFilterService } from '../board-elements-filter.service';
import { BoardElement } from '../interfaces/board-element';

@Component({
  selector: 'app-board-elements-list',
  templateUrl: './board-elements-list.component.html',
  styleUrls: ['./board-elements-list.component.css']
})
export class BoardElementsListComponent implements OnInit, OnDestroy {

  public tasks: Task[] = [];
  public notes: Note[] = [];

  private _elements: BoardElement[] = [];
  public displayedElements: BoardElement[] = [];

  private _subscriptions: Subscription[] = [];

  private _boardId: number;

  constructor(private _boardItemsService: BoardElementsService,
              private _activeRoute: ActivatedRoute,
              private _boardItemsFilterService: BoardElementsFilterService) { }

  ngOnInit() {

    this._boardId = this._activeRoute.parent.snapshot.params['boardId'];

    this._subscriptions.push(
      this._boardItemsService.taskDeleted.subscribe(this.onTaskDeleted.bind(this))
    );

    this._subscriptions.push(
      this._boardItemsService.noteDeleted.subscribe(this.onNoteDeleted.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.textFilterChanged.subscribe(
      this.onTextFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.placeToSearchFilterChanged.subscribe(
      this.onPlaceToSearchFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.displayOrderFilterChanged.subscribe(
      this.onDisplayOrderFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.displaySizeFilterChanged.subscribe(
      this.onDisplaySizeFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.completionStatusFilterChanged.subscribe(
      this.onCompletionStatusFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.boardElementsToShowFilterChanged.subscribe(
      this.onBoardElementsToShowFilterChanged.bind(this))
    );

    this._boardItemsService.getTasks(this._boardId).subscribe(
      this.onGetTasksList.bind(this)
    );

    this._boardItemsService.getNotes(this._boardId).subscribe(
      this.onGetNotesList.bind(this)
    );
  }

  public ngOnDestroy(): void {
    this._subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }

  private setDisplayedElements() {
    this.displayedElements = [];
    this._elements = [];
    this._elements.push(...this.tasks);
    this._elements.push(...this.notes);

    for (let i = 0; i < this._elements.length; i++) {
      if (this._boardItemsFilterService.applyAllFilters(this._elements[i])) {
        this.displayedElements.push(this._elements[i]);
      }
    }

    this.displayedElements = this.displayedElements.sort(this._boardItemsFilterService.getDisplayOrderFunc());
  }

  private onGetTasksList(tasks: Task[]) {
    this.tasks = tasks;
    this.setDisplayedElements();
    console.log(this.tasks);
  }

  private onGetNotesList(notes: Note[]) {
    this.notes = notes;
    this.setDisplayedElements();
    console.log(this.notes);
  }

  private onTaskDeleted() {
    this._boardItemsService.getTasks(this._boardId).subscribe(
      this.onGetTasksList.bind(this)
    );
  }

  private onNoteDeleted() {
    this._boardItemsService.getNotes(this._boardId).subscribe(
      this.onGetNotesList.bind(this)
    );
  }

  public getComponentByElement(element: BoardElement): Type<any> {
    if (this.tasks.includes(element as Task)) { return TaskIconComponent; }
    if (this.notes.includes(element as Note)) { return NoteIconComponent; }
  }

  public getBoardElementData(element: BoardElement): BoardElementData {
    return {
      componentType: this.getComponentByElement(element),
      boardElement: element
    };
  }

  private onTextFilterChanged() {
    this.setDisplayedElements();
  }

  private onPlaceToSearchFilterChanged() {
    this.setDisplayedElements();
  }

  private onDisplayOrderFilterChanged() {
    this.setDisplayedElements();
  }

  private onDisplaySizeFilterChanged() {
    this.setDisplayedElements();
  }

  private onCompletionStatusFilterChanged() {
    this.setDisplayedElements();
  }

  private onBoardElementsToShowFilterChanged() {
    this.setDisplayedElements();
  }
}
