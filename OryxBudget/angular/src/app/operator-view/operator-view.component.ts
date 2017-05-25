import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { GridOptions } from 'ag-grid/main';

import { Budgets, Operators, BudgetLines, LineComments } from './../models';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { SecurityService } from './../login/security.service';

import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import { DisplayModeEnum } from './../shared/shared-enum.enum';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import 'rxjs/add/operator/debounce';
@Component({
  selector: 'app-operator-view',
  templateUrl: './operator-view.component.html',
  styleUrls: ['./operator-view.component.scss']
})
export class OperatorViewComponent implements OnInit, OnChanges {

  public name = '';
  public operatorId = '';
  public roles: any[] = [];
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  lines$: Observable<BudgetLines[]>;
  lineComments$: Observable<LineComments[]>;
  line$: Observable<BudgetLines>;
  commentSaved$: BehaviorSubject<boolean> = new BehaviorSubject(true);
  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;
  public data: any;
  public uploadUrl = 'Budget/UploadBudget';
  public uploadTitle = '';
  private budgetDesc = '';
  public columnDefs: any[];
  public gridOptions: GridOptions;
  showDetail = false;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http) {
    this.gridOptions = <GridOptions>{};
    this.createColumnDefs();

  }

  ngOnInit() {
    if (this.securityService.IsAuthorized()) {
      this.name = this.securityService.name;
      this.operatorId = this.securityService.operatorId;
      this.roles = this.securityService.roles;
      console.log(this.roles)
      this.getOperator();
    }
  }

  ngOnChanges(changes: any) {

  }

  getOperator() {


    let url = this.securityService.getUrl('Budget/GetByOperator');
    let params: URLSearchParams = new URLSearchParams();
    params.append('operatorId', this.operatorId);

    this.budgets$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params
    }).map(res => res.json());

    url = this.securityService.getUrl('Operator/GetById');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('id', this.operatorId);

    this.operator$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());
    //this.budgets$.subscribe(b => console.log(b));
    this.budgets$.subscribe(budgets => {
      if (budgets) {
        this.budgetDesc = budgets[0].description;
        this.getLineDetails(budgets[0].id);
        this.upload(budgets[0].id,budgets[0].description )
      }
    });

    

    

  }

  changeDisplayMode(mode: DisplayModeEnum) {
    // console.log(mode); 
    this.displayMode = mode;
  }

  upload(id: string, description: string) {
    this.data = { id: id };
    this.changeDisplayMode(this.displayModeEnum.Upload);
    this.budgetDesc = description;
    this.uploadTitle = 'Upload Budget for ' + this.budgetDesc;
  }

  setUploadType(type: string) {
    if (type === 'Budget') {
      // this.changeDisplayMode(this.displayModeEnum.Budget);
      this.uploadUrl = 'Budget/UploadBudget';
      this.uploadTitle = 'Upload Budget for ' + this.budgetDesc;
    } else {
      // this.changeDisplayMode(this.displayModeEnum.Actual);
      this.uploadUrl = 'Budget/UploadActual';
      this.uploadTitle = 'Upload Actual for ' + this.budgetDesc;
    }
  }

  showDetails(id: string) {
    this.changeDisplayMode(this.displayModeEnum.Details);
  }

  private createColumnDefs() {
    this.columnDefs = [

      {
        headerName: 'Operator Budget',
        children: [
          {
            headerName: 'Budget LC', field: 'opBudgetLC',
            width: 140, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'opBudgetUSD',
            width: 120, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'opBudgetFC',
            width: 120, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      }
    ];
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


}

function currencyRenderer(params) {
  return `{{` + params.value + ` | currency:'USD':true:'4.0-0'}}`;
}
