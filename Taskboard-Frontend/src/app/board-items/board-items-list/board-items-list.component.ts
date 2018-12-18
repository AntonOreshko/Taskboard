import { Component, OnInit, OnDestroy, Type } from '@angular/core';
import { Task } from '../interfaces/task';
import { Note } from '../interfaces/note';
import { Subscription } from 'rxjs';
import { BoardItemsService } from '../board-items.service';
import { ActivatedRoute } from '@angular/router';
import { BoardItem } from '../interfaces/board-item';
import { TaskIconComponent } from '../task-icon/task-icon.component';
import { NoteIconComponent } from '../note-icon/note-icon.component';
import { IconItemData } from '../interfaces/icon-item-data';
import { BoardItemsFilterService } from '../board-items-filter.service';
import { PlaceToSearch } from 'src/app/core/enums/PlaceToSearch';
import { DisplayOrder } from 'src/app/core/enums/DisplayOrder';
import { DisplaySize } from 'src/app/core/enums/DisplaySize';
import { BoardItemsToShow } from 'src/app/core/enums/BoardItemsToShow';

@Component({
  selector: 'app-board-items-list',
  templateUrl: './board-items-list.component.html',
  styleUrls: ['./board-items-list.component.css']
})
export class BoardItemsListComponent implements OnInit, OnDestroy {

  public tasks: Task[] = [];
  public notes: Note[] = [];

  private _items: BoardItem[] = [];
  public displayItems: BoardItem[] = [];

  private _subscriptions: Subscription[] = [];

  private _boardId: number;

  constructor(private _boardItemsService: BoardItemsService,
              private _activeRoute: ActivatedRoute,
              private _boardItemsFilterService: BoardItemsFilterService) { }

  ngOnInit() {

    this._boardId = this._activeRoute.parent.snapshot.params['id'];

    this._subscriptions.push(
      this._boardItemsService.taskDeleted.subscribe(this.onTaskDeleted.bind(this))
    );

    this._subscriptions.push(
      this._boardItemsService.noteDeleted.subscribe(this.onNoteDeleted.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.filterChanged.subscribe(
      this.onFilterChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.placeToSearchChanged.subscribe(
      this.onPlaceToSearchChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.displayOrderChanged.subscribe(
      this.onDisplayOrderChanged.bind(this))
    );

    this._subscriptions.push(this._boardItemsFilterService.displaySizeChanged.subscribe(
      this.onDisplaySizeChanged.bind(this))
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

  private setDisplayItems() {
    this.displayItems = [];
    this._items = [];
    this._items.push(...this.tasks);
    this._items.push(...this.notes);

    for (let i = 0; i < this._items.length; i++) {
      if (this._boardItemsFilterService.applyAllFilters(this._items[i])) {
        this.displayItems.push(this._items[i]);
      }
    }

    this.displayItems = this.displayItems.sort(this._boardItemsFilterService.getDisplayOrderFunc());
  }

  private onGetTasksList(tasks: Task[]) {
    this.tasks = tasks;
    this.setDisplayItems();
    console.log(this.tasks);
  }

  private onGetNotesList(notes: Note[]) {
    this.notes = notes;
    this.setDisplayItems();
    console.log(this.notes);
  }

  private onTaskDeleted(result: boolean) {
    this._boardItemsService.getTasks(this._boardId).subscribe(
      this.onGetTasksList.bind(this)
    );
  }

  private onNoteDeleted(result: boolean) {
    this._boardItemsService.getNotes(this._boardId).subscribe(
      this.onGetNotesList.bind(this)
    );
  }

  public getComponentByItem(item: BoardItem): Type<any> {
    if (this.tasks.includes(item as Task)) { return TaskIconComponent; }
    if (this.notes.includes(item as Note)) { return NoteIconComponent; }
  }

  public getIconItemData(item: BoardItem): IconItemData {
    return {
      component: this.getComponentByItem(item),
      iconItem: item
    };
  }

  private onFilterChanged(value: string) {
    this.setDisplayItems();
  }

  private onPlaceToSearchChanged(value: PlaceToSearch) {
    this.setDisplayItems();
  }

  private onDisplayOrderChanged(value: DisplayOrder) {
    this.setDisplayItems();
  }

  private onDisplaySizeChanged(value: DisplaySize) {
    this.setDisplayItems();
  }

  private onBoardItemToShowChanged(value: BoardItemsToShow) {
    this.setDisplayItems();
  }
}
