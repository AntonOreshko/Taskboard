import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersRoutingModule } from './users-routing.module';

import { UserInfoComponent } from './user-info/user-info.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { UsersSearchComponent } from './users-search/users-search.component';
import { UsersSearchElementComponent } from './users-search-element/users-search-element.component';
import { UserContactsComponent } from './user-contacts/user-contacts.component';
import { UserContactsElementComponent } from './user-contacts-element/user-contacts-element.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';

@NgModule({
  declarations: [
    UserInfoComponent,
    UsersSearchComponent,
    UsersSearchElementComponent,
    UserMenuComponent,
    UserContactsComponent,
    UserContactsElementComponent,
    UserSettingsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    UsersRoutingModule
  ],
  exports: [
    UserInfoComponent,
    UsersSearchComponent,
    UsersSearchElementComponent,
    UserMenuComponent,
    UserContactsComponent,
    UserContactsElementComponent,
    UserSettingsComponent
  ]
})
export class UsersModule { }
