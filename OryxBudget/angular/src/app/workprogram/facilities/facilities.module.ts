import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FacilitiesComponent } from './facilities.component';
import { FacilitiesRoutingModule} from './facilities.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../../shared/shared.module';
@NgModule({
  imports: [
    CommonModule,
    FacilitiesRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [FacilitiesComponent],
   exports: [FacilitiesComponent]
})
export class FacilitiesModule { }
