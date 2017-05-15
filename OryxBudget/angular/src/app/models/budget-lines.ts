export interface BudgetLines {
    id: string;
    code: string;
    description: string;
    level: number;
    fatherNum: string;
    budget: number;
    budgetLC: number;
    budgetUSD: number;
    actual: number;
    actualLC: number;
    actualUSD: number;
    budgetId: string;   
}
