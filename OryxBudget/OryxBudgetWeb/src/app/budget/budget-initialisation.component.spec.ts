import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BudgetInitialisationComponent } from './budget-initialisation.component';

describe('BudgetInitialisationComponent', () => {
  let component: BudgetInitialisationComponent;
  let fixture: ComponentFixture<BudgetInitialisationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BudgetInitialisationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BudgetInitialisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
