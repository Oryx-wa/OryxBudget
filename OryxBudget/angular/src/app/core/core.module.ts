/* tslint:disable:member-ordering no-unused-variable */
import {
  ModuleWithProviders, NgModule,
  Optional, SkipSelf
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { StoreModule, Store } from '@ngrx/store';
// import { DBModule } from '@ngrx/db';
import { reducer, initialState } from '../redux';
import { MaterializeModule } from 'angular2-materialize';
import { Configuration } from '../app.constants';
// import { schema } from './../redux/utilities/db';
//import {ServiceHelper} from '../redux/services';
import { SecurityService, CanDeactivateGuard } from './../login';
// import { DialogService } from './../shared/dialog.service';
@NgModule({
  imports: [CommonModule,
    StoreModule.provideStore(reducer),
    MaterializeModule, FormsModule,
    // DBModule.provideDB(schema),

  ],
  declarations: [],
  exports: [MaterializeModule],
  providers: [Configuration, SecurityService, CanDeactivateGuard]
})
export class CoreModule {

  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only');
    }
  }
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        Configuration, SecurityService, CanDeactivateGuard
      ]
    };
  }
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/