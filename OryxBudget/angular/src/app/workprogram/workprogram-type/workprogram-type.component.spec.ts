import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkprogramTypeComponent } from './workprogram-type.component';

describe('WorkprogramTypeComponent', () => {
  let component: WorkprogramTypeComponent;
  let fixture: ComponentFixture<WorkprogramTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkprogramTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkprogramTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
