import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import { Budgets, Operators } from './../models';
import { Observable } from 'rxjs';
import { SecurityService } from './../login/security.service';
@Component({
  selector: 'app-operator-details',
  templateUrl: './operator-details.component.html',
  styleUrls: ['./operator-details.component.scss']
})
export class OperatorDetailsComponent implements OnInit {
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  operator: Operators;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http
  ) { }

  ngOnInit() {
    console.log(this.route.snapshot.paramMap.get('id'));
    this.getOperator(this.route.snapshot.paramMap.get('id'));
    //console.log(this.route);

  }

  getOperator(id: string) {
    let url = this.securityService.getUrl('Budget/GetByOperator');
    const params: URLSearchParams = new URLSearchParams();
    params.append('operatorId', id);

    this.budgets$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params
    }).map(res => res.json());

    url = this.securityService.getUrl('Operator/GetById');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('id', id);

    this.operator$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());

    this.operator$.subscribe(operator => this.operator = operator);


    

  }

}
