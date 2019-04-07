import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BoardElementsRoutingModule } from './board-elements-routing.module';

import { TaskIconComponent } from './task-icon/task-icon.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { NoteIconComponent } from './note-icon/note-icon.component';
import { NoteDetailsComponent } from './note-details/note-details.component';
import { BoardElementDirective } from './directives/board-element.directive';
import { BoardElementIconComponent } from './board-element-icon/board-element-icon.component';
import { BoardElementsListComponent } from './board-elements-list/board-elements-list.component';
import { BoardElementsMenuComponent } from './board-elements-menu/board-elements-menu.component';
import { BoardElementsPageComponent } from './board-elements-page/board-elements-page.component';


@NgModule({
  declarations: [
    BoardElementsPageComponent,
    BoardElementsMenuComponent,
    BoardElementsListComponent,
    TaskIconComponent,
    TaskDetailsComponent,
    NoteIconComponent,
    NoteDetailsComponent,
    BoardElementDirective,
    BoardElementIconComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BoardElementsRoutingModule
  ],
  entryComponents: [
    TaskIconComponent,
    NoteIconComponent
  ],
  exports: [
    BoardElementsPageComponent,
    BoardElementsMenuComponent,
    BoardElementsListComponent,
    TaskIconComponent,
    TaskDetailsComponent,
    NoteIconComponent,
    NoteDetailsComponent,
    BoardElementIconComponent,
    BoardElementDirective
  ]
})
export class BoardElementsModule { }
