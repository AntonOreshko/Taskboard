import { Component, OnInit } from '@angular/core';
import { BoardService } from '../board.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BoardNewData } from '../interfaces/board-new-data';
import { BoardEditData } from '../interfaces/board-edit-data';

@Component({
  selector: 'app-board-details',
  templateUrl: './board-details.component.html',
  styleUrls: ['./board-details.component.css']
})
export class BoardDetailsComponent implements OnInit {

  boardDetailsForm: FormGroup;

  private _boardId: number;

  private _mode: string;

  constructor(private _boardService: BoardService,
              private _router: Router,
              private _route: ActivatedRoute) {  }

  ngOnInit() {

    this.boardDetailsForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null),
    });

    this._mode = 'new';
    this._boardId = this._route.snapshot.params['id'];

    if (this._boardId !== undefined
        && this._boardId !== NaN
        && this._boardId !== null) {
      this._mode = 'edit';
      this._boardService.getBoard(this._boardId)
        .subscribe(
          response => {
            this.boardDetailsForm.controls['name'].setValue(response.name);
            this.boardDetailsForm.controls['description'].setValue(response.description);
          },
          error => {

          }
        );
    }
  }

  public submit() {
    if (this.boardDetailsForm.valid) {
      switch (this._mode) {
        case 'new':
          this.createBoard();
          break;
        case 'edit':
          this.editBoard();
          break;
      }
    }
  }

  public createBoard() {
    this._boardService.newBoard(this.getBoardNewData())
    .subscribe(
      response => {
        this._router.navigate(['boards/list']);
      },
      error => {

      }
    );
  }

  public editBoard() {
    this._boardService.editBoard(this._boardId, this.getBoardEditData())
    .subscribe(
      response => {
        this._router.navigate(['boards/list']);
      },
      error => {

      }
    );
  }

  public back() {
    this._router.navigate(['boards/list']);
  }

  public getBoardNewData(): BoardNewData {
    return {
      name: this.boardDetailsForm.controls['name'].value,
      description: this.boardDetailsForm.controls['description'].value
    };
  }

  public getBoardEditData(): BoardEditData {
    return {
      name: this.boardDetailsForm.controls['name'].value,
      description: this.boardDetailsForm.controls['description'].value
    };
  }
}
