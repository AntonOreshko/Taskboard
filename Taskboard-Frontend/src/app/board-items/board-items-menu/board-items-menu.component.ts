import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-board-items-menu',
  templateUrl: './board-items-menu.component.html',
  styleUrls: ['./board-items-menu.component.css']
})
export class BoardItemsMenuComponent implements OnInit {

  private _boardId: number;

  constructor(private _router: Router,
              private _activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this._boardId = this._activeRoute.parent.snapshot.params['id'];
  }

  public newTask() {
    this._router.navigate(['boarditems/' + this._boardId + '/new/task']);
  }

  public newNote() {
    this._router.navigate(['boarditems/' + this._boardId + '/new/note']);
  }

  public back() {
    this._router.navigate(['boards/list']);
  }
}
