import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrls: ['./board-menu.component.css']
})
export class BoardMenuComponent implements OnInit {

  constructor(private _router: Router) { }

  public newBoard() {
    this._router.navigate(['boards/new']);
  }

  ngOnInit() {
  }

}
