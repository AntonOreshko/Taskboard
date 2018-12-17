import { Component, OnInit, Input } from '@angular/core';
import { Note } from '../interfaces/note';
import { BoardIcon } from '../interfaces/board-icon';

@Component({
  selector: 'app-note-icon',
  templateUrl: './note-icon.component.html',
  styleUrls: ['./note-icon.component.css']
})
export class NoteIconComponent implements OnInit, BoardIcon {

  item: Note;

  constructor() { }

  ngOnInit() {

  }

  public edit() {

  }

  public remove() {

  }
}
