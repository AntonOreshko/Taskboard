import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  constructor(private _authService: AuthService,
              private _router: Router) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  public isAuthenticated(): boolean {
    return this._authService.isAuthenticated();
  }

  public logout(): void {
    this._authService.logout();
    this._router.navigate(['login']);
  }

  public personalInfo() {
    this._router.navigate(['personal-info']);
  }
}
