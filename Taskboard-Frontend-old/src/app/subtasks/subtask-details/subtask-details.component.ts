import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { SubtasksService } from '../subtasks.service';
import { Subtask } from '../interfaces/subtask';
import { SubtaskNewData } from '../interfaces/subtask-new-data';
import { SubtaskEditData } from '../interfaces/subtask-edit-data';

@Component({
  selector: 'app-subtask-details',
  templateUrl: './subtask-details.component.html',
  styleUrls: ['./subtask-details.component.css']
})
export class SubtaskDetailsComponent implements OnInit {

  public subtaskDetailsForm: FormGroup;

  private _id: number;

  private _taskId: number;

  private _boardId: number;

  private _mode: string;

  private get returnUrl() { return 'boards/' + this._boardId + '/elements/tasks/' + this._taskId + '/subtasks/list'; }

  constructor(private _subtasksService: SubtasksService,
              private _router: Router,
              private _route: ActivatedRoute) {  }

  ngOnInit() {

    this.subtaskDetailsForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null),
    });

    this._mode = 'new';
    this._id = this._route.snapshot.params['subtaskId'];
    this._taskId = this._route.parent.snapshot.params['taskId'];
    this._boardId = this._route.parent.snapshot.params['boardId'];

    if (this._id !== undefined) {
      this._mode = 'edit';
      this._subtasksService.getSubtask(this._id).subscribe(
        this.onGetSubtask.bind(this)
      );
    }
  }

  private onGetSubtask(subtask: Subtask) {
    this.subtaskDetailsForm.controls['name'].setValue(subtask.name);
    this.subtaskDetailsForm.controls['description'].setValue(subtask.description);
  }

  private onCreateSubtask() {
    this._router.navigate([this.returnUrl]);
  }

  private onEditSubtask() {
    this._router.navigate([this.returnUrl]);
  }

  public submit() {
    if (this.subtaskDetailsForm.valid) {
      switch (this._mode) {
        case 'new':
          this.createSubtask();
          break;
        case 'edit':
          this.editSubtask();
          break;
      }
    }
  }

  public createSubtask() {
    this._subtasksService.newSubtask(this.getSubtaskNewData()).subscribe(
      this.onCreateSubtask.bind(this)
    );
  }

  public editSubtask() {
    this._subtasksService.editSubtask(this.getSubtaskEditData()).subscribe(
      this.onEditSubtask.bind(this)
    );
  }

  public back() {
    this._router.navigate([this.returnUrl]);
  }

  public getSubtaskNewData(): SubtaskNewData {
    return {
      taskId: this._taskId,
      name: this.subtaskDetailsForm.controls['name'].value,
      description: this.subtaskDetailsForm.controls['description'].value
    };
  }

  public getSubtaskEditData(): SubtaskEditData {
    return {
      id: this._id,
      name: this.subtaskDetailsForm.controls['name'].value,
      description: this.subtaskDetailsForm.controls['description'].value
    };
  }
}
