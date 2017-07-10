import { Schema, arrayOf } from 'normalizr/lib';
import { Notification } from './notification.interface';

export const notificationSchema = new Schema('Notification');
export const arrayOfNotification = arrayOf(notificationSchema);


export const initNotification: Notification = {
    id: null,
    description: '',
    urlData: '',
    lineCommentId: '',
    budgetCode: '',
    user: '',
    username: '',
    operatorId: '',
    workProgramId: '',
    isRead: false
};

export interface NotificationEntity {
    [id: string]: Notification;
}
