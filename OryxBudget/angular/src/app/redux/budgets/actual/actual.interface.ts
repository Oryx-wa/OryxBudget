export interface Actual {
    id: string;
    code: string;
    description: string;
    level: string;
    fatherNum: string;
    opActualFC: number;
    opActualLC: number;
    opActualUSD: number;
    opActualCInUSD: number;
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
    lineStatus: string;
    budgetId: string;
    finalBudgetFC: number;
}
