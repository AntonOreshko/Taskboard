import { Component, OnInit, Input } from '@angular/core';
import { UserWithContactStatus } from '../interfaces/user-with-contact-status';
import { UsersService } from '../users.service';
import { AuthService } from 'src/app/auth/auth.service';
import { ContactRequest } from '../interfaces/contact-request';

@Component({
  selector: 'app-users-search-element',
  templateUrl: './users-search-element.component.html',
  styleUrls: ['./users-search-element.component.css']
})
export class UsersSearchElementComponent implements OnInit {

  @Input() user: UserWithContactStatus;

  private _contactRequestId: number;

  constructor(private _usersService: UsersService,
              private _authService: AuthService) { }

  ngOnInit() {

  }

  public invite(): void {
    const contactRequestNewData = {
      senderId: this._authService.getUser().id,
      receiverId: this.user.id
    };
    this._usersService.inviteUser(contactRequestNewData).subscribe(
      this.onInvitationSent.bind(this)
    );
  }

  public get cancel(): number {
    return null;
  }

  public accept(): void {

  }

  public reject(): void {

  }

  public remove(): void {

  }

  public isContact(): boolean {
    return this.user.contactStatus === 'Contact';
  }

  public isContactRequestSent(): boolean {
    return this.user.contactStatus === 'RequestSent';
  }

  public isContactRequestReceived(): boolean {
    return this.user.contactStatus === 'RequestReceived';
  }

  public isMissing(): boolean {
    return this.user.contactStatus === 'Missing';
  }

  private onInvitationSent(contactRequest: ContactRequest) {
    this.user.contactStatus = 'RequestSent';
    this._contactRequestId = contactRequest.id;
  }
}
