import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../interfaces/task';
import { BoardElementIconBase } from '../interfaces/board-element-icon-base';
import { Router } from '@angular/router';
import { BoardElementsService } from '../board-elements.service';

@Component({
  selector: 'app-task-icon',
  templateUrl: './task-icon.component.html',
  styleUrls: ['./task-icon.component.css']
})
export class TaskIconComponent implements OnInit, BoardElementIconBase {

  public boardElement: Task;

  constructor(private _router: Router,
              private _boardItemsService: BoardElementsService) { }

  ngOnInit() {
  }

  public open() {
    this._router.navigate(['boards/' + this.boardElement.boardId + '/elements/tasks/' + this.boardElement.id + '/subtasks/list']);
  }

  public edit() {
    this._router.navigate(['boards/' + this.boardElement.boardId + '/elements/tasks/' + this.boardElement.id + '/edit']);
  }

  public remove() {
    this._boardItemsService.deleteTask(this.boardElement.id).subscribe(
      this.onTaskRemoved.bind(this)
    );
  }

  private onTaskRemoved(result: boolean) {
    console.log(result);
  }
}
