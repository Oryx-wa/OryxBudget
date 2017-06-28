
export * from './actual';
//export * from './attachment';
export * from './budget';
export * from './budgetCode';
//export * from './budgetCodeView';
export * from './budgetLine';
export * from './budgetRun';
//export * from './category';
//export * from './period';
export * from './lineComment';
//export * from './statusHistory';


import { combineReducers } from '@ngrx/store';


import { ActualReducer, ActualState, initActualState } from './actual/actual.reducer';
// import { AttachmentReducer, AttachmentState } from './attachment/attachment.reducer';
import { BudgetReducer,BudgetState,  initBudgetState } from './budget/budget.reducer';
import { BudgetCodeReducer, BudgetCodeState, initBudgetCodeState } from './budgetCode/budgetCode.reducer';
// import { BudgetCodeViewReducer, BudgetCodeViewState } from './budgetCodeView/budgetCodeView.reducer';
import { BudgetLineReducer, BudgetLineState, initBudgetLineState } from './budgetLine/budgetLine.reducer';
import { BudgetRunReducer, BudgetRunState, initBudgetRunState } from './budgetRun/budgetRun.reducer';
// import { CategoryReducer, CategoryState } from './category/category.reducer';
// import { LineCommentReducer, LineCommentState } from './lineComment/lineComment.reducer';
// import { PeriodReducer, PeriodState } from './period/period.reducer';
// import { StatusHistoryReducer, StatusHistoryState } from './statusHistory/statusHistory.reducer';

const reducer = {

    actual: ActualReducer,
    // attachment: AttachmentReducer,
    budget: BudgetReducer,
    budgetCode: BudgetCodeReducer,
    // budgetCodeView: BudgetCodeViewReducer,
    budgetLine: BudgetLineReducer,
    budgetRun: BudgetRunReducer,
    // category: CategoryReducer,
    // lineComment: LineCommentReducer,
    // period: PeriodReducer,
    // statusHistory: StatusHistoryReducer
};

export const BudgetsReducer = combineReducers(reducer);

export interface BudgetsState {

    actual: ActualState;
    // attachment: AttachmentState;
    budget: BudgetState;
    budgetCode: BudgetCodeState;
    // budgetCodeView: BudgetCodeViewState;
    budgetLine: BudgetLineState;
    budgetRun: BudgetRunState;
    // category: CategoryState;
    // lineComment: LineCommentState;
    // period: PeriodState;
    // statusHistory: StatusHistoryState;
}

export const initBdState: BudgetsState = {
    actual: initActualState,
    budget: initBudgetState,
    budgetCode: initBudgetCodeState,
    budgetLine: initBudgetLineState,
    budgetRun: initBudgetRunState
};

