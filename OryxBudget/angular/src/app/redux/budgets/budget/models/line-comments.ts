export interface LineComments {
    id: string;
    comment: string;
    commentStatus: string;
    budgetId: string;
    code: string;
    userName: string;
    createDate: Date;
    userType: string;
    commentType: string;
}

export const initLineComments: LineComments = {
    id: '',
    comment: '',
    commentStatus: '',
    budgetId: '',
    code: '',
    userName: '',
    createDate: new Date(),
    userType: '',
    commentType: '',
};
