import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { SubtasksPageComponent } from './subtasks-page/subtasks-page.component';
import { SubtasksListComponent } from './subtasks-list/subtasks-list.component';
import { SubtaskDetailsComponent } from './subtask-details/subtask-details.component';


const routes: Routes = [
  { path: 'boards/:boardId/elements/tasks/:taskId/subtasks', component: SubtasksPageComponent, children:
    [
      { path: 'list', component: SubtasksListComponent },
      { path: 'new', component: SubtaskDetailsComponent },
      { path: ':subtaskId/edit', component: SubtaskDetailsComponent },
    ]
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class SubtasksRoutingModule { }
