import { Component, OnInit, Input, OnChanges, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { RouterModule } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import * as _ from 'lodash';
import { Store } from '@ngrx/store';
import { MaterializeAction } from 'angular2-materialize';
import { GridOptions } from 'ag-grid/main';
import { Budget, BudgetLines, LineComment, Actual, AppState } from '../../redux';
import { CurrencyComponent } from '../../shared/renderers/currency.component';
import { WordWrapComponent } from '../../shared/renderers/word-wrap.component';
import { TextComponent } from '../../shared/renderers/text.component';
import { ChildMessageComponent } from '../../shared/renderers/child-message.component';

import { StyledComponent } from '../../shared/renderers/styled-component';



@Component({
  selector: 'app-line-details2',
  templateUrl: './line-details2.component.html',
  styleUrls: ['./line-details2.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LineDetails2Component implements OnInit, OnChanges {
  @Input() lines: BudgetLines[] = [];
  @Input() showSubCom = false;
  @Input() showTecCom = false;
  @Input() showMalCom =  false;
  @Input() showFinal = false;


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
  constructor(private store: Store<AppState>) { }

  ngOnInit() {
    // this.structureData();
    this.createColumnDefs();
    this.gridOptions = <GridOptions>{
        context: {
          componentParent: this
        },
        getNodeChildDetails: getNodeChildDetails,        
        debug: false,
        getRowStyle: function (params) {
          if (params.node.floating) {
            return { 'font-weight': 'bold' };
          }
        },
        floatingTopRowData: this.floatingRow,
        floatingBottomRowData: this.floatingRow,
      };

  }

  ngOnChanges(changes: any) {

   
    this.structureData();
    if (this.rowData.length > 0) {
      this.gridOptions.api.setRowData(this.rowData);
    }
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
            headerName: 'Budget LC', field: 'opBudgetLC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN', hidden: true
          },
          {
            headerName: 'Budget USD', field: 'opBudgetUSD',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true
          },
          {
            headerName: 'Budget FC', field: 'opBudgetFC',
            width: this.colWidth,
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
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN', hidden: true, editable: true
          },
          {
            headerName: 'Budget USD', field: 'subComBudgetUSD',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true, editable: true
          },
          {
            headerName: 'Budget FC', field: 'subComBudgetFC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', editable: true
          }
        ]
      },
      {
        headerName: 'Technical Commitee',
        children: [

          {
            headerName: 'Budget USD', field: 'tecComBudgetUSD',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true, editable: true
          },
          {
            headerName: 'Budget FC', field: 'tecComBudgetFC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', editable: true, hidden: false,
          }
        ]
      },

      {
        headerName: 'Details | Comments | Attachments',
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


  public onReady(data: any) {
    // // console.log('onReady');
    // this.gridOptions.api.setColumnDefs(this.createColumnDefs());
    // this.gridOptions.api.setRowData(this.rowData);
    this.ready = true;
    this.setColumns();


  }

  private setColumns() {
    if (this.ready && this.rowData.length > 1) {
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
  }

  structureData() {
     this.rowData = [];
    const data = _.assign(this.lines, { comment: '' });
    const level1: BudgetLines[] = this.lines.filter(line => line.level === '1');
    const level2: BudgetLines[] = this.lines.filter(line => line.level === '2');
    const level3: BudgetLines[] = this.lines.filter(line => line.level === '3');
    let leve2Data: any[] = [];
    level2.map(line => {
      const children = level3.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign({}, line, { level2: line.code, level3: children });
      leve2Data.push(bd);
    });

    level1.map(line => {
      const children = leve2Data.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign({}, line, { level1: line.code, level2: children });
      this.rowData.push(bd);
    });
    const output = this.floatingRow.push({
      id: '',
      code: 'Total',
      description: '',
      level: '3',
      fatherNum: '',
      opBudgetFC: _.sumBy(level3, 'opBudgetFC'),
      opBudgetLC: _.sumBy(level3, 'opBudgetLC'),
      opBudgetUSD: _.sumBy(level3, 'opBudgetUSD'),
      subComBudgetFC: _.sumBy(level3, 'subComBudgetFC'),
      subComBudgetLC: _.sumBy(level3, 'subComBudgetLC'),
      subComBudgetUSD: _.sumBy(level3, 'subComBudgetUSD'),
      tecComBudgetFC: _.sumBy(level3, 'tecComBudgetFC'),
      tecComBudgetLC: _.sumBy(level3, 'tecComBudgetLC'),
      tecComBudgetUSD: _.sumBy(level3, 'tecComBudgetUSD'),
      malComBudgetFC: _.sumBy(level3, 'malComBudgetFC'),
      malComBudgetLC: _.sumBy(level3, 'malComBudgetLC'),
      malComBudgetUSD: _.sumBy(level3, 'malComBudgetUSD'),
      finalBudgetFC: _.sumBy(level3, 'finalBudgetFC'),
      finalBudgetLC: _.sumBy(level3, 'finalBudgetLC'),
      finalBudgetUSD: _.sumBy(level3, 'finalBudgetUSD'),
      lineStatus: '',
      budgetId: '',
      comment: '',
      float: true,
    });
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