import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PersonalInfoComponent } from './personal-info/personal-info.component';

const routes: Routes = [
  { path: 'personal-info', component: PersonalInfoComponent }
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
