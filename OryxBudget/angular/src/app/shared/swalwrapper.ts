import swal from 'sweetalert2';
import { UploadOutput, UploadInput, UploadFile, humanizeBytes, NgUploaderService, UploadStatus } from 'ngx-uploader';
import {Observable} from 'rxjs/Observable';


export function upload(uploadInput: UploadInput) {

  return swal({
    title: 'No Budget Details',
    type: 'question',
    text: 'Do you want to upload budget?',
    showCloseButton: true,
    showCancelButton: true,
    confirmButtonText:
    ' Upload ',
    confirmButtonClass: 'waves-effect waves-light btn',
    cancelButtonText:
    'Cancel',
    cancelButtonClass: 'waves-effect waves-light btn',
    buttonsStyling: false

  }).then(function () {
    swal({
      title: 'Select File',
      input: 'file',
      inputAttributes: {
        accept: '*/*'
      }
    }).then(function (file) {

      // console.log(uploadInput);
      const ngx = new NgUploaderService();
      uploadFile(file, uploadInput).subscribe(data => console.log(data));
    });
  });
}

function uploadFile(file: any, event: UploadInput) {
  return new Observable(observer => {
    const url = event.url;
    const method = event.method || 'POST';
    const data = event.data || {};
    const headers = event.headers || {};

    const reader = new FileReader();
    const xhr = new XMLHttpRequest();
    let time: number = new Date().getTime();
    let load = 0;

    xhr.upload.addEventListener('progress', (e: ProgressEvent) => {
      if (e.lengthComputable) {
        const percentage = Math.round((e.loaded * 100) / e.total);
        const diff = new Date().getTime() - time;
        time += diff;
        load = e.loaded - load;
        const speed = parseInt((load / diff * 1000) as any, 10);

        file.progress = {
          status: UploadStatus.Uploading,
          data: {
            percentage: percentage,
            speed: speed,
            speedHuman: `${humanizeBytes(speed)}/s`
          }
        };

        observer.next({ type: 'uploading', file: file });
      }
    }, false);

    xhr.upload.addEventListener('error', (e: Event) => {
      observer.error(e);
      observer.complete();
    });

    xhr.onreadystatechange = () => {
      if (xhr.readyState === XMLHttpRequest.DONE) {
        file.progress = {
          status: UploadStatus.Done,
          data: {
            percentage: 100,
            speed: null,
            speedHuman: null
          }
        };

        try {
          file.response = JSON.parse(xhr.response);
        } catch (e) {
          file.response = xhr.response;
        }

        observer.next({ type: 'done', file: file });
        observer.complete();
      }
    };

    xhr.open(method, url, true);

    const form = new FormData();

    try {
      form.append('file', file, file.name);

      Object.keys(data).forEach(key => form.append(key, data[key]));
      Object.keys(headers).forEach(key => xhr.setRequestHeader(key, headers[key]));

      // this.serviceEvents.emit({ type: 'start', file: file });
      xhr.send(form);

    } catch (e) {
      observer.complete();
    }

    return () => {
      xhr.abort();
      reader.abort();
    };
  });
}