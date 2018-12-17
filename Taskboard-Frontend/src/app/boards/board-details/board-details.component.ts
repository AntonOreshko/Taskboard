import { Component, OnInit } from '@angular/core';
import { BoardService } from '../board.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BoardNewData } from '../interfaces/board-new-data';
import { BoardEditData } from '../interfaces/board-edit-data';
import { Board } from '../interfaces/board';

@Component({
  selector: 'app-board-details',
  templateUrl: './board-details.component.html',
  styleUrls: ['./board-details.component.css']
})
export class BoardDetailsComponent implements OnInit {

  public boardDetailsForm: FormGroup;

  private _boardId: number;

  private _mode: string;

  private get returnUrl() { return 'boards/list'; }

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

    if (this._boardId !== undefined) {
      this._mode = 'edit';
      this._boardService.getBoard(this._boardId).subscribe(
        this.onGetBoard.bind(this)
      );
    }
  }

  private onGetBoard(board: Board) {
    this.boardDetailsForm.controls['name'].setValue(board.name);
    this.boardDetailsForm.controls['description'].setValue(board.description);
  }

  private onCreateBoard() {
    this._router.navigate([this.returnUrl]);
  }

  private onEditBoard() {
    this._router.navigate([this.returnUrl]);
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
    this._boardService.newBoard(this.getBoardNewData()).subscribe(
      this.onCreateBoard.bind(this)
    );
  }

  public editBoard() {
    this._boardService.editBoard(this.getBoardEditData()).subscribe(
      this.onEditBoard.bind(this)
    );
  }

  public back() {
    this._router.navigate([this.returnUrl]);
  }

  public getBoardNewData(): BoardNewData {
    return {
      name: this.boardDetailsForm.controls['name'].value,
      description: this.boardDetailsForm.controls['description'].value
    };
  }

  public getBoardEditData(): BoardEditData {
    return {
      id: this._boardId,
      name: this.boardDetailsForm.controls['name'].value,
      description: this.boardDetailsForm.controls['description'].value
    };
  }
}
