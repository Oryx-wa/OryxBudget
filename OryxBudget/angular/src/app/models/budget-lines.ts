export interface BudgetLines {
    id: string;
    code: string;
    description: string;
    level: string;
    fatherNum: string;
    opBudgetFC: number;
    opBudgetLC: number;
    opBudgetUSD: number;
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
    lineStatus: number;
    budgetId: string;
}
