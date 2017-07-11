import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CashCallComponent } from './cash-call.component';

describe('CashCallComponent', () => {
  let component: CashCallComponent;
  let fixture: ComponentFixture<CashCallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CashCallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CashCallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
