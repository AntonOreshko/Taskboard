import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubtasksRoutingModule } from './subtasks-routing.module';

import { SubtasksPageComponent } from './subtasks-page/subtasks-page.component';
import { SubtasksMenuComponent } from './subtasks-menu/subtasks-menu.component';
import { SubtasksListComponent } from './subtasks-list/subtasks-list.component';
import { SubtaskIconComponent } from './subtask-icon/subtask-icon.component';
import { SubtaskDetailsComponent } from './subtask-details/subtask-details.component';

@NgModule({
  declarations: [
    SubtasksPageComponent,
    SubtasksMenuComponent,
    SubtasksListComponent,
    SubtaskIconComponent,
    SubtaskDetailsComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SubtasksRoutingModule
  ],
  exports: [
    SubtasksPageComponent,
    SubtasksMenuComponent,
    SubtasksListComponent,
    SubtaskIconComponent,
    SubtaskDetailsComponent
  ]
})
export class SubtasksModule { }
