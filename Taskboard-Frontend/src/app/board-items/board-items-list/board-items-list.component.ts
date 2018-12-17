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

@Component({
  selector: 'app-board-items-list',
  templateUrl: './board-items-list.component.html',
  styleUrls: ['./board-items-list.component.css']
})
export class BoardItemsListComponent implements OnInit, OnDestroy {

  public tasks: Task[] = [];
  public notes: Note[] = [];

  public items: BoardItem[];

  private _subscriptions: Subscription[] = [];

  private _boardId: number;

  constructor(private _boardItemsService: BoardItemsService,
              private _activeRoute: ActivatedRoute) { }

  ngOnInit() {

    this._boardId = this._activeRoute.parent.snapshot.params['id'];

    // subscribe on events
    this._subscriptions.push(
      this._boardItemsService.taskDeleted.subscribe(this.onTaskDeleted.bind(this))
    );

    this._subscriptions.push(
      this._boardItemsService.noteDeleted.subscribe(this.onNoteDeleted.bind(this))
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

  private buildItemsList() {
    this.items = [];
    this.items.push(...this.tasks);
    this.items.push(...this.notes);
    this.items = this.items.sort((i1: BoardItem, i2: BoardItem) => {
      if (i1.created > i2.created) { return 1; }
      if (i2.created > i1.created) { return -1; }
      return 0;
    });
  }

  private onGetTasksList(tasks: Task[]) {
    this.tasks = tasks;
    this.buildItemsList();
    console.log(this.tasks);
  }

  private onGetNotesList(notes: Note[]) {
    this.notes = notes;
    this.buildItemsList();
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
}
