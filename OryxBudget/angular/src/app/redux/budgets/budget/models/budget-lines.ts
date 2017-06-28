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
    opActualFC: number;
    opActualLC: number;
    opActualUSD: number;
    subComActualFC: number;
    subComActualLC: number;
    subComActualUSD: number;
    tecComActualFC: number;
    tecComActualLC: number;
    tecComActualUSD: number;
    malComActualFC: number;
    malComActualLC: number;
    malComActualUSD: number;
    finalActualFC: number;
    finalActualLC: number;
    finalActualUSD: number;
    lineStatus: number;
    budgetId: string;
}

export const initBudgetLines: BudgetLines = {
    id: '',
    code: '',
    description: '',
    level: '',
    fatherNum: '',
    opBudgetFC: 0,
    opBudgetLC: 0,
    opBudgetUSD: 0,
    subComBudgetFC: 0,
    subComBudgetLC: 0,
    subComBudgetUSD: 0,
    tecComBudgetFC: 0,
    tecComBudgetLC: 0,
    tecComBudgetUSD: 0,
    malComBudgetFC: 0,
    malComBudgetLC: 0,
    malComBudgetUSD: 0,
    finalBudgetFC: 0,
    finalBudgetLC: 0,
    finalBudgetUSD: 0,
    opActualFC: 0,
    opActualLC: 0,
    opActualUSD: 0,
    subComActualFC: 0,
    subComActualLC: 0,
    subComActualUSD: 0,
    tecComActualFC: 0,
    tecComActualLC: 0,
    tecComActualUSD: 0,
    malComActualFC: 0,
    malComActualLC: 0,
    malComActualUSD: 0,
    finalActualFC: 0,
    finalActualLC: 0,
    finalActualUSD: 0,
    lineStatus: 0,
    budgetId: '',
};

