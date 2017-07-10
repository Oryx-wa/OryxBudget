import { Component, ElementRef, NgZone, OnDestroy, OnInit, Input, Output } from '@angular/core';
import { D3Service, D3, RGBColor, Selection, Timer, ScaleLinear } from 'd3-ng2-service';
import * as _ from 'lodash';

@Component({
  selector: 'app-bar-chart',
  template: `
    
    <svg class="chart" [attr.width]="height" [attr.height]="width"></svg>
  `,
  styles: []
})
export class BarChartComponent implements OnInit {
  @Input() dataset: any[];
  @Input() width = 300;
  @Input() height = 300;
  @Input() labelField: string;
  @Input() valueField: string;

  private d3: D3;
  private parentNativeElement: any;
  private d3Svg: Selection<SVGSVGElement, any, null, undefined>;
  private timer: Timer;
  private data: any[];

  constructor(element: ElementRef, private ngZone: NgZone, d3Service: D3Service) {
    this.d3 = d3Service.getD3();
    this.parentNativeElement = element.nativeElement;
  }

  ngOnInit() {
    this.setupData();

    const d3 = this.d3;


    let d3ParentElement: Selection<HTMLElement, any, null, undefined>;
    let chart: Selection<SVGSVGElement, any, null, undefined>;
    // let d3G: Selection<SVGGElement, any, null, undefined>;

    // const context: CanvasRenderingContext2D;
    let width: number;
    let height: number;
    if (this.parentNativeElement !== null) {
      d3ParentElement = d3.select(this.parentNativeElement);
      chart = this.d3Svg = d3ParentElement.select<SVGSVGElement>('svg');
      const margin = { top: 20, right: 30, bottom: 30, left: 40 };
      // width = this.width;
      // height = this.height;
      const data = this.data;
      console.log(data);

      width = this.width - margin.left - margin.right;
      height = this.height - margin.top - margin.bottom;
      const x = d3.scaleLinear()
        .domain([0, d3.max(data, function (d) { return d.value; })])
        .range([0, width]);

      const y = d3.scaleLinear()
        .domain([0, d3.max(data, function (d) { return d.value; })])
        .range([height, 0]);



      // x.domain(data.map(function (d) { return d.label; }));
      // y.domain([0, 1000000]);

      const barWidth = width / data.length;

      const g = chart.append('g')
        .attr('transform', 'translate(' + margin.left + ',' + margin.right + ')');

      g.append('g')
        .attr('class', 'axis axis--x')
        .attr('transform', 'translate(0,' + height + ')')
        .call(d3.axisBottom(x));

      g.append('g')
        .attr('class', 'axis axis--y')
        .call(d3.axisLeft(y).ticks(10, '%'))
        .append('text')
        .attr('transform', 'rotate(-90)')
        .attr('y', 6)
        .attr('dy', '0.71em')
        .attr('text-anchor', 'end')
        .text('Code');

      const bar = g.selectAll('g')
        .data(data)
        .enter().append('rect')
        .attr('class', 'bar')
        .attr('x', function (d) { return x(d.value); })
        .attr('y', function (d) { return y(d.value); })
        .attr('width', barWidth - 1)
        .attr('height', function (d) { return height - y(d.value); });
      /*
            bar.append('rect')
              .attr('y', function (d) { return y(d.value); })
              .attr('height', function (d) { return height - y(d.value); })
              .attr('width', barWidth - 1);
      
            bar.append('text')
              .attr('x', barWidth / 2)
              .attr('y', function (d) { return y(d.value) + 3; })
              .attr('dy', '.75em')
              .text(function (d) { return d.label; });
              */
    }
  }

  setupData() {
    const labelField = this.labelField;
    const valueField = this.valueField;
    this.data = _.map(this.dataset, function (obj) {
      const ret = _.transform(obj, function (result, value, key: string) {
        switch (key) {
          case labelField:
            result['label'] = value;
            break;
          case valueField:
            result['value'] = +value;
            break;
        }
      }, {});
      return ret;
    });
    // this.data = ret;

  }

}
