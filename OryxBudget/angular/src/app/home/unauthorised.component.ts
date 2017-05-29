import { Component, OnInit } from '@angular/core';
import { SecurityService } from './../login/security.service';
@Component({
  selector: 'app-unauthorised',
  templateUrl: './unauthorised.component.html',
  styleUrls: ['./unauthorised.component.scss']
})
export class UnauthorisedComponent implements OnInit {

  constructor(
    public securityService: SecurityService,
  ) {

  }
  ngOnInit() {
  }

  public login() {
    this.securityService.Authorize('');
  }

}
