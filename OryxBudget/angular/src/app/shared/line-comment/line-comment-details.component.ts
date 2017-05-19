import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import { Budgets, Operators, BudgetLines, LineComments } from './../../models';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { SecurityService } from './../../login/security.service';
@Component({
  selector: 'app-line-comment-details',
  templateUrl: './line-comment-details.component.html',
  styleUrls: ['./line-comment-details.component.scss']
})
export class LineCommentDetailsComponent implements OnInit {
 @Input() lineCommentForm: FormGroup;
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  operator: Operators;
  lines$: Observable<BudgetLines[]>;
  lineComments$: Observable<LineComments[]>;
  line$: Observable<BudgetLines>;
  commentSaved$: BehaviorSubject<boolean> = new BehaviorSubject(true);
  public title = 'Details';
  showDetail = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http
  ) { }

 ngOnInit() {
    console.log(this.route.snapshot.paramMap.get('id'));
    this.getOperator(this.route.snapshot.paramMap.get('id'));
    // console.log(this.route);


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
    this.commentSaved$.next(true);

  }

  getLineDetails(id: string) {
    this.showDetail = true;
    const url = this.securityService.getUrl('Budget/GetBudgetDetails');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('id', id);

    this.lines$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());
    this.commentSaved$.next(true);

  }

  getComments(line: BudgetLines) {
    const url = this.securityService.getUrl('Budget/GetLineComment');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('budgetId', line.budgetId);
    params1.append('code', line.code);

    this.lineComments$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());
    this.commentSaved$.next(false);

  }

  saveComments(comments: any) {
    const url = this.securityService.getUrl('Budget/AddLineComment');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('budgetId', comments.budgetId);
    params1.append('code', comments.code);
    console.log(JSON.stringify(comments.data));
    const ret = this._http.post(url,
      JSON.stringify(comments.data), {
        headers: this.securityService.getHeaders(),
        search: params1
      })
      .map(res => res.json())
      .subscribe();
      this.commentSaved$.next(true);




  }
}
