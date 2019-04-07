import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BoardRoutingModule } from './board-routing.module';

import { BoardMenuComponent } from './board-menu/board-menu.component';
import { BoardIconComponent } from './board-icon/board-icon.component';
import { BoardDetailsComponent } from './board-details/board-details.component';
import { BoardsPageComponent } from './boards-page/boards-page.component';
import { BoardListComponent } from './board-list/board-list.component';


@NgModule({
  declarations: [
    BoardsPageComponent,
    BoardMenuComponent,
    BoardIconComponent,
    BoardDetailsComponent,
    BoardListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BoardRoutingModule
  ],
  exports: [
    BoardsPageComponent,
    BoardMenuComponent,
    BoardIconComponent,
    BoardDetailsComponent,
    BoardListComponent
  ]
})
export class BoardModule { }
