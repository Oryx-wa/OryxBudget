import { Component, OnInit, Input, Output } from '@angular/core';

@Component({
  selector: 'app-wp-dashboard',
  templateUrl: './wp-dashboard.component.html',
  styleUrls: ['./wp-dashboard.component.scss']
})
export class WpDashboardComponent implements OnInit {
  @Input() dept: string;
  constructor() { }

  ngOnInit() { 
  }

}
