import { Component, OnInit, EventEmitter, OnChanges } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import { NotificationsService } from 'angular2-notifications';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { MaterializeDirective, MaterializeAction } from 'angular2-materialize';
import { DisplayModeEnum } from './../shared/shared-enum.enum';
import { GridOptions } from 'ag-grid/main';
import { Budgets, Operators, BudgetLines, LineComments, LineStatus } from './../models';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { SecurityService } from './../login/security.service';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import * as _ from 'lodash';

@Component({
  selector: 'app-operator-details',
  templateUrl: './operator-details.component.html',
  styleUrls: ['./operator-details.component.scss']
})
export class OperatorDetailsComponent implements OnInit, OnChanges {
  budgets$: Observable<Budgets[]>;
  operator$: Observable<Operators>;
  operator: Operators;
  lines$: Observable<BudgetLines[]>;
  lineComments$: Observable<LineComments[]>;
  line$: Observable<BudgetLines>;
  commentSaved$: BehaviorSubject<boolean> = new BehaviorSubject(true);
  lineStatus$: Observable<LineStatus[]>;
  public columnDefs: any[];
  public gridOptions: GridOptions;
  public showSubCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showTecCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showMalCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showFinal$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showLevel: number;
  private colWidth = 110;
  public budgetDesc = '';
  actions1 = new EventEmitter<string | MaterializeAction>();
  public showApproval = false;



  params = [
    {
      onOpen: (el) => {
        console.log('Collapsible open', el);
      },
    }
  ];

  values = ['First'];
  public roles: any[] = [];
  public loading$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public saving$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  showDetail = false;
  public dept = 'All';
  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;

  form: FormGroup;



  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private securityService: SecurityService,
    private _http: Http,
    private _service: NotificationsService,
    private fb: FormBuilder
  ) {
    this.gridOptions = <GridOptions>{};
    this.createColumnDefs();
  }

  ngOnInit() {
    // console.log(this.route.snapshot.paramMap.get('id'));
    this.getOperator(this.route.snapshot.paramMap.get('id'));
    // // console.log(this.route);
    this.roles = this.securityService.roles;
    this.roles.map(role => {
      switch (role) {
        case 'SubCom':
          this.showSubCom$.next(true);
          this.showLevel = 1;
          break;
        case 'TecCom':
          this.showTecCom$.next(true);
          this.showLevel = 2;
          break;
        case 'MalCom':
          this.showMalCom$.next(true);
          this.showLevel = 3;
          break;
        case 'Final':
          this.showFinal$.next(true);
          this.showLevel = 3;
          break;
        case 'Production':
          this.dept = 'Production';
          break;
        case 'Exploration':
          this.dept = 'Exploration';
          break;
        case 'Facilities':
          this.dept = 'Facilities';
          break;
        default:
          break;
      }
    });
    this.form = this.fb.group({
            status: new FormControl({}),
    });
  }
  ngOnChanges(changes: any): void {

    

  }
  openFirst() {
    this.showApproval = true;
  }
  getOperator(id: string) {
    this.loading$.next(true);
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
        this.getLineDetails(budgets[0].id);
        this.loading$.next(false);
        this._service.success('loaded Successfully', 'Budget loaded successfully');
      }
    });

  }

  getLineDetails(id: string) {
    this.loading$.next(true);
    this.showDetail = true;
    const url = this.securityService.getUrl('Budget/GetBudgetDetails');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('id', id);
    params1.append('department', this.dept);
    this.lines$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());
    this.commentSaved$.next(true);
    this.changeDisplayMode(DisplayModeEnum.Budget);
    this.lines$.subscribe(lines => this.loading$.next(false));
  }

  changeDisplayMode(mode: DisplayModeEnum) {
    // // console.log(mode); 
    this.displayMode = mode;
  }

  getComments(line: BudgetLines) {
    let url = this.securityService.getUrl('Budget/GetLineComment');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('budgetId', line.budgetId);
    params1.append('code', line.code);

    this.lineComments$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());

    url = this.securityService.getUrl('Budget/GetLineStatus');

    this.lineStatus$ = this._http.get(url, {
      headers: this.securityService.getHeaders(),
      body: '',
      params: params1
    }).map(res => res.json());




    this.lineStatus$.subscribe(s => console.log(s));
    this.commentSaved$.next(false);

  }

  saveComments(data: any) {
    this.saving$.next(true);
    const url = this.securityService.getUrl('Budget/AddLineComment');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('budgetId', data.budgetId);
    params1.append('code', data.code);
    params1.append('type', data.type);
    params1.append('status', data.status);

    const bd = { lineComments: data.lineComments, budgetLine: _.assign(data.budgetLine, { code: data.code }) };

    const ret$ = this._http.post(url,
      JSON.stringify(bd), {
        headers: this.securityService.getHeaders(),
        search: params1
      })
      .map(res => res.json())
      .subscribe(saved => {
        this.commentSaved$.next(true);
        this._service.success('', 'Saved successfully');
        this.saving$.next(false);
      });
    //.catch(err => Observable.from([this._service.error('Error', err)])
    // ));
  }

  newComment(data: any) {
    const url = this.securityService.getUrl('Budget/AddComment');
    const params1: URLSearchParams = new URLSearchParams();
    // params1.append('budgetId', data.budgetId);
    // params1.append('code', data.code);

    const ret = this._http.post(url,
      data, {
        headers: this.securityService.getHeaders(),
        // search: params1
      })
      .map(res => res.json())
      .subscribe(saved => {
        // this.commentSaved$.next(true);
        // this.saving$.next(false);
        // this._service.success('Comments', 'Comments successfully');
      });

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
    // // console.log('onReady');
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

  public showExploration(type: string) {
    switch (type) {
      case 'AFE':
        break;
      case 'Exploration Details':
        this.changeDisplayMode(this.displayModeEnum.Option3);
        break;
      default:
        break;
    }
  }
}
