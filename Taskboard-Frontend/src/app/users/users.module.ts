import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersRoutingModule } from './users-routing.module';

import { PersonalInfoComponent } from './personal-info/personal-info.component';

@NgModule({
  declarations: [
    PersonalInfoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    UsersRoutingModule
  ],
  exports: [
    PersonalInfoComponent
  ]
})
export class UsersModule { }
