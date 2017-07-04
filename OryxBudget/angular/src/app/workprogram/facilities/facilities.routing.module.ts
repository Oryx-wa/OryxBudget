import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateGuard } from '../../login';
import { AuthGuard } from '../../login';

import { FacilitiesComponent } from './facilities.component';

const FacilitiesRoutes: Routes = [
    {
        path: 'facilities',
        component: FacilitiesComponent, canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard],

    }
];

@NgModule({
    imports: [RouterModule.forChild(FacilitiesRoutes)],
    exports: [RouterModule]
})
export class FacilitiesRoutingModule { }