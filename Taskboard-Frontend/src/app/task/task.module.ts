import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskComponent } from './task/task.component';
import { TaskMenuComponent } from './task-menu/task-menu.component';
import { TaskIconComponent } from './task-icon/task-icon.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { TaskListComponent } from './task-list/task-list.component';
import { NoteIconComponent } from './note-icon/note-icon.component';
import { NoteDetailsComponent } from './note-details/note-details.component';

@NgModule({
  declarations: [
    TaskComponent,
    TaskMenuComponent,
    TaskIconComponent,
    TaskDetailsComponent,
    TaskListComponent,
    NoteIconComponent,
    NoteDetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TaskModule { }
