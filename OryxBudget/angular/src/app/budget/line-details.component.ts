import { Component, OnInit, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { MaterializeAction } from 'angular2-materialize';
import { GridOptions } from 'ag-grid/main';
import { Budgets, Operators, BudgetLines, LineComments } from './../models';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import { WordWrapComponent } from './../shared/renderers/word-wrap.component'

@Component({
  selector: 'app-line-details',
  templateUrl: './line-details.component.html',
  styleUrls: ['./line-details.component.scss']
})
export class LineDetailsComponent implements OnInit, OnChanges {
  @Input() lines: BudgetLines[] = [];
  @Input() lineComments: LineComments[] = [];
  @Output() comments = new EventEmitter();
  @Output() saveComments = new EventEmitter();
  @Input() commentSaved: Observable<boolean>;
  @Input() roles: any[] = [];

  modalActions = new EventEmitter<string | MaterializeAction>();
  filtered: BudgetLines[] = [];
  selectedCode: BudgetLines;
  parentCode: BudgetLines;
  level: number;
  showComment = false;
  line: BudgetLines;

  public showSubCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showTecCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showMalCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showFinal$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private colWidth = 110;
  public columnDefs: any[];

  public gridOptions: GridOptions;
  public rowData: any[] = [];


  history: string[] = ['home'];
  constructor() {



  }

  ngOnInit() {
    this.commentSaved.subscribe(saved => this.showComment = !saved);
    this.structureData();

    this.createColumnDefs();
    this.gridOptions = <GridOptions>{
      getNodeChildDetails: getNodeChildDetails,
    };



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

  ngOnChanges(changes: any) {
    this.filtered = this.lines.filter(bd => bd.level === '1');
    this.level = 0;
    console.log(this.filtered);
  }

  addHistory(code: string) {
    this.history.push(code);
  }
  /*
    filterLines(code: string, addToHistory = true) {
      if (code === 'home') {
        this.filtered = this.lines.filter(bd => bd.level === '1');
        this.level = 0;
      } else {
        this.filtered = this.lines.filter(bd => bd.fatherNum === code);
        this.selectedCode = this.lines.filter(bd => bd.code === code)[0];
        this.level = this.selectedCode.level + 1;
        if (this.level === 3) {
          this.parentCode = this.lines.filter(bd => bd.code === this.selectedCode.fatherNum)[0];
        }
        if (this.history.indexOf(code) === -1) {
          if (addToHistory) { this.addHistory(code); }
        }
  
      }
  
  
    }
  */
  showDetails(code: string) {

  }

  getComments(code: string) {
    this.showComment = true;
    // this.comments.emit({ code: this.selectedCode.code, budgetId: this.selectedCode.budgetId });
    this.line = this.lines.filter(bd => bd.code === code)[0];
    this.comments.emit(this.line);
    // this.modalActions.emit({ action: 'modal', params: ['open'] });

  }

  updateComments(comments: any) {
    const data = { data: comments, code: this.line.code, budgetId: this.line.budgetId };
    this.saveComments.emit(data);
  }

  structureData() {
    const level1: BudgetLines[] = this.lines.filter(line => line.level === '1');
    const level2: BudgetLines[] = this.lines.filter(line => line.level === '2');
    const level3: BudgetLines[] = this.lines.filter(line => line.level === '3');
    let leve2Data: any[] = [];
    level2.map(line => {
      const children = level3.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign(line, { level2: line.code, level3: children });
      leve2Data.push(bd);
    })

    level1.map(line => {
      const children = leve2Data.filter(l2 => l2.fatherNum === line.code);
      const bd = _.assign(line, { level1: line.code, level2: children });
      this.rowData.push(bd);
    });
    console.log(this.rowData);

  }

  private createColumnDefs() {
    this.columnDefs = [
      {
        headerName: 'Budget Codes',
        children: [
          {
            headerName: 'Code', field: 'code',
            width: 100, pinned: true,
            cellRenderer: 'group'
          },
          {
            headerName: 'Description', field: 'description',
            width: 300, pinned: true,
            // cellRendererFramework: WordWrapComponent
            cellStyle: {  'word-wrap': 'break-word' }
          }
        ]
      },

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
            currency: 'NGN',
            editable: true
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
          {
            headerName: 'Comment',
            width: this.colWidth, pinned: true,
            cellTemplate: '<div><a href="#">Visible text</a></div>'
          }
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
      // the key is used by the default group cellRenderer
      key: rowItem.level1
    };
  } else {
    if (rowItem.level2) {
      return {
        group: true,

        children: rowItem.level3,

        field: 'level2',
        // the key is used by the default group cellRenderer
        key: rowItem.level2
      };
    } else
    { return null; }
  }
}
