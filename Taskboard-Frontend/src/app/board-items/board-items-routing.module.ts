import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { BoardItemsPageComponent } from './board-items-page/board-items-page.component';
import { BoardItemsListComponent } from './board-items-list/board-items-list.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { NoteDetailsComponent } from './note-details/note-details.component';

const routes: Routes = [
  { path: 'boards/:boardId/elements', component: BoardItemsPageComponent, children:
    [
      { path: 'list', component: BoardItemsListComponent },
      { path: 'new/task', component: TaskDetailsComponent },
      { path: 'new/note', component: NoteDetailsComponent },
      { path: 'tasks/:taskId/edit', component: TaskDetailsComponent },
      { path: 'notes/:noteId/edit', component: NoteDetailsComponent },
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
export class BoardItemsRoutingModule { }
