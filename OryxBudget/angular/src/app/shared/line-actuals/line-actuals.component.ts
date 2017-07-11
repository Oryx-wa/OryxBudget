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

import { upload } from './../swalwrapper';

@Component({
  selector: 'app-line-actuals',
  templateUrl: './line-actuals.component.html',
  styleUrls: ['./line-actuals.component.scss']
})
export class LineActualsComponent implements OnInit {
  @Input() actuals: Actual[] = [];
  showSubCom = false;
  showTecCom = false;

  @Input() budgetId = '';
  constructor() { }

  ngOnInit() {
  }

  public onReady(data: any) {}

}
