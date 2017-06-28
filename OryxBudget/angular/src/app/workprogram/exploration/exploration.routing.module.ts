import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateGuard } from '../../login';
import { AuthGuard } from '../../login';

import { ExplorationComponent } from './exploration.component';

const ExplorationRoutes: Routes = [
    {
        path: 'exploration',
        component: ExplorationComponent, canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard],

    }
];

@NgModule({
    imports: [RouterModule.forChild(ExplorationRoutes)],
    exports: [RouterModule]
})
export class ExplorationRoutingModule { }

