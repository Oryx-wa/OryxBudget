import { Component, OnInit, OnChanges } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Operators } from './../models/operators';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnChanges {
  public name = '';
  public operatorId = '';
  public role = [];
  public operators$: Observable<Operators>;
  public showNapims = false;
  public showOperator = false;

  constructor(private _router: Router,
    public securityService: SecurityService,
    private _http: Http) {

  }

  ngOnInit() {
    // console.log(this.securityService.roles);

    if (this.securityService.IsAuthorized()) {
      this.name = this.securityService.name;
      this.operatorId = this.securityService.operatorId;
      this.role = this.securityService.roles;

      if (this.role.indexOf('NAPIMS') !== -1) {
        this.showNapims = true;
        const url = this.securityService.getUrl('Operator');

        this.operators$ = this._http.get(url, {
          headers: this.securityService.getHeaders(),
          body: ''
        }).map(res => res.json());
      }
      if (this.role.indexOf('Operator') !== -1) {
        this.showOperator = true;
      }
    }
  }




  ngOnChanges(changes: any) {


  }


}
