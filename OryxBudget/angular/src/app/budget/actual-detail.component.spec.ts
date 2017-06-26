import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualDetailComponent } from './actual-detail.component';

describe('ActualDetailComponent', () => {
  let component: ActualDetailComponent;
  let fixture: ComponentFixture<ActualDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
