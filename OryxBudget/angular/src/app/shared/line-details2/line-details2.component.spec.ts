import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineDetails2Component } from './line-details2.component';

describe('LineDetails2Component', () => {
  let component: LineDetails2Component;
  let fixture: ComponentFixture<LineDetails2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineDetails2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineDetails2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
