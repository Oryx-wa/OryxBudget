export interface LineStatus {
    code: string;
    budgetId: string;
    status: string;
}

export const initLineStatus: LineStatus = {
    code: '',
    budgetId: '',
    status: '',
};