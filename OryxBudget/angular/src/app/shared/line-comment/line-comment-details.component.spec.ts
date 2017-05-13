import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineCommentDetailsComponent } from './line-comment-details.component';

describe('LineCommentDetailsComponent', () => {
  let component: LineCommentDetailsComponent;
  let fixture: ComponentFixture<LineCommentDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineCommentDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineCommentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
