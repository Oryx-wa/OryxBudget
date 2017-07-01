import { Injectable } from '@angular/core';
import { default as swal, SweetAlertType } from 'sweetalert2';

/**
 * Async modal dialog service
 * DialogService makes this app easier to test by faking this service.
 * TODO: better modal implementation that doesn't use window.confirm
 */
@Injectable()
export class DialogService {
  /**
   * Ask user to confirm an action. `message` explains the action and choices.
   * Returns promise resolving to `true`=confirm or `false`=cancel
   */
  confirm(message?: string) {
    return new Promise<boolean>(resolve => {
      return resolve(window.confirm(message || 'Is it OK?'));
    });
  };

   confirmAlert(title: string, message: string, type: alertTypeEnum) {
      const typeString = <SweetAlertType>alertTypeEnum[type];
        return swal({
            title: title,
            text: message,
            type: typeString,
            showCancelButton: true
        });
    };
}

export enum alertTypeEnum {
  success = 1,
  error = 2,
  warning = 3,
  info = 4,
  question = 5
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/