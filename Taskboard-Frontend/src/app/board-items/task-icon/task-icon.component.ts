import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../interfaces/task';
import { BoardIcon } from '../interfaces/board-icon';

@Component({
  selector: 'app-task-icon',
  templateUrl: './task-icon.component.html',
  styleUrls: ['./task-icon.component.css']
})
export class TaskIconComponent implements OnInit, BoardIcon {

  item: Task;

  constructor() {
   }

  ngOnInit() {
  }

  public open() {

  }

  public edit() {

  }

  public remove() {

  }
}
