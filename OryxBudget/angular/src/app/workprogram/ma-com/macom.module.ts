import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaComRoutingModule } from './macom.routing.module';
import { MaComComponent } from './ma-com.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../../shared/shared.module';
import { SvgAssetsModule} from './../../svg-assets/svg-assets.module';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    MaComRoutingModule,
    SvgAssetsModule
  ],
  declarations: [MaComComponent],
  
  exports: [MaComComponent]
})
export class MacomModule { }
