import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';

import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {
  @Input() loading: boolean;
  @Input() saving: boolean;

  public options = {
    timeOut: 3000,
    lastOnBottom: true,
    clickToClose: true,
    maxLength: 0,
    maxStack: 7,
    showProgressBar: true,
    pauseOnHover: true,
    preventDuplicates: false,
    preventLastDuplicates: 'visible',
    rtl: false,
    animate: 'scale',
    position: ['right', 'top']
  };
  constructor(private _service: NotificationsService) { }

  ngOnInit() {
  }

}
