import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BoardItemsService } from '../board-items.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Task } from '../interfaces/task';
import { TaskNewData } from '../interfaces/task-new-data';
import { TaskEditData } from '../interfaces/task-edit-data';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})
export class TaskDetailsComponent implements OnInit {

  public taskDetailsForm: FormGroup;

  private _taskId: number;

  private _boardId: number;

  private _mode: string;

  private get returnUrl() { return 'boarditems/' + this._boardId + '/list'; }

  constructor(private _boardItemsService: BoardItemsService,
              private _router: Router,
              private _route: ActivatedRoute) { }

  ngOnInit() {
    this.taskDetailsForm =  new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null),
    });

    this._mode = 'new';
    this._taskId = this._route.snapshot.params['id'];
    this._boardId = this._route.parent.snapshot.params['id'];

    if (this._taskId !== undefined) {
      this._mode = 'edit';
      this._boardItemsService.getTask(this._taskId).subscribe(
        this.onGetTask.bind(this)
      );
    }
  }

  private onGetTask(task: Task) {
    this.taskDetailsForm.controls['name'].setValue(task.name);
    this.taskDetailsForm.controls['description'].setValue(task.description);
  }

  private onCreateTask() {
    this._router.navigate([this.returnUrl]);
  }

  private onEditTask() {
    this._router.navigate([this.returnUrl]);
  }

  public submit() {
    if (this.taskDetailsForm.valid) {
      switch (this._mode) {
        case 'new':
          this.createTask();
          break;
        case 'edit':
          this.editTask();
          break;
      }
    }
  }

  public createTask() {
    this._boardItemsService.newTask(this.getTaskNewData()).subscribe(
      this.onCreateTask.bind(this)
    );
  }

  public editTask() {
    this._boardItemsService.editTask(this.getTaskEditData()).subscribe(
      this.onEditTask.bind(this)
    );
  }

  public back() {
    this._router.navigate([this.returnUrl]);
  }

  public getTaskNewData(): TaskNewData {
    return {
      boardId: this._boardId,
      name: this.taskDetailsForm.controls['name'].value,
      description: this.taskDetailsForm.controls['description'].value
    };
  }

  public getTaskEditData(): TaskEditData {
    return {
      id: this._taskId,
      name: this.taskDetailsForm.controls['name'].value,
      description: this.taskDetailsForm.controls['description'].value
    };
  }
}
