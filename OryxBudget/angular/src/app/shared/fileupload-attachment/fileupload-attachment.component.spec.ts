import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileuploadAttachmentComponent } from './fileupload-attachment.component';

describe('FileuploadAttachmentComponent', () => {
  let component: FileuploadAttachmentComponent;
  let fixture: ComponentFixture<FileuploadAttachmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileuploadAttachmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileuploadAttachmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
