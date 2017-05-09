import { Component, OnInit, Input } from '@angular/core';
// import  { HomeDashboardItems  } from './../../redux/login/models/home.model'
import { Operators } from './../../models';
@Component({
  selector: 'app-oryx-dashboard',
  templateUrl: './oryx-dashboard.component.html',
  styleUrls: ['./oryx-dashboard.component.scss']
})
export class OryxDashboardComponent implements OnInit {
  @Input() operators: Operators[] = [];
  @Input() name = '';
  @Input() operatorId = '';
  @Input() role = '';

  constructor() { }

  ngOnInit() {
    console.log(this.role)
  }

}
