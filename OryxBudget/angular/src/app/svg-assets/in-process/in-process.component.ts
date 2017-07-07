import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: '[app-in-process]',
  templateUrl: './in-process.component.html',
  styleUrls: ['./in-process.component.scss']
})
export class InProcessComponent implements OnInit {
  @Input() text = 'Start';
  @Input() activeColour = 'green ';
  @Input() passiveColour = 'green lighten-5';
  @Input() textColor = 'black-text';
  @Output() onClicked = new EventEmitter();
  constructor() { }


  ngOnInit() {
  }

}
