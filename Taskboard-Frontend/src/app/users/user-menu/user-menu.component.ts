import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent implements OnInit {

  constructor(private _router: Router) { }

  ngOnInit() {
  }

  public info(): void {
    this._router.navigate(['user', 'info']);
  }

  public settings(): void {
    this._router.navigate(['user', 'settings']);
  }

  public contacts(): void {
    this._router.navigate(['user', 'contacts']);
  }

  public search(): void {
    this._router.navigate(['user', 'search']);
  }

  public back() {
    this._router.navigate(['boards', 'list']);
  }
}
