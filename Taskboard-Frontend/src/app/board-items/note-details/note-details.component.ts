import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BoardItemsService } from '../board-items.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Note } from '../interfaces/note';
import { NoteNewData } from '../interfaces/note-new-data';
import { NoteEditData } from '../interfaces/note-edit-data';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrls: ['./note-details.component.css']
})
export class NoteDetailsComponent implements OnInit {

  public noteDetailsForm: FormGroup;

  private _noteId: number;

  private _boardId: number;

  private _mode: string;

  private get returnUrl() { return 'boards/' + this._boardId + '/elements/list'; }

  constructor(private _boardItemsService: BoardItemsService,
    private _router: Router,
    private _route: ActivatedRoute) { }

  ngOnInit() {
    this.noteDetailsForm =  new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null),
    });

    this._mode = 'new';
    this._noteId = this._route.snapshot.params['noteId'];
    this._boardId = this._route.parent.snapshot.params['boardId'];

    if (this._noteId !== undefined) {
      this._mode = 'edit';
      this._boardItemsService.getNote(this._noteId).subscribe(
        this.onGetNote.bind(this)
      );
    }
  }

  private onGetNote(note: Note) {
    this.noteDetailsForm.controls['name'].setValue(note.name);
    this.noteDetailsForm.controls['description'].setValue(note.description);
  }

  private onCreateNote() {
    this._router.navigate([this.returnUrl]);
  }

  private onEditNote() {
    this._router.navigate([this.returnUrl]);
  }

  public submit() {
    if (this.noteDetailsForm.valid) {
      switch (this._mode) {
        case 'new':
          this.createNote();
          break;
        case 'edit':
          this.editNote();
          break;
      }
    }
  }

  public createNote() {
    this._boardItemsService.newNote(this.getNoteNewData()).subscribe(
      this.onCreateNote.bind(this)
    );
  }

  public editNote() {
    this._boardItemsService.editNote(this.getNoteEditData()).subscribe(
      this.onEditNote.bind(this)
    );
  }

  public back() {
    this._router.navigate([this.returnUrl]);
  }

  public getNoteNewData(): NoteNewData {
    return {
      boardId: this._boardId,
      name: this.noteDetailsForm.controls['name'].value,
      description: this.noteDetailsForm.controls['description'].value
    };
  }

  public getNoteEditData(): NoteEditData {
    return {
      id: this._noteId,
      name: this.noteDetailsForm.controls['name'].value,
      description: this.noteDetailsForm.controls['description'].value
    };
  }
}
