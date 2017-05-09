import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import {SharedModule} from './../shared/shared.module';
import { OperatorViewModule} from './../operator-view/operator-view.module';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    OperatorViewModule
  ],
  declarations: [HomeComponent]
})
export class HomeModule { }
