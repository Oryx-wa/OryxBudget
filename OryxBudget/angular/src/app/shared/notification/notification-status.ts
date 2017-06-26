export interface NotificationStatus  {
  loading: boolean;
  loaded: boolean;
  saving: boolean;
  saved: boolean;
  loadingError: boolean;
  savingError: boolean;
  message: string;

}

export const initNotificatioStatus: NotificationStatus = {
  loading: false,
  loaded: false,
  saving: false,
  saved: false,
  loadingError: false,
  savingError: false,
  message: ''
};

Object.freeze(initNotificatioStatus);
