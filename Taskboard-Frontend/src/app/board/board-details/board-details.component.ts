import { Component, OnInit } from '@angular/core';
import { BoardService } from '../board.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BoardNewData } from '../interfaces/board-new-data';

@Component({
  selector: 'app-board-details',
  templateUrl: './board-details.component.html',
  styleUrls: ['./board-details.component.css']
})
export class BoardDetailsComponent implements OnInit {

  boardDetailsForm: FormGroup;

  constructor(private _boardService: BoardService,
              private _router: Router) {

  }

  ngOnInit() {
    this.boardDetailsForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null),
    });
  }

  public createBoard() {
    if (this.boardDetailsForm.valid) {
      this._boardService.newBoard(this.getBoardNewData())
        .subscribe(
          response => {
            this._router.navigate(['boards/list']);
          },
          error => {

          }
        );
    }
  }

  public getBoardNewData(): BoardNewData {
    return {
      name: this.boardDetailsForm.controls['name'].value,
      description: this.boardDetailsForm.controls['description'].value
    };
  }
}
