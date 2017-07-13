import { Component, ElementRef, NgZone, OnDestroy, OnInit, Input, Output } from '@angular/core';
import * as d3 from 'd3';
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


  private parentNativeElement: any;

  private data: any[];

  constructor(element: ElementRef, private ngZone: NgZone) {

    this.parentNativeElement = element.nativeElement;
  }

  ngOnInit() {
    this.setupData();





    // let d3G: Selection<SVGGElement, any, null, undefined>;

    // const context: CanvasRenderingContext2D;
    const margin = { top: 20, right: 30, bottom: 30, left: 40 };
    const formatPercent = d3.format(',');
    const data = this.data;

    const width = this.width - margin.left - margin.right;
    const height = this.height - margin.top - margin.bottom;

    const barWidth = width / data.length;

    const x = d3.scaleBand()
      .range([0, width])
      .padding(0.1);

    const y = d3.scaleLinear()
      .range([height, 0]);

    x.domain(this.data.map(function (d) { return d.label; }));
    y.domain([0, d3.max(data, function (d) { return d.value; })]);

    const g = d3.select('svg')
      .attr('width', width + margin.left + margin.right)
      .attr('height', height + margin.top + margin.bottom)
      .append('g')
      .attr('transform',
      'translate(' + margin.left + ',' + margin.top + ')');



    const yAxis = d3.axisBottom(y)
      .ticks(10);

    const xAxis = d3.axisLeft(x);

    g.selectAll('bar')
      .data(data)
      .enter().append('rect')
      .attr('class', 'bar')
      .attr('x', function (d) { return x(d.label); })
      .attr('width', x.bandwidth())
      .attr('y', function (d) { return y(d.value); })
      .attr('height', function (d) { return height - y(d.value); });

    // add the x Axis
    g.append('g')
      .attr('transform', 'translate(0,' + height + ')')
      .call(d3.axisBottom(x))
      .selectAll('text')
      .style('text-anchor', 'end')
      .attr('dx', '-.8em')
      .attr('dy', '-.55em')
      .attr('transform', 'rotate(-90)' );;

    // add the y Axis
    g.append('g')
      .call(d3.axisLeft(y))
      .append('text')
      .attr('transform', 'rotate(-90)')
      .attr('y', 6)
      .attr('dy', '.71em')
      .style('text-anchor', 'end')
      .text('Value ($)');

    /*
        g.append('g')
          .attr('class', 'x axis')
          .attr('transform', 'translate(0,' + height + ')')
          .call(xAxis)
          .selectAll('text')
          .style('text-anchor', 'end')
          .attr('dx', '-.8em')
          .attr('dy', '-.55em')
          .attr('transform', 'rotate(-90)');

        g.append('g')
          .attr('class', 'y axis')
          .call(yAxis)
          .append('text')
          .attr('transform', 'rotate(-90)')
          .attr('y', 6)
          .attr('dy', '.71em')
          .style('text-anchor', 'end')
          .text('Value ($)');



        g.selectAll('bar')
          .data(data)
          .enter().append('rect')
          .style('fill', 'steelblue')
          .attr('x', function (d) { return x(d.label); })
          .attr('width', x.bandwidth())
          .attr('y', function (d) { return y(d.value); })
          .attr('height', function (d) { return height - y(d.value); });


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
