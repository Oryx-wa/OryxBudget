import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-business-process-svg',
  templateUrl: './business-process-svg.component.html',
  styleUrls: ['./business-process-svg.component.scss']
})
export class BusinessProcessSVGComponent implements OnInit {
  @Input() text: string[] = ['Start', 'In Process', 'End'];
  @Input() activeColour = '#a5d6a7 ';
  @Input() passiveColour = '#e8f5e9';
  @Input() textColor = 'black-text';
  @Output() onClicked = new EventEmitter();

  start: string;
  end: string;
  remaining: string[] = [];
  constructor() { }

  ngOnInit() {
    this.start = this.text[0];
    this.end = this.text[this.text.length - 1];
    this.remaining = Array.from(this.text);
    this.remaining.shift();
    this.remaining.pop();

  }

}
