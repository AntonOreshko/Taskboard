import { Component, OnInit, Input } from '@angular/core';
import { Note } from '../interfaces/note';
import { BoardElementIconBase } from '../interfaces/board-element-icon-base';
import { Router } from '@angular/router';
import { BoardElementsService } from '../board-elements.service';

@Component({
  selector: 'app-note-icon',
  templateUrl: './note-icon.component.html',
  styleUrls: ['./note-icon.component.css']
})
export class NoteIconComponent implements OnInit, BoardElementIconBase {

  public boardElement: Note;

  constructor(private _router: Router,
              private _boardItemsService: BoardElementsService) { }

  ngOnInit() {
  }

  public edit() {
    this._router.navigate(['boards/' + this.boardElement.boardId + '/elements/notes/' + this.boardElement.id + '/edit']);
  }

  public remove() {
    this._boardItemsService.deleteNote(this.boardElement.id).subscribe(
      this.onNoteRemoved.bind(this)
    );
  }

  private onNoteRemoved(result: boolean) {
    console.log(result);
  }
}
