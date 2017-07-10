import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaComComponent } from './ma-com.component';

describe('MaComComponent', () => {
  let component: MaComComponent;
  let fixture: ComponentFixture<MaComComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaComComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaComComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
