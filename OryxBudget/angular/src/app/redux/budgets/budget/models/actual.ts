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

export const initActual: Actual = {
    id: '',
    code: '',
    description: '',
    level: '',
    fatherNum: '',
    opActualFC: 0,
    opActualLC: 0,
    opActualUSD: 0,
    opActualCInUSD: 0,
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
    lineStatus: '',
    budgetId: '',
    finalBudgetFC: 0,
}
