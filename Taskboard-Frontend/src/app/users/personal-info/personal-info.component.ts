import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../users.service';
import { UserEditData } from '../interfaces/user-edit-data';
import { User } from 'src/app/auth/interfaces/user';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit {

  public personalInfoForm: FormGroup;

  private get returnUrl() { return 'boards/list'; }

  constructor(private _usersService: UsersService,
              private _router: Router,
              private _route: ActivatedRoute) {  }

  ngOnInit() {

    this.personalInfoForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      fullName: new FormControl(null, Validators.required),
      oldPassword: new FormControl(null),
      newPassword: new FormControl(null),
      confirmNewPassword: new FormControl(null),
    }, [this.confirmPasswordValidator]);

    this._usersService.getUser().subscribe(
      this.onGetUserInfo.bind(this)
    );

  }

  private onGetUserInfo(user: User) {
    console.log(user);
    this.personalInfoForm.controls['email'].setValue(user.email);
    this.personalInfoForm.controls['fullName'].setValue(user.fullName);
  }

  private onEditUser(user: User) {
    this.onGetUserInfo(user);
  }

  public submit() {
    if (this.personalInfoForm.valid) {
      this._usersService.editUser(this.getUserEditData()).subscribe(
        this.onEditUser.bind(this)
      );
    }
  }

  public back() {
    this._router.navigate([this.returnUrl]);
  }

  public getUserEditData(): UserEditData {
    return {
      email: this.personalInfoForm.controls['email'].value,
      fullName: this.personalInfoForm.controls['fullName'].value,
      oldPassword: this.personalInfoForm.controls['oldPassword'].value,
      newPassword: this.personalInfoForm.controls['newPassword'].value
    };
  }

  private confirmPasswordValidator(group: FormGroup) {
    if (group.controls['newPassword'].value !== group.controls['confirmNewPassword'].value) {
      return  {'passwordsAreNotEqual' : true };
    }
    return null;
  }
}
