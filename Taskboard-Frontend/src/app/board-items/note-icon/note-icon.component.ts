import { Component, OnInit, Input } from '@angular/core';
import { Note } from '../interfaces/note';
import { BoardIcon } from '../interfaces/board-icon';
import { Router } from '@angular/router';
import { BoardItemsService } from '../board-items.service';

@Component({
  selector: 'app-note-icon',
  templateUrl: './note-icon.component.html',
  styleUrls: ['./note-icon.component.css']
})
export class NoteIconComponent implements OnInit, BoardIcon {

  public item: Note;

  constructor(private _router: Router,
              private _boardItemsService: BoardItemsService) { }

  ngOnInit() {
  }

  public edit() {
    this._router.navigate(['boarditems/' + this.item.boardId + '/edit/note/' + this.item.id]);
  }

  public remove() {
    this._boardItemsService.deleteNote(this.item.id).subscribe(
      this.onNoteRemoved.bind(this)
    );
  }

  private onNoteRemoved(result: boolean) {
    console.log(result);
  }
}
