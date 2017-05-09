import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorViewComponent } from './operator-view.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [OperatorViewComponent],
  exports: [OperatorViewComponent]
})
export class OperatorViewModule { }
