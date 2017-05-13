import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  @Input() budgetId: string;
  @Input() type = 'Budget';
  constructor() { }

  ngOnInit() {
  }

}
