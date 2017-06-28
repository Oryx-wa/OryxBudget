export * from './operators';
export * from './budget';
export * from './budget-lines';
export * from './line-comments';
export * from './linestatus';
export * from './actual';

import { Schema, arrayOf } from 'normalizr/lib';

export const budgetSchema = new Schema('Budget');
export const linesSchema = new Schema('BudgetLines');
export const actualSchema = new Schema('Actual');
export const lineCommentsSchema = new Schema('LineComments');

export const arrayOfBudget = arrayOf(budgetSchema);
export const arrayOfLines = arrayOf(linesSchema);
export const arrayOfActuals = arrayOf(actualSchema);
export const arrayOfLineComments = arrayOf(lineCommentsSchema);


