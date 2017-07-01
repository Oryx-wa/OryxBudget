import {
  Component, OnInit, Input, OnChanges, Output,
  EventEmitter, ChangeDetectionStrategy, OnDestroy, SimpleChanges
} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { RouterModule } from '@angular/router';
import { Http, URLSearchParams } from '@angular/http';
import * as _ from 'lodash';
import { Store } from '@ngrx/store';
import { MaterializeAction } from 'angular2-materialize';
import { GridOptions } from 'ag-grid/main';
import { Budget, BudgetLines, LineComment, Actual, AppState, UserSelector } from '../../redux';
import { CurrencyComponent } from '../../shared/renderers/currency.component';
import { WordWrapComponent } from '../../shared/renderers/word-wrap.component';
import { TextComponent } from '../../shared/renderers/text.component';
import { ChildMessageComponent } from '../../shared/renderers/child-message.component';
import { SecurityService } from './../../login/security.service';
import { StyledComponent } from '../../shared/renderers/styled-component';
import { DialogService, alertTypeEnum } from './../dialog.service';

import swal from 'sweetalert2';
import { UploadOutput, UploadInput, UploadFile, humanizeBytes, NgUploaderService, UploadStatus } from 'ngx-uploader';


@Component({
  selector: 'app-line-details2',
  templateUrl: './line-details2.component.html',
  styleUrls: ['./line-details2.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LineDetails2Component implements OnInit, OnChanges, OnDestroy {
  @Input() lines: BudgetLines[] = [];
  showSubCom = false;
  showTecCom = false;

  @Input() budgetId = '';



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
  public nolines = false;
  private alive = true;

  uploadInput: EventEmitter<UploadInput>;
  humanizeBytes: Function;
  upload: NgUploaderService;
  public operator = false;

  public data: any;
  constructor(private store: Store<AppState>, private dialog: DialogService, private securityService: SecurityService) {
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

  ngOnInit() {
    // this.structureData();
    this.createColumnDefs();

    this.store
      .takeWhile(() => this.alive)
      .subscribe(s => {
        this.operator = s.security.user.operator;
        this.showTecCom = s.security.user.showTecCom;
        this.showSubCom = s.security.user.showSubCom;

      })
    this.data = { id: this.budgetId };
    console.log(this.showTecCom);
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(changes);
    if (changes['lines']) {
      if (changes['lines'].currentValue.length > 0) {
        this.structureData();
        if (this.rowData.length > 0) {

          this.gridOptions.api.setRowData(this.rowData);
          this.setColumns();
        }
      } else {
        const nolines = this.nolines;

        if (this.operator) {
          const event: UploadInput = {
            type: 'uploadFile',
            url: this.securityService.getUrl('Budget/UploadBudget'),
            method: 'POST',
            data: { id: this.budgetId },
            concurrency: 1, // set sequential uploading of files with concurrency 1,
            headers: { ['Authorization']: 'Bearer ' + this.securityService.GetToken() }

          };
          uploadBudget(event);
          this.nolines = nolines;

        }
      }
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
            headerName: 'Budget LC', field: 'tecComBudgetLC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'NGN', hidden: true,
          },
          {
            headerName: 'Budget USD', field: 'tecComBudgetUSD',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true,
          },
          {
            headerName: 'Budget FC', field: 'tecComBudgetFC',
            width: this.colWidth,
            cellRendererFramework: CurrencyComponent,
            currency: 'USD', hidden: true,
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
    // this.setColumns();


  }

  private setColumns() {
    if (this.ready) {
      this.gridOptions.columnApi.setColumnsVisible(
        ['subComBudgetLC', 'subComBudgetUSD', 'subComBudgetFC'],
        this.showSubCom);

      this.gridOptions.columnApi.setColumnsVisible(
        ['tecComBudgetLC', 'tecComBudgetUSD', 'tecComBudgetFC'],
        this.showTecCom);
      /*
    this.gridOptions.columnApi.setColumnsVisible(
      ['malComBudgetLC', 'malComBudgetUSD', 'malComBudgetFC'],
     false);

    this.gridOptions.columnApi.setColumnsVisible(
      ['finalBudgetLC', 'finalBudgetUSD', 'finalBudgetFC'],
      false);*/
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

  ngOnDestroy() {
    this.alive = false;
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

function uploadBudget(uploadInput: UploadInput) {

  return swal({
    title: 'No Budget Details',
    type: 'question',
    text: 'Do you want to upload budget?',
    showCloseButton: true,
    showCancelButton: true,
    confirmButtonText:
    ' Upload ',
    confirmButtonClass: 'waves-effect waves-light btn',
    cancelButtonText:
    'Cancel',
    cancelButtonClass: 'waves-effect waves-light btn',
    buttonsStyling: false

  }).then(function () {
    swal({
      title: 'Select File',
      input: 'file',
      inputAttributes: {
        accept: '*/*'
      }
    }).then(function (file) {

      // console.log(uploadInput);
      const ngx = new NgUploaderService();
      uploadFile(file, uploadInput).subscribe(data => console.log(data));
    });
  });
}

function uploadFile(file: any, event: UploadInput) {
  return new Observable(observer => {
    const url = event.url;
    const method = event.method || 'POST';
    const data = event.data || {};
    const headers = event.headers || {};

    const reader = new FileReader();
    const xhr = new XMLHttpRequest();
    let time: number = new Date().getTime();
    let load = 0;

    xhr.upload.addEventListener('progress', (e: ProgressEvent) => {
      if (e.lengthComputable) {
        const percentage = Math.round((e.loaded * 100) / e.total);
        const diff = new Date().getTime() - time;
        time += diff;
        load = e.loaded - load;
        const speed = parseInt((load / diff * 1000) as any, 10);

        file.progress = {
          status: UploadStatus.Uploading,
          data: {
            percentage: percentage,
            speed: speed,
            speedHuman: `${humanizeBytes(speed)}/s`
          }
        };

        observer.next({ type: 'uploading', file: file });
      }
    }, false);

    xhr.upload.addEventListener('error', (e: Event) => {
      observer.error(e);
      observer.complete();
    });

    xhr.onreadystatechange = () => {
      if (xhr.readyState === XMLHttpRequest.DONE) {
        file.progress = {
          status: UploadStatus.Done,
          data: {
            percentage: 100,
            speed: null,
            speedHuman: null
          }
        };

        try {
          file.response = JSON.parse(xhr.response);
        } catch (e) {
          file.response = xhr.response;
        }

        observer.next({ type: 'done', file: file });
        observer.complete();
      }
    };

    xhr.open(method, url, true);

    const form = new FormData();

    try {
      form.append('file', file, file.name);

      Object.keys(data).forEach(key => form.append(key, data[key]));
      Object.keys(headers).forEach(key => xhr.setRequestHeader(key, headers[key]));

      // this.serviceEvents.emit({ type: 'start', file: file });
      xhr.send(form);

    } catch (e) {
      observer.complete();
    }

    return () => {
      xhr.abort();
      reader.abort();
    };
  });
}
