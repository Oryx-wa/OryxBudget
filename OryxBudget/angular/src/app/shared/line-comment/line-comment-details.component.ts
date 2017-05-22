import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-line-comment-details',
  templateUrl: './line-comment-details.component.html',
  styleUrls: ['./line-comment-details.component.scss']
})
export class LineCommentDetailsComponent implements OnInit {
 @Input() lineCommentForm: FormGroup;
  constructor() { }

  ngOnInit() {
  }

}
