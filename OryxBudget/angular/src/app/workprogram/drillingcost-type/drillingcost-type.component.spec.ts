import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrillingcostTypeComponent } from './drillingcost-type.component';

describe('DrillingcostTypeComponent', () => {
  let component: DrillingcostTypeComponent;
  let fixture: ComponentFixture<DrillingcostTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrillingcostTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrillingcostTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
