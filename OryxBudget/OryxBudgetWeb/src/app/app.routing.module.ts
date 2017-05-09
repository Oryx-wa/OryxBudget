import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './home';
import { OperatorDetailsComponent } from './budget/operator-details.component';
// import { LoginComponent } from './login/login.component';
import { AuthGuard } from './login/auth.guard';
import { NgModule } from '@angular/core';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
 // { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  {path: 'operatordetails', component: OperatorDetailsComponent}
 
 
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [
    RouterModule
  ],
  providers: [AuthGuard],
  
})
export class AppRoutingModule { }

