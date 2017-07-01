import { Component, OnInit } from '@angular/core';
import { SecurityService } from './../../login/security.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(public securityService: SecurityService) { }

  ngOnInit() {
    this.securityService.Logoff();
  }

}
