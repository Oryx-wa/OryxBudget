import { Component, OnInit, Input, Output, EventEmitter, OnChanges, ChangeDetectionStrategy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import * as _ from 'lodash';
import { ListMapping } from './list-mapping';
import { IOption } from 'ng-select';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnChanges {
  @Input() listData: any[];
  @Input() fields: string[];
  @Input() idField: string = 'id';
  @Input() paginate = true;
  @Input() itemsPerPage = 10;
  @Input() useSelect = false;
  @Input() inputSelectData: any[];
  @Input() multiple = false;
  @Input() selectPlaceHolder = 'Filter list by selecting an item';
  @Input() selectLabel = '';
  @Input() selectFilterField = '';
  @Input() selectFields: string[];
  @Input() showAdd: false;
  @Input() newCaption: 'New Item';
  @Input() refresh: BehaviorSubject<any> = new BehaviorSubject(null);
  @Input() showAvatar: true;

  @Output() select = new EventEmitter();
  @Output() addNew = new EventEmitter();

  public data: any[];
  public selectData: any[];
  public noOfFields = 0;
  selectedIndex: number;
  public selectedValue = '';
  public listClass = '';

  constructor() { }

  ngOnInit() {
    this.setupListData();
    let selectMap = _.zipObject(this.selectFields, ['value', 'label']);
    this.selectData = _.map(this.inputSelectData, function (obj) {
      return _.transform(obj, function (result, value, key: string) {
        if (selectMap[key]) {
          result[selectMap[key]] = value;
        }
      });
    });

    if (this.useSelect) {
      this.data = this.data.filter(data => data.filterField === this.selectedValue);
    }

    this.refresh.subscribe(data => {
      if (data !== null) {
        let match = _.findIndex(this.data, ['id', data.id]);
        let index = 0;
        if (match >= 0) {
          index = _.indexOf(this.data, _.find(this.data, data.id));
          this.data.splice(index, 1, data);
        } else {
          this.data.push(data);
          index = this.data.length - 1;
        }
        this.selectedIndex = index;

      }
    });

    if (this.showAvatar) {
      this.listClass = 'hoverable collection-item avatar fake-link';
    } else {
      this.listClass = 'hoverable collection-item  fake-link';
    }
  }

  ngOnChanges(changes: any): void {
    //// console.log(changes);
  }

  setupListData() {
    this.noOfFields = this.fields.length;
    let keyMap = _.zipObject(this.fields, ['field1', 'field2', 'field3']);
    let id = this.idField;
    let filterField = this.selectFilterField;
    let useSelect = this.useSelect;
    this.data = _.map(this.listData, function (obj) {
      return _.transform(obj, function (result, value, key: string) {
        switch (key) {
          case id:
            result['id'] = value;
            break;
          case filterField:
            if (useSelect) {
              result['filterField'] = value;
            }
            break;
          default:
            if (keyMap[key]) {
              result[keyMap[key]] = value;
            }
            break;
        };

      });
    });
  }

  filterSelected(option: IOption) {
    this.setupListData();
    if (option.value) {
      this.data = this.data.filter(data => data.filterField === option.value);
    } else {
      this.data = this.data.filter(data => data.filterField === option.label);
    }

  }

  itemSelected(id: string, index: number) {
    this.selectedIndex = index;
    this.select.emit(id);
  }


}
