import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineActualsComponent } from './line-actuals.component';

describe('LineActualsComponent', () => {
  let component: LineActualsComponent;
  let fixture: ComponentFixture<LineActualsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineActualsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineActualsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
