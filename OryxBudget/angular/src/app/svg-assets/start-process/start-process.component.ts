import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: '[app-start-process]',
  templateUrl: './start-process.component.html',
  styleUrls: ['./start-process.component.scss']
})
export class StartProcessComponent implements OnInit {
  @Input() text = 'Start';
  @Input() activeColour = 'green ';
  @Input() passiveColour = 'green lighten-5';
  @Input() textColor = 'black-text';
  @Output() onClicked = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
