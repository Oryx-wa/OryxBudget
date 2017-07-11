import { Component, OnInit } from '@angular/core';
import { SecurityService } from './../../login/security.service';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Store } from '@ngrx/store';
import { AppState, Notification, NotificationActions } from './../../redux';
@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent implements OnInit {

  notifications = [];
  constructor(public securityService: SecurityService) {


  }

  ngOnInit() {

  }

  public Login() {
    this.securityService.Authorize('');
  }

  public Logout() {

    this.securityService.Logoff();
  }



}
