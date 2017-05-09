
import { Component, OnInit } from '@angular/core';
import { SecurityService } from './login/security.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title: string = 'Budget';


  constructor(public securityService: SecurityService) {
  }

  ngOnInit() {
    if (window.location.hash) {
      this.securityService.AuthorizedCallback();
    }
  }

  public Login() {
    this.securityService.Authorize('');
  }

  logOut() {
    this.securityService.Logoff();
  }
}
