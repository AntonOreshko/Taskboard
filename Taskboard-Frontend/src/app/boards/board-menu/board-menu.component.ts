import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BoardFilterService } from '../board-filter.service';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrls: ['./board-menu.component.css']
})
export class BoardMenuComponent implements OnInit {

  constructor(private _router: Router,
              private _boardFilterService: BoardFilterService) { }

  public newBoard() {
    this._router.navigate(['boards/new']);
  }

  ngOnInit() {

  }

  public onSearchChange(value: string) {
    console.log(value);
    this._boardFilterService.onFilterChanged(value);
  }
}
