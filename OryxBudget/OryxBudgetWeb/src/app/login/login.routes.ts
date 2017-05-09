import {Routes} from '@angular/router';

import { LoginComponent }     from './login.component';
// import {ForbiddenComponent} from '../forbidden/forbidden.component';
// import {UnauthorizedComponent} from '';



export const LoginRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  // { path: 'forbidden',  component: ForbiddenComponent },
  // { path: 'unauthorized',  component: UnauthorizedComponent },
];
/*
export const AUTH_PROVIDERS = [AuthGuard, 
  SecurityService, 
  HTTP_PROVIDERS,
  Configuration];
*/

/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/