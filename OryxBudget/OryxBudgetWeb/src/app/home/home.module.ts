import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import {SharedModule} from './../shared/shared.module';
import { OperatorViewModule} from './../operator-view/operator-view.module';
import { UnauthorisedComponent } from './unauthorised.component';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    OperatorViewModule
  ],
  declarations: [HomeComponent, UnauthorisedComponent]
})
export class HomeModule { }
