import { Component, OnInit, Input } from '@angular/core';
import { Subtask } from '../interfaces/subtask';
import { Router, ActivatedRoute } from '@angular/router';
import { SubtasksService } from '../subtasks.service';

@Component({
  selector: 'app-subtask-icon',
  templateUrl: './subtask-icon.component.html',
  styleUrls: ['./subtask-icon.component.css']
})
export class SubtaskIconComponent implements OnInit {

  @Input() subtask: Subtask;

  private _boardId: number;

  constructor(private _router: Router,
              private _subtasksService: SubtasksService,
              private _route: ActivatedRoute) { }

  ngOnInit() {
    this._boardId = this._route.parent.snapshot.params['boardId'];
  }

  public edit() {
    this._router.navigate(['boards/' + this._boardId + '/elements/tasks/'
      + this.subtask.taskId + '/subtasks/' + this.subtask.id + '/edit']);
  }

  public remove() {
    this._subtasksService.deleteSubtask(this.subtask.id).subscribe(
      this.onSubtaskDeleted.bind(this)
    );
  }

  private onSubtaskDeleted(result: boolean): void {
    console.log(result);
  }
}
