import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualsComponent } from './actuals.component';

describe('ActualsComponent', () => {
  let component: ActualsComponent;
  let fixture: ComponentFixture<ActualsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
