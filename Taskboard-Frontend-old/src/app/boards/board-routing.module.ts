import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';


import { BoardDetailsComponent } from './board-details/board-details.component';
import { BoardsPageComponent } from './boards-page/boards-page.component';
import { BoardListComponent } from './board-list/board-list.component';

const routes: Routes = [
  { path: 'boards', component: BoardsPageComponent, children:
    [
      { path: 'list', component: BoardListComponent },
      { path: 'new', component: BoardDetailsComponent },
      { path: ':boardId/edit', component: BoardDetailsComponent },
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
export class BoardRoutingModule { }
