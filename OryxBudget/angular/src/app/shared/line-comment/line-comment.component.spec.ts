import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLineDetailsComponent } from './create-line-details.component';

describe('CreateLineDetailsComponent', () => {
  let component: CreateLineDetailsComponent;
  let fixture: ComponentFixture<CreateLineDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateLineDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateLineDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
