import { Component, OnInit } from '@angular/core';
import { SecurityService } from './../../login/security.service';
@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent implements OnInit {


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
