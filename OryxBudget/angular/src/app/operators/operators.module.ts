import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OperatorsComponent } from './operators.component';
import { ContactDetailsComponent } from './contact-details.component';

@NgModule({
  imports: [
   CommonModule,
    SharedModule,
     FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [OperatorsComponent,
    ContactDetailsComponent,],
    exports: [
    OperatorsComponent]
})
export class OperatorsModule { }
