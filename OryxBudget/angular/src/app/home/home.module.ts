import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { HomeComponent } from './home.component';
import { SharedModule } from './../shared/shared.module';
import { OperatorViewModule } from './../operator-view/operator-view.module';
import { UnauthorisedComponent } from './unauthorised.component';
import { WorkprogramModule } from './../workprogram/workprogram.module';
import { OperatorEffects, OperatorService } from './../redux';
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    OperatorViewModule,
    WorkprogramModule,
    EffectsModule.run(OperatorEffects)
  ],
  declarations: [HomeComponent, UnauthorisedComponent],
  providers: [OperatorService]
})
export class HomeModule { }
