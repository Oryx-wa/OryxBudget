import { Component, OnInit, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Operators } from './../models/operators';
import { Budgets } from './../models/budget';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnChanges {
  public name = '';
  public operatorId = '';
  public role = '';
  public operators$: Observable<Operators>;

  constructor(private _router: Router,
    private securityService: SecurityService,
    private _http: Http) {

  }

  ngOnInit() {
    console.log(this.securityService.role);
    if (this.securityService.IsAuthorized()) {
      this.name = this.securityService.name;
      this.operatorId = this.securityService.operatorId;
      this.role = this.securityService.role;
      if (this.role === 'Napims') {
        const url = this.securityService.getUrl('Operator');

        this.operators$ = this._http.get(url, {
          headers: this.securityService.getHeaders(),
          body: ''
        }).map(res => res.json());
      }

      else if (this.role === 'Operator') {
        const url = this.securityService.getUrl('Operator');

        this.operators$ = this._http.get(url, {
          headers: this.securityService.getHeaders(),
          body: ''
        }).map(res => res.json());
      }
    }
  }



  ngOnChanges(changes: any) {


  }


}
