import { Injectable, OnInit } from '@angular/core';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateChild,
  NavigationExtras,
  CanLoad, Route
} from '@angular/router';
import { SecurityService } from './security.service';


import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/let';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad, OnInit {
  
  constructor(private securityService: SecurityService, private router: Router,
  

  ) {

   

  }

  ngOnInit() {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let url: string = state.url;

    return this.checkLogin(url);
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(route, state);
  }

  canLoad(route: Route): boolean {
    let url = `/${route.path}`;

    return this.checkLogin(url);
  }

  checkLogin(url: string): boolean {

    if (this.securityService.authenticated) {
      return true;
    } else {
      // Store the attempted URL for redirecting
      this.securityService.redirectUrl = url;

      // Navigate to the login page with extras
      this.router.navigate(['/login'], { queryParams: { returnUrl: url } });
      return false;
    }
  }
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/