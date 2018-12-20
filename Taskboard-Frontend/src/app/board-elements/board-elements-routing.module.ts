import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { TaskDetailsComponent } from './task-details/task-details.component';
import { NoteDetailsComponent } from './note-details/note-details.component';
import { BoardElementsListComponent } from './board-elements-list/board-elements-list.component';
import { BoardElementsPageComponent } from './board-elements-page/board-elements-page.component';

const routes: Routes = [
  { path: 'boards/:boardId/elements', component: BoardElementsPageComponent, children:
    [
      { path: 'list', component: BoardElementsListComponent },
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
export class BoardElementsRoutingModule { }
