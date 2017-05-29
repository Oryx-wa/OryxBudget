import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineCommentCommentsComponent } from './line-comment-comments.component';

describe('LineCommentCommentsComponent', () => {
  let component: LineCommentCommentsComponent;
  let fixture: ComponentFixture<LineCommentCommentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineCommentCommentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineCommentCommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
