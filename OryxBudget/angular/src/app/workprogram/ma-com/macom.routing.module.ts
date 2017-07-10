import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateGuard } from '../../login';
import { AuthGuard } from '../../login';
import { MaComComponent } from './ma-com.component';

const MaComRoutes: Routes = [
    {
        path: 'macom',
        component: MaComComponent, canDeactivate: [CanDeactivateGuard], canActivate: [AuthGuard], canLoad: [AuthGuard],

    }
];

@NgModule({
    imports: [RouterModule.forChild(MaComRoutes)],
    exports: [RouterModule]
})
export class MaComRoutingModule { }