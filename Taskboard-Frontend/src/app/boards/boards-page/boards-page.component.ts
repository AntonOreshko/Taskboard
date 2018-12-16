import { Component, OnInit, OnDestroy } from '@angular/core';
import { BoardService } from '../board.service';

@Component({
  selector: 'app-boards-page',
  templateUrl: './boards-page.component.html',
  styleUrls: ['./boards-page.component.css']
})
export class BoardsPageComponent implements OnInit, OnDestroy {

  constructor(private _boardService: BoardService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
