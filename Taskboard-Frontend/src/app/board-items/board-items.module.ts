import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BoardItemsRoutingModule } from './board-items-routing.module';

import { BoardItemsPageComponent } from './board-items-page/board-items-page.component';
import { BoardItemsMenuComponent } from './board-items-menu/board-items-menu.component';
import { BoardItemsListComponent } from './board-items-list/board-items-list.component';
import { TaskIconComponent } from './task-icon/task-icon.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { NoteIconComponent } from './note-icon/note-icon.component';
import { NoteDetailsComponent } from './note-details/note-details.component';
import { BoardItemDirective } from './directives/board-item.directive';
import { BoardItemIconComponent } from './board-item-icon/board-item-icon.component';

@NgModule({
  declarations: [
    BoardItemsPageComponent,
    BoardItemsMenuComponent,
    BoardItemsListComponent,
    TaskIconComponent,
    TaskDetailsComponent,
    NoteIconComponent,
    NoteDetailsComponent,
    BoardItemDirective,
    BoardItemIconComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BoardItemsRoutingModule
  ],
  entryComponents: [
    TaskIconComponent,
    NoteIconComponent
  ],
  exports: [
    BoardItemsPageComponent,
    BoardItemsMenuComponent,
    BoardItemsListComponent,
    TaskIconComponent,
    TaskDetailsComponent,
    NoteIconComponent,
    NoteDetailsComponent,
    BoardItemIconComponent,
    BoardItemDirective
  ]
})
export class BoardItemsModule { }
