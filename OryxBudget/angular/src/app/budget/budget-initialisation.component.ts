import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Http, URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';
import { SecurityService } from './../login/security.service';

@Component({
  selector: 'app-budget-initialisation',
  templateUrl: './budget-initialisation.component.html',
  styleUrls: ['./budget-initialisation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BudgetInitialisationComponent implements OnInit, OnChanges {

  form: FormGroup;


  constructor(private fb: FormBuilder,
    private securityService: SecurityService,
    private _http: Http,
    private router: Router, ) {
    this.form = this.fb.group({
      year: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
    });

  }
  ngOnChanges(changes: any): void {
    this.form.reset();

  }


  ngOnInit() {

  }

  save(data: any) {
    const url = this.securityService.getUrl('Budget/InitializeBudgetForAllOperators');
    const params1: URLSearchParams = new URLSearchParams();
    params1.append('year', data.year);
    params1.append('description', data.description);

    const ret = this._http.post(url,
      '', {
        headers: this.securityService.getHeaders(),
        search: params1
      })
      .map(res => res.json())
      .subscribe(saved => {
        this.router.navigate(['/home']);
      });
  }

}
