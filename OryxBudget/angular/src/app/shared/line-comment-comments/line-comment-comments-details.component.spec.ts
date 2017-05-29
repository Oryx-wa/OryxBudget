import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineCommentCommentsDetailsComponent } from './line-comment-comments-details.component';

describe('LineCommentCommentsDetailsComponent', () => {
  let component: LineCommentCommentsDetailsComponent;
  let fixture: ComponentFixture<LineCommentCommentsDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineCommentCommentsDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineCommentCommentsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
