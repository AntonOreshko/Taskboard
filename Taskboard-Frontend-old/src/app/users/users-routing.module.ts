import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserInfoComponent } from './user-info/user-info.component';
import { UsersSearchComponent } from './users-search/users-search.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { UserContactsComponent } from './user-contacts/user-contacts.component';
import { UserMenuComponent } from './user-menu/user-menu.component';

const routes: Routes = [
  { path: 'user', component: UserMenuComponent, children:
    [
      { path: 'info', component: UserInfoComponent },
      { path: 'settings', component: UserSettingsComponent },
      { path: 'contacts', component: UserContactsComponent },
      { path: 'search', component: UsersSearchComponent },
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
export class UsersRoutingModule { }
