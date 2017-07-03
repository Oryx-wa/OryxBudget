import { Component, OnInit, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { RouterModule } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import * as _ from 'lodash';
//import { Observable } from 'rxjs/Observable';
import { MaterializeAction } from 'angular2-materialize';
import { GridOptions } from 'ag-grid/main';
import { Budgets, Operators, BudgetLines, LineComments, LineStatus, Actual } from './../models';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import { WordWrapComponent } from './../shared/renderers/word-wrap.component';
import { TextComponent } from './../shared/renderers/text.component';
import { ChildMessageComponent } from './../shared/renderers/child-message.component';

import { StyledComponent } from './../shared/renderers/styled-component';
import { SecurityService } from './../login/security.service';

@Component({
  selector: 'app-actual-detail',
  templateUrl: './actual-detail.component.html',
  styleUrls: ['./actual-detail.component.scss']
})
export class ActualDetailComponent implements OnInit, OnChanges {
  @Input() lines: BudgetLines[] = [];
  @Input() actuals: Actual[] = [];
  @Input() lineComments: LineComments[] = [];
  @Input() lineStatus: LineStatus[] = [];

  @Input() commentSaved: Observable<boolean>;
  @Input() roles: any[] = [];
  @Input() showSubCom: boolean;
  @Input() showTecCom: boolean;
  @Input() showMalCom: boolean;
  @Input() showFinal: boolean;
  @Input() showOp: boolean;
  @Input() operator = false;
  @Input() napims = false;

  @Output() comments = new EventEmitter();
  @Output() saveComments = new EventEmitter();
  @Output() addNewComment = new EventEmitter();
  // @Output() getComments = new EventEmitter();
  @Output() showActual = new EventEmitter();

  modalActions = new EventEmitter<string | MaterializeAction>();
  filtered: BudgetLines[] = [];
  selectedCode: BudgetLines;
  parentCode: BudgetLines;
  level: number;
  showComment = false;
  line: BudgetLines;
  actual: BudgetLines;
  role: string;
  floatingRow = [];
  private colWidth = 150;
  public columnDefs: any[];
  private ready = false;
  public gridOptions: GridOptions;
  public rowData: any[] = [];
  public userType: string;

  private roleList = ['SubCom', 'TecCom', 'MalCom'];
  private userTypeList = ['Operator', 'Napims'];
  history: string[] = ['home'];
  dialogMode = 'details';
  constructor() { }

  ngOnInit() {
     this.commentSaved.subscribe(saved => this.showComment = !saved);
    this.structureData();
    this.createColumnDefs();
    this.gridOptions = <GridOptions>{
      context: {
        componentParent: this
      },
      getNodeChildDetails: getNodeChildDetails,
      rowData: this.rowData,
      debug: false,
      getRowStyle: function (params) {
        if (params.node.floating) {
          return { 'font-weight': 'bold' };
        }
      },
      floatingTopRowData: this.floatingRow,
      floatingBottomRowData: this.floatingRow,
    };
    console.log(this.floatingRow);
  }

   ngOnChanges(changes: any) {
    this.setupUser();
    this.filtered = this.lines.filter(bd => bd.level === '1');
    this.level = 0;
    this.setColumns();
    // // console.log(this.filtered);
  }

  setupUser() {
    // Role
    this.roles.map(role => {
      if (this.roleList.indexOf(role) > -1) {
        this.role = role;
      }
      if (this.userTypeList.indexOf(role) > -1) {
        this.userType = <string>role;
        this.userType = this.userType.toLowerCase()
      }
    });
  }

  structureData() {
    const data = _.assign(this.actuals, { comment: '' });
    const level1: Actual[] = this.actuals.filter(line => line.level === '1');
    const level2: Actual[] = this.actuals.filter(line => line.level === '2');
    const level3: Actual[] = this.actuals.filter(line => line.level === '3');
    const leve2Data: any[] = [];
    level2.map(line => {
      const children = level3.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign(line, { level2: line.code, level3: children });
      leve2Data.push(bd);
    });

    level1.map(line => {
      const children = leve2Data.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign(line, { level1: line.code, level2: children });
      this.rowData.push(bd);
    });
    const output = this.floatingRow.push({
      id: '',
      code: 'Total',
      description: '',
      level: '3',
      fatherNum: '',
      opActualFC: _.sumBy(level3, 'opBudgetFC'),
      opActualLC: _.sumBy(level3, 'opBudgetLC'),
      opActualUSD: _.sumBy(level3, 'opBudgetUSD'),
      finalBudgetFC: _.sumBy(level3, 'finalBudgetFC'),
      lineStatus: '',
      budgetId: '',
      comment: '',
      float: true,
    });
  }

  private createColumnDefs() {
    this.columnDefs = [

      {
        headerName: 'Budget Codes',
        children: [
          {
            headerName: 'Code', field: 'code',
            width: 90,
            cellRenderer: 'group',
            floatingCellRendererParams: {
              style: { 'font-weight': 'bold' }
            },
            floatingCellRendererFramework: StyledComponent,

          },
          {
            headerName: 'Description', field: 'description',
            width: 200,
            // cellRendererFramework: WordWrapComponent
            cellStyle: { 'word-wrap': 'break-word' },
            floatingCellRendererParams: {
              style: { 'font-weight': 'bold' }
            },
            floatingCellRendererFramework: StyledComponent,
          }
        ]
      },

      {
        headerName: 'Operator Budget',
        children: [

          {
            headerName: 'Budget FC', field: 'opBudgetFC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD'
          },
        ]
      },
      {
        headerName: 'Performance',
        children: [
          {
            headerName: 'NGN', field: 'opActualLC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN', hidden: true, editable: true
          },
          {
            headerName: 'USD', field: 'opActualUSD',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true, editable: true
          },
          {
            headerName: 'FC', field: 'opActualFC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', editable: true
          }
        ]
      },

      {
        headerName: 'Details | Attachments',
        children: [

          {
            headerName: 'Comments', field: 'id',
            width: 140,
            // cellTemplate: '<div><a href="#">Visible text</a></div>',
            editable: true,
            cellRendererFramework: ChildMessageComponent,
            mIcon: 'message', type: 'comment'
          },

        ]
      }

    ];
  }

 private setColumns() {
   /*
    if (this.ready) {
      this.gridOptions.columnApi.setColumnsVisible(
        ['subComBudgetLC', 'subComBudgetUSD', 'subComBudgetFC'],
        this.showSubCom);

      this.gridOptions.columnApi.setColumnsVisible(
        ['tecComBudgetLC', 'tecComBudgetUSD', 'tecComBudgetFC'],
        this.showTecCom);

      this.gridOptions.columnApi.setColumnsVisible(
        ['malComBudgetLC', 'malComBudgetUSD', 'malComBudgetFC'],
        this.showMalCom);

      this.gridOptions.columnApi.setColumnsVisible(
        ['finalBudgetLC', 'finalBudgetUSD', 'finalBudgetFC'],
        this.showFinal);
    }
    */
  }
public onReady(data: any) {
    // // console.log('onReady');
    this.ready = true;
    this.setColumns();


  }

}

function getNodeChildDetails(rowItem) {


  if (rowItem.level1) {
    return {
      group: true,
      // open C be default
      // expanded: rowItem.group === 'Group C',
      // provide ag-Grid with the children of this group
      children: rowItem.level2,
      // this is not used, however it is available to the cellRenderers,
      // if you provide a custom cellRenderer, you might use it. it's more
      // relavent if you are doing multi levels of groupings, not just one
      // as in this example.
      field: 'level1',

      expanded: true,
      // the key is used by the default group cellRenderer
      key: rowItem.level1
    };
  } else {
    if (rowItem.level2) {
      return {
        group: true,

        children: rowItem.level3,

        field: 'level2',
        expanded: false,
        // the key is used by the default group cellRenderer
        key: rowItem.level2
      };
    } else {
      return null;
    }
  }
}