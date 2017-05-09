import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router'
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
@Component({
  selector: 'app-operator-details',
  templateUrl: './operator-details.component.html',
  styleUrls: ['./operator-details.component.scss']
})
export class OperatorDetailsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
  private router: Router
  ) { }

  ngOnInit() {
    console.log(this.route.snapshot.paramMap.get('id'));
    //console.log(this.route);
     
  }

  getOperator()  {

  }

}
