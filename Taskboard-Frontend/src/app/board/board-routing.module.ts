import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { BoardListComponent } from './board-list/board-list.component';
import { BoardComponent } from './board/board.component';
import { BoardDetailsComponent } from './board-details/board-details.component';

const routes: Routes = [
  { path: 'boards', component: BoardComponent, children:
    [
      { path: 'list', component: BoardListComponent },
      { path: 'new', component: BoardDetailsComponent },
      { path: 'edit', component: BoardDetailsComponent },
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
