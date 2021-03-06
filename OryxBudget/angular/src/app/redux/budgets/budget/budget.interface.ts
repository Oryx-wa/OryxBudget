export interface Budget {
    id: string;
    description: string;
    additionalStatement: string;
    periodId: string;
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
}
