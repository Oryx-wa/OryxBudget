
export interface BudgetLine {
    id: string;
    rowNumber: string;
    code: string;
    description: string;

    opBudgetFC: number;
    opBudgetLC: number;
    opBudgetUSD: number;
    opBudgetLCInUSD: number;
    subComBudgetFC: number;
    subComBudgetLC: number;
    subComBudgetUSD: number;
    tecComBudgetFC: number;
    tecComBudgetLC: number;
    tecComBudgetUSD: number;
    malComBudgetFC: number;
    malComBudgetLC: number;
    malComBudgetUSD: number;
    finalBudgetFC: number;
    finalBudgetLC: number;
    finalBudgetUSD: number;
    lineStatus: string;
    approvalStatus: string;
    budgetId: string;
    categoryId: string;
}
