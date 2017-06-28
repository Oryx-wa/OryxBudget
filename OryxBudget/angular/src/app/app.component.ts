
import { Component, OnInit } from '@angular/core';
import { SecurityService } from './login/security.service';
import {LicenseManager} from 'ag-grid-enterprise/main';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Budget';


  constructor(public securityService: SecurityService) {
    LicenseManager
    .setLicenseKey('ag-Grid_Evaluation_License_Not_for_Production_100Devs19_July_2017__MTUwMDQxODgwMDAwMA==c8fa1c094c7bd76cddf4297f92d5f8da');
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
