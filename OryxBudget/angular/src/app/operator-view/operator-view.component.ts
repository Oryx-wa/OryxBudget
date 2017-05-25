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
  public showSubCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showTecCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showMalCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showFinal$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public data: any;
  public uploadUrl = 'Budget/UploadBudget';
  public uploadTitle = '';
  private budgetDesc = '';
  public columnDefs: any[];
   private colWidth = 110;
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
        this.roles.map(role => {
      switch (role) {
        case 'SubCom':
          this.showSubCom$.next(true);
          break;
        case 'TecCom':
          this.showTecCom$.next(true);
          break;
        case 'MalCom':
          this.showMalCom$.next(true);
          break;
        case 'Final':
          this.showFinal$.next(true);
          break;
        default:
          break;
      }
    });
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
      }
    });

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

  saveComments(data: any) {
    const url = this.securityService.getUrl('Budget/AddLineComment');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('budgetId', data.budgetId);
    params1.append('code', data.code);
    console.log(JSON.stringify(data.data));
    const ret = this._http.post(url,
      { comments: JSON.stringify(data.data), budgetline: JSON.stringify(data.line) }, {
        headers: this.securityService.getHeaders(),
        search: params1
      })
      .map(res => res.json())
      .subscribe();
    this.commentSaved$.next(true);
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
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'opBudgetUSD',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'opBudgetFC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      },
      {
        headerName: 'Sub Commitee',
        children: [
          {
            headerName: 'Budget LC', field: 'subComBudgetLC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'subComBudgetUSD',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'subComBudgetFC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      },
      {
        headerName: 'Technical Commitee',
        children: [
          {
            headerName: 'Budget LC', field: 'tecComBudgetLC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'tecComBudgetUSD',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'tecComBudgetFC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      },
      {
        headerName: 'Management Commitee',
        children: [
          {
            headerName: 'Budget LC', field: 'malComBudgetLC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'malComBudgetUSD',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'malComBudgetFC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      },
      {
        headerName: 'Final Budget',
        children: [
          {
            headerName: 'Budget LC', field: 'finalBudgetLC',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN'
          },
          {
            headerName: 'Budget USD', field: 'finalBudgetUSD',
            width: this.colWidth, pinned: true,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
          {
            headerName: 'Budget FC', field: 'finalBudgetFC',
            width: this.colWidth, pinned: true,
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
 public showColumn(columnType: string) {
    let columns: any[] = [];
    switch (columnType) {

      case 'subCom':
        columns = ['subComBudgetLC', 'subComBudgetUSD', 'subComBudgetFC'];
        // this.gridOptions.columnApi.setColumnsVisible(columns, !this.showSubCom);
        // this.showSubCom = !this.showSubCom;
        break;
      default:
        break;

    }
  }

  private onReady() {
    // console.log('onReady');
    this.showSubCom$.subscribe(checked => {
      this.gridOptions.columnApi.setColumnsVisible(
        ['subComBudgetLC', 'subComBudgetUSD', 'subComBudgetFC'],
        checked);
      // this.gridOptions.api.sizeColumnsToFit();
    });

    this.showTecCom$.subscribe(checked => {
      this.gridOptions.columnApi.setColumnsVisible(
        ['tecComBudgetLC', 'tecComBudgetUSD', 'tecComBudgetFC'],
        checked);
      // this.gridOptions.api.sizeColumnsToFit();
    });

    this.showMalCom$.subscribe(checked => {
      this.gridOptions.columnApi.setColumnsVisible(
        ['malComBudgetLC', 'malComBudgetUSD', 'malComBudgetFC'],
        checked);
      //this.gridOptions.api.sizeColumnsToFit();
    });

    this.showFinal$.subscribe(checked => {
      this.gridOptions.columnApi.setColumnsVisible(
        ['finalBudgetLC', 'finalBudgetUSD', 'finalBudgetFC'],
        checked);
      // this.gridOptions.api.sizeColumnsToFit();
    });



    // this.gridOptions.api.sizeColumnsToFit();


  }

}

function currencyRenderer(params) {
  return `{{` + params.value + ` | currency:'USD':true:'4.0-0'}}`;
}
