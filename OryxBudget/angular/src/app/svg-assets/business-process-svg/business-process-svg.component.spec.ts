import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessProcessSVGComponent } from './business-process-svg.component';

describe('BusinessProcessSVGComponent', () => {
  let component: BusinessProcessSVGComponent;
  let fixture: ComponentFixture<BusinessProcessSVGComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessProcessSVGComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessProcessSVGComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
