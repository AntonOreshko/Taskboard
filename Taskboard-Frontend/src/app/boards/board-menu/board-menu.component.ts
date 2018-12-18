import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BoardFilterService } from '../board-filter.service';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrls: ['./board-menu.component.css']
})
export class BoardMenuComponent implements OnInit {

  public textFilter: string;

  constructor(private _router: Router,
              private _boardFilterService: BoardFilterService) { }

  public newBoard() {
    this._router.navigate(['boards/new']);
  }

  ngOnInit() {
    this.applyFilterValues();
  }

  private applyFilterValues() {
    this.textFilter = this._boardFilterService.filter;
  }

  public onSearchChange(value: string) {
    console.log(value);
    this._boardFilterService.onFilterChanged(value);
  }
}
