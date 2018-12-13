import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BoardRoutingModule } from './board-routing.module';

import { BoardListComponent } from './board-list/board-list.component';
import { BoardMenuComponent } from './board-menu/board-menu.component';
import { BoardIconComponent } from './board-icon/board-icon.component';

@NgModule({
  declarations: [BoardListComponent, BoardMenuComponent, BoardIconComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BoardRoutingModule
  ],
  exports: [
    BoardListComponent,
    BoardMenuComponent,
    BoardIconComponent
  ]
})
export class BoardModule { }
