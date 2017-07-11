import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateGuard } from '../../login';
import { AuthGuard } from '../../login';

import {  CashCallComponent } from './cash-call.component';

const  CashCallRoutes: Routes = [
    {
        path: 'cashcall',
        component: CashCallComponent, canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard],

    }
];

@NgModule({
    imports: [RouterModule.forChild( CashCallRoutes)],
    exports: [RouterModule]
})
export class CashCallRoutingModule { }