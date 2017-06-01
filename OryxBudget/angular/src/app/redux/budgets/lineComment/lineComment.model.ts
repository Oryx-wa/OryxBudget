import { Schema, arrayOf } from 'normalizr/lib';
import { LineComment } from './lineComment.interface';
export const lineCommentSchema = new Schema('LineComment');
export const arrayOfLineComment = arrayOf(lineCommentSchema);



export const initLineComment: LineComment = {
    id: '',
    code: '',
    userType: '',
    budgetId: '',
    comment: '',
    commentStatus: '',
    userName: '',
    userEmail: '',
    commentType: '',

};
export interface LineCommentEntity {
    [id: string]: LineComment;
}
