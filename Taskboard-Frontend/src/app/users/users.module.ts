import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersRoutingModule } from './users-routing.module';

import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { FindUsersComponent } from './find-users/find-users.component';
import { FindUserElementComponent } from './find-user-element/find-user-element.component';

@NgModule({
  declarations: [
    PersonalInfoComponent,
    FindUsersComponent,
    FindUserElementComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    UsersRoutingModule
  ],
  exports: [
    PersonalInfoComponent,
    FindUsersComponent,
    FindUserElementComponent
  ]
})
export class UsersModule { }
