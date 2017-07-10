export interface Notifications {
    id: string;
    description: string;
    urlData: string;
    lineCommentId: string;
    budgetCode: string;
    user: string;
    username: string;
    operatorId: string;
    workProgramId: number;
    isRead: boolean;
}

export const initNotifications: Notifications = {
    id: '',
    description: '',
    urlData: '',
    lineCommentId: '',
    budgetCode: '',
    user: '',
    username: '',
    operatorId: '',
    workProgramId: 1,
    isRead: false
}
