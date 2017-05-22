import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { GridOptions } from 'ag-grid/main';

import { Budgets } from './../models/budget';
import { Operators } from './../models/operators';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import { DisplayModeEnum } from './../shared/shared-enum.enum';
import { CurrencyComponent } from './../shared/renderers/currency.component';
@Component({
  selector: 'app-operator-view',
  templateUrl: './operator-view.component.html',
  styleUrls: ['./operator-view.component.scss']
})
export class OperatorViewComponent implements OnInit, OnChanges {

  public name = '';
  public operatorId = '';
  public role: any;
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;
  public data: any;
  public uploadUrl = 'Budget/UploadBudget';
  public uploadTitle = '';
  private budgetDesc = '';
  public columnDefs: any[];
  public gridOptions: GridOptions;


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
      this.role = this.securityService.roles;
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
            width: 200, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'opBudgetUSD',
            width: 140, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'opBudgetFC',
            width: 140, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      }
    ];
  }




}

function currencyRenderer(params) {
  return `{{` + params.value + ` | currency:'USD':true:'4.0-0'}}`;
}
