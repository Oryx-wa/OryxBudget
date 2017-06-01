import { Schema, arrayOf } from 'normalizr/lib';
import { Category } from './category.interface';
export const categorySchema = new Schema('Category');
export const arrayOfCategory = arrayOf(categorySchema);



export const initCategory: Category = {
    id: '',
    code: '',
    description: '',


};
export interface CategoryEntity {
    [id: string]: Category;
}
