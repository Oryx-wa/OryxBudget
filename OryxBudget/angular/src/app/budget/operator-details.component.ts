import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import { GridOptions } from 'ag-grid/main';
import { Budgets, Operators, BudgetLines, LineComments } from './../models';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { SecurityService } from './../login/security.service';
import { CurrencyComponent } from './../shared/renderers/currency.component';


@Component({
  selector: 'app-operator-details',
  templateUrl: './operator-details.component.html',
  styleUrls: ['./operator-details.component.scss']
})
export class OperatorDetailsComponent implements OnInit {
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  operator: Operators;
  lines$: Observable<BudgetLines[]>;
  lineComments$: Observable<LineComments[]>;
  line$: Observable<BudgetLines>;
  commentSaved$: BehaviorSubject<boolean> = new BehaviorSubject(true);
  public columnDefs: any[];
  public gridOptions: GridOptions;
  public showSubCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showTecCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showMalCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showFinal$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private colWidth = 90;
  public budgetDesc = '';
  private roles: any[] = [];

  showDetail = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http
  ) {
    this.gridOptions = <GridOptions>{};
    this.createColumnDefs();
  }

  ngOnInit() {
    console.log(this.route.snapshot.paramMap.get('id'));
    this.getOperator(this.route.snapshot.paramMap.get('id'));
    // console.log(this.route);
    this.roles = this.securityService.roles;
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
    this.budgets$.subscribe(budgets => {
      if (budgets) {
        this.budgetDesc = budgets[0].description;
      }
    });

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
