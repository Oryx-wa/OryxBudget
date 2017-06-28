export interface Budgets {
    id: string;
    operatorId: string;
    opBudgetFC: number;
    opBudgetLC: number;
    opBudgetUSD: number;
    subComBudgetFC: number;
    subComBudgetLC: number;
    subComBudetUSD: number;
    tecComBudgetFC: number;
    tecComBudgetLC: number;
    tecComBudetUSD: number;
    malComBudgetFC: number;
    malComBudgetLC: number;
    malComBudetUSD: number;
    finalBudgetFC: number;
    finalBudgetLC: number;
    finalBudetUSD: number;
    description: string;
}

export const initBudget: Budgets = {
    id: '',
    operatorId: '',
    opBudgetFC: 0,
    opBudgetLC: 0,
    opBudgetUSD: 0,
    subComBudgetFC: 0,
    subComBudgetLC: 0,
    subComBudetUSD: 0,
    tecComBudgetFC: 0,
    tecComBudgetLC: 0,
    tecComBudetUSD: 0,
    malComBudgetFC: 0,
    malComBudgetLC: 0,
    malComBudetUSD: 0,
    finalBudgetFC: 0,
    finalBudgetLC: 0,
    finalBudetUSD: 0,
    description: '',
}
