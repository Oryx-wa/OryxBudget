import { Schema, arrayOf } from 'normalizr/lib';
import { Attachment } from './attachment.interface';
export const attachmentSchema = new Schema('Attachment');
export const arrayOfAttachment = arrayOf(attachmentSchema);



export const initAttachment: Attachment = {
    id: '',
    budgetLineId: '',
    code: '',
    fileData: '',
    fileName: '',
    fileType: '',
    budgetId: '',

};
export interface AttachmentEntity {
    [id: string]: Attachment;
}
