import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkprogramComponent } from './workprogram.component';

describe('WorkprogramComponent', () => {
  let component: WorkprogramComponent;
  let fixture: ComponentFixture<WorkprogramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkprogramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
