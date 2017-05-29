import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-line-comment-comments-details',
  templateUrl: './line-comment-comments-details.component.html',
  styleUrls: ['./line-comment-comments-details.component.scss']
})
export class LineCommentCommentsDetailsComponent implements OnInit {

 @Input() lineCommentsForm: FormGroup;
 
  public title = 'Details';  
  constructor(   
  ) { }

 ngOnInit() { 

  }

  
}
