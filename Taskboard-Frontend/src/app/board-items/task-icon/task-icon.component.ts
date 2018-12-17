import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../interfaces/task';
import { BoardIcon } from '../interfaces/board-icon';
import { Router } from '@angular/router';
import { BoardItemsService } from '../board-items.service';

@Component({
  selector: 'app-task-icon',
  templateUrl: './task-icon.component.html',
  styleUrls: ['./task-icon.component.css']
})
export class TaskIconComponent implements OnInit, BoardIcon {

  public item: Task;

  constructor(private _router: Router,
              private _boardItemsService: BoardItemsService) { }

  ngOnInit() {
  }

  public open() {

  }

  public edit() {
    this._router.navigate(['boarditems/' + this.item.boardId + '/edit/task/' + this.item.id]);
  }

  public remove() {
    this._boardItemsService.deleteTask(this.item.id).subscribe(
      this.onTaskRemoved.bind(this)
    );
  }

  private onTaskRemoved(result: boolean) {
    console.log(result);
  }
}
