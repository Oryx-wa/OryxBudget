import {
  Component, OnInit,
  Input, Output, EventEmitter, ElementRef, ViewChild
} from '@angular/core';

@Component({
  selector: 'app-business-process-svg',
  templateUrl: './business-process-svg.component.html',
  styleUrls: ['./business-process-svg.component.scss']
})
export class BusinessProcessSVGComponent implements OnInit {
  @Input() text: string[] = ['Start', 'In Process', 'End'];
  @Input() activeColour = '#4caf50 ';
  @Input() passiveColour = '#DFDFDF';
  @Input() textColor = 'black-text';
  @Input() active = 0;
  @Output() onClicked = new EventEmitter();




  start: string;
  end: string;
  lastNum: number;
  remaining: string[] = [];
  buttonWidth = 109;
  buttonheight = 50;
  viewBox = '0 0 109 50 ';

  constructor() { }

  ngOnInit() {
    this.start = this.text[0];
    this.end = this.text[this.text.length - 1];
    this.lastNum = this.text.length - 1;
    this.remaining = Array.from(this.text);
    this.remaining.shift();
    this.remaining.pop();


  }

  colourActive = (id: number) => {
    if (this.active === id) {
      return this.activeColour;
    } else {
      return this.passiveColour;
    }
  }

  textActive = (id: number) => {
    if (this.active === id) {
      return 'white';
    } else {
      return '#9F9F9F';
    }
  }

}
