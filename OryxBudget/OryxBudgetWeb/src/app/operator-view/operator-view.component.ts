import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Budgets } from './../models/budget';
import { Operators } from './../models/operators';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';

@Component({
  selector: 'app-operator-view',
  templateUrl: './operator-view.component.html',
  styleUrls: ['./operator-view.component.scss']
})
export class OperatorViewComponent implements OnInit {
  @Input() operatorid = '';
  @Input() budgets: Budgets[] = [];
  public name = '';
  public operatorId = '';
  public role = '';
  budgets$: Observable<Budgets>;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http) {

  }

  ngOnInit() {
    if (this.securityService.IsAuthorized()) {
      this.name = this.securityService.name;
      this.operatorId = this.securityService.operatorId;
      this.role = this.securityService.role; 
      this.getOperator(this.route.snapshot.paramMap.get('id'));  
    }
  }

  getOperator(id: string) {

    if (this.role === 'Operator') {
      const url = this.securityService.getUrl('Budget/GetByOperator');
      let params: URLSearchParams = new URLSearchParams();
      params.append('operatorId', id);

      this.budgets$ = this._http.get(url, {
        headers: this.securityService.getHeaders(),
        body: '',
        params: params
      }).map(res => res.json());

      this.budgets$.subscribe(b => console.log(b));
    }

  }

}