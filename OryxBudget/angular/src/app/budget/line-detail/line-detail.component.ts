import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { MaterializeDirective, MaterializeAction } from 'angular2-materialize';
import { GridOptions } from 'ag-grid/main';
import { CurrencyComponent } from './../../shared/renderers/currency.component';
import { BudgetLines } from './../../models/';
import * as _ from 'lodash';


@Component({
  selector: 'app-line-detail',
  templateUrl: './line-detail.component.html',
  styleUrls: ['./line-detail.component.scss']
})
export class LineDetailComponent implements OnInit, OnChanges {
  @Input() actual: BudgetLines;
  @Input() from = false;
  @Input() to = false;
  @Input() showActual = false;

  @Input() userType = '';
  @Input() napims = false;
  @Input() operator = false;
  @Output() update = new EventEmitter();
  public gridOptions: GridOptions;
  public columnDefs: any[];
  private colWidth = 150;
  actuals: BudgetLines;
  actions1 = new EventEmitter<string | MaterializeAction>();
 


  params = [
    {
      onOpen: (el) => {
        console.log('Collapsible open', el);
      },
    }
  ];

  values = ['First'];

  form: FormGroup;


  constructor(private fb: FormBuilder) {

  }
  ngOnInit() {
  }
  ngOnChanges(changes: any): void {

    this.form = this.fb.group({
      opBudgetFC: new FormControl({ value: this.actual.opBudgetFC, disabled: true }),
      opBudgetLC: new FormControl({ value: this.actual.opBudgetLC, disabled: true }),
      opBudgetUSD: new FormControl({ value: this.actual.opBudgetUSD, disabled: true }),
      opActualFC: new FormControl({ value: this.actual.opActualFC, disabled: true }),
      opActualLC: new FormControl({ value: this.actual.opActualLC, disabled: true }),
      opActualUSD: new FormControl({ value: this.actual.opActualUSD, disabled: true }),
      to: new FormControl({  }),
       from: new FormControl({  }),


    });

  }
  save(data: any) {
    const actual: BudgetLines = _.assign({}, data);
    this.update.emit({ actual: actual });

  }

  openFirst() {
    this.actions1.emit({ action: 'collapsible', params: ['open', 0] });
  }
  private createColumnDefs() {
    this.columnDefs = [
      {
        headerName: 'From',
        children: [
          {
            headerName: 'From', field: 'From',
            width: 120,
           cellTemplate: '<div>3/12/2017</div>',

          },
          {
            headerName: 'To', field: 'To',
            width: 120,
            cellTemplate: '<div>3/12/2017</div>',
          }
        ]
      },

      {
        headerName: 'Operator Actual',
        children: [
          {
            headerName: 'Actual LC', field: 'opActualLC',
            width: this.colWidth,
            cellTemplate: '<div>20000</div>',
            currency: 'NGN', hidden: true
          },
          {
            headerName: 'Actual USD', field: 'opActualUSD',
            width: this.colWidth,
            cellTemplate: '<div>3000</div>',
            currency: 'USD', hidden: true
          },
          {
            headerName: 'Actual FC', field: 'opActualFC',
            width: this.colWidth,
           cellTemplate: '<div>5000</div>',
            currency: 'USD'
          },
        ]
      },
    ];
  }


}
