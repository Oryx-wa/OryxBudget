import { Component, NgZone, Inject, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { UploadOutput, UploadInput, UploadFile, humanizeBytes } from 'ngx-uploader';
import { Http, Response, Headers, URLSearchParams, ResponseContentType } from '@angular/http';
import { SecurityService } from './../../login/security.service';
import { Configuration } from './../../app.constants';
import { DisplayModeEnum } from './../shared-enum.enum'

import * as FileSaver from 'file-saver';

import 'rxjs/add/operator/catch';

@Component({
  selector: 'app-fileuploader',
  templateUrl: './fileuploader.component.html',
  styleUrls: ['./fileuploader.component.scss']
})
export class FileuploaderComponent implements OnInit {
  @Input() allowedExtensions: string[] = ['csv'];
  @Input() data: any;
  @Input() fieldName: string = 'file';
  @Input() fieldReset: boolean = true;
  @Input() method: string = 'POST';
  @Input() previewUrl: boolean = true;
  @Input() withCredentials: boolean = false;
  @Input() autoUpload: boolean = false;
  @Input() url: string = '';
  @Input() maxUploads: number = 1;
  @Input() showDownload: boolean = false;
  @Input() templatePath: string;
  @Input() title = '';

  @Output() done = new EventEmitter();


  files: UploadFile[];
  uploadInput: EventEmitter<UploadInput>;
  humanizeBytes: Function;
  dragOver: boolean;


  constructor(private securityService: SecurityService) {
    // this.url = config.apiServer + '/' + this.url;


    this.files = []; // local uploading files array
    this.uploadInput = new EventEmitter<UploadInput>(); // input events, we use this to emit data to ngx-uploader
    this.humanizeBytes = humanizeBytes;

  }

  ngOnInit() {

  }



  onUploadOutput(output: UploadOutput): void {
    // console.log(output); // lets output to see what's going on in the console

    if (output.type === 'allAddedToQueue') { // when all files added in queue
      // uncomment this if you want to auto upload files when added
      // const event: UploadInput = {
      //   type: 'uploadAll',
      //   url: '/upload',
      //   method: 'POST',
      //   data: { foo: 'bar' },
      //   concurrency: 0
      // };
      // this.uploadInput.emit(event);
    } else if (output.type === 'addedToQueue') {
      this.files.push(output.file); // add file to array when added
    } else if (output.type === 'uploading') {
      // update current data in files array for uploading file
      const index = this.files.findIndex(file => file.id === output.file.id);
      this.files[index] = output.file;
    } else if (output.type === 'removed') {
      // remove file from array when removed
      this.files = this.files.filter((file: UploadFile) => file !== output.file);
    } else if (output.type === 'dragOver') { // drag over event
      this.dragOver = true;
    } else if (output.type === 'dragOut') { // drag out event
      this.dragOver = false;
    } else if (output.type === 'drop') { // on drop event
      this.dragOver = false;
    }
  }

  startUpload(): void {  // manually start uploading
    const event: UploadInput = {
      type: 'uploadAll',
      url: this.securityService.getUrl(this.url),
      method: 'POST',
      data: this.data,
      concurrency: 1, // set sequential uploading of files with concurrency 1,
      headers: {['Authorization']: 'Bearer ' + this.securityService.GetToken()}

    }

    this.uploadInput.emit(event);
  }

  cancelUpload(id: string): void {
    this.uploadInput.emit({ type: 'cancel', id: id });
  }

  protected getHeaders = (): Headers => {
    let headers = new Headers();
    headers.append('Content-Type', 'application/csv');
    headers.append('Accept', 'application/csv');

    return headers;
  }
}
