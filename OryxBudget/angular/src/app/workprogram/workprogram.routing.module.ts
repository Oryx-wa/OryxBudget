import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateGuard } from './../login';
import { AuthGuard } from './../login';

import { WorkprogramComponent } from './workprogram.component';
import { FacilitiesComponent } from './facilities/facilities.component';
import { ExplorationComponent } from './exploration/exploration.component';
import {CashCallComponent } from './cash-call/cash-call.component';
import { MaComComponent} from './ma-com/ma-com.component'

const workProgramRoutes: Routes = [
    {
        path: 'workprogram',
        component: WorkprogramComponent, canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard],
        children: [{
            path: 'facilities', component: FacilitiesComponent,
            canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard]
        },
        {
            path: 'exploration', component: ExplorationComponent,
            canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard]
        },
         {
            path: 'macom', component: MaComComponent,
            canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard]
        },
         {
            path: 'cashcall', component: CashCallComponent,
            canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard]
        },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(workProgramRoutes)],
    exports: [RouterModule]
})
export class WorkProgramRoutingModule { }

