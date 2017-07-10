import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { D3Service } from 'd3-ng2-service';
import { BusinessProcessSVGComponent } from './business-process-svg/business-process-svg.component';


import { BarChartComponent } from './bar-chart/bar-chart.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BusinessProcessSVGComponent, BarChartComponent],
  providers: [D3Service],
  exports: [BusinessProcessSVGComponent, BarChartComponent]

})
export class SvgAssetsModule { }
