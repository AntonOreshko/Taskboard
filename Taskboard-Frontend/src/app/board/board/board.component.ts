import { Component, OnInit, OnDestroy } from '@angular/core';
import { BoardService } from '../board.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit, OnDestroy {

  constructor(private _boardService: BoardService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
