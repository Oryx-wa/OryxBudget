import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusinessProcessSVGComponent } from './business-process-svg/business-process-svg.component';

import { StartProcessComponent } from './start-process/start-process.component';
import { InProcessComponent } from './in-process/in-process.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BusinessProcessSVGComponent, StartProcessComponent, InProcessComponent],
  exports: [BusinessProcessSVGComponent]
  
})
export class SvgAssetsModule { }
