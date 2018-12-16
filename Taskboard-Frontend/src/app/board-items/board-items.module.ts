import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardItemsPageComponent } from './board-items-page/board-items-page.component';
import { BoardItemsMenuComponent } from './board-items-menu/board-items-menu.component';
import { BoardItemsListComponent } from './board-items-list/board-items-list.component';
import { TaskIconComponent } from './task-icon/task-icon.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { NoteIconComponent } from './note-icon/note-icon.component';
import { NoteDetailsComponent } from './note-details/note-details.component';

@NgModule({
  declarations: [BoardItemsPageComponent, BoardItemsMenuComponent, BoardItemsListComponent, TaskIconComponent, TaskDetailsComponent, NoteIconComponent, NoteDetailsComponent],
  imports: [
    CommonModule
  ]
})
export class BoardItemsModule { }
