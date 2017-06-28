import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExplorationComponent } from './exploration.component';
import { SharedModule } from './../../shared/shared.module';
import { ExplorationRoutingModule} from './exploration.routing.module';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ExplorationRoutingModule
  ],
  declarations: [ExplorationComponent],
  exports: [ExplorationComponent]
})
export class ExplorationModule { }
