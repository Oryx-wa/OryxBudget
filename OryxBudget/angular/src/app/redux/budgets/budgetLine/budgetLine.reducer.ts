import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budgetLine.action';
import { BudgetLines } from './budgetLine.interface';
import {
    arrayOfBudgetLine, BudgetLineEntity,
    budgetLineSchema, initBudgetLines
} from './budgetLine.model';

import { updateObject } from '../../utilities';

export interface BudgetLineState {
    ids: string[];
    entities: BudgetLineEntity;
    lastUpdate: Date;
    selectedId: string | null;
    untouched: BudgetLineEntity;
    touched: boolean;
    signOffStatus: number;
    filtered: boolean;
}

export const initBudgetLineState: BudgetLineState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
    untouched: {},
    touched: false,
    signOffStatus: 0,
    filtered: false
};
export const BudgetLineReducer: ActionReducer<BudgetLineState> = (state: BudgetLineState = initBudgetLineState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudgetLine: any = normalize(action.payload, budgetLineSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudgetLine.result),
                entities: _.merge({}, state.entities, newBudgetLine.entities.BudgetLine),
                lastUpdate: new Date(),
                selectedId: newBudgetLine.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const BudgetLine: any = normalize(action.payload, arrayOfBudgetLine);

            return updateObject({}, updateObject(state, {
                ids: BudgetLine.result,
                entities: BudgetLine.entities.BudgetLine,
                lastUpdate: new Date(),
                selectedId: state.selectedId,
                untouched: BudgetLine.entities.BudgetLine,
                touched: false,
            }));
        case AllActions.SELECT:
            return _.assign({}, state, { selectedId: action.payload });
        case AllActions.FILTER:
            return _.assign({}, state, { filtered: action.payload });
        case AllActions.RESET:
            return initBudgetLineState;
        case AllActions.UPDATE_STATUS:
            const line = () => {
                const bdLine = state.entities[action.payload.code];
                return updateStatus(bdLine, action.payload.status);
            };
            return Object.assign({}, state, {
                ids: state.ids,
                entities: _.merge({}, state.entities, line().entities.BudgetLine),
                lastUpdate: new Date(),
                selectedId: state.selectedId,
                touched: true
            });
        case AllActions.UPDATE_STATUS_VALUE:
            const line1 = () => {
                const bdLine = state.entities[action.payload.code];
                return updateStatusWithValue(bdLine, bdLine.workProgramStatus, action.payload)

            };
            return Object.assign({}, state, {
                ids: state.ids,
                entities: _.merge({}, state.entities, line1().entities.BudgetLine),
                lastUpdate: new Date(),
                selectedId: state.selectedId,
                touched: true
            });
        case AllActions.UPDATE_UNTOUCHED:
            const untouched = () => {
                const ret = [];
                state.ids.map(id => {
                    ret.push(updateUnTouched(state.entities[id], action.payload));
                });
                return normalize(ret, arrayOfBudgetLine);
            };
            return Object.assign({}, state, {
                ids: state.ids,
                entities: _.merge({}, state.entities, untouched().entities.BudgetLine),
                lastUpdate: new Date(),
                selectedId: state.selectedId,
                touched: true
            });
        case AllActions.RESET_APPROVAL_UPDATES:
            return _.assign({}, state, {
                entities: state.untouched,
                touched: false
            })

        default:
            return state;
    }
};
export const getBudgetLineEntities = (state: BudgetLineState) => state.entities;
export const getBudgetLineIds = (state: BudgetLineState) => state.ids;
export const getSelectedBudgetLineId = (state: BudgetLineState) => state.selectedId;
export const getTouched = (state: BudgetLineState) => state.touched;
export const getFiltered = (state: BudgetLineState) => state.filtered;

export const getSelectedBudgetLine
    = createSelector(getBudgetLineEntities, getSelectedBudgetLineId, getFiltered, (entities, selectedId, filtered) => {
        if (selectedId === null) {
            return initBudgetLines;
        }
        const ret = entities[selectedId];
        if (filtered) {
            if (ret.lineStatus < 3) {
                return ret;
            }
        } else {
            return entities[selectedId];
        }

    });

function updateStatus(bdLine: BudgetLines, status: number) {
    switch (bdLine.workProgramStatus) {
        case 1:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        subComBudgetFC: bdLine.opBudgetFC,
                        subComBudgetLC: bdLine.opBudgetLC,
                        subComBudgetUSD: bdLine.opBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 2:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        tecComBudgetFC: (bdLine.subComBudgetFC === 0) ?
                            bdLine.opBudgetFC : bdLine.subComBudgetFC,
                        tecComBudgetLC: (bdLine.subComBudgetLC === 0) ?
                            bdLine.opBudgetLC : bdLine.subComBudgetLC,
                        tecComBudgetUSD: (bdLine.subComBudgetUSD === 0) ?
                            bdLine.opBudgetUSD : bdLine.subComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 3:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        malComBudgetFC: (bdLine.tecComBudgetFC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetFC,
                        malComBudgetLC: (bdLine.tecComBudgetLC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetLC,
                        malComBudgetUSD: (bdLine.tecComBudgetUSD === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetUSD,
                        finalBudgetFC: bdLine.malComBudgetFC,
                        finalBudgetLC: bdLine.malComBudgetLC,
                        finalBudgetUSD: bdLine.malComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 4:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        finalBudgetFC: (bdLine.malComBudgetFC === 0) ?
                            bdLine.tecComBudgetFC : bdLine.malComBudgetFC,
                        finalBudgetLC: (bdLine.tecComBudgetLC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetLC,
                        finalBudgetUSD: (bdLine.malComBudgetUSD === 0) ?
                            bdLine.tecComBudgetFC : bdLine.malComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        default:
            return _.assign({}, normalize(bdLine,
                budgetLineSchema));

    }
}

function updateStatusWithValue(bdLine: BudgetLines, status: number, value: BudgetLines) {
    switch (bdLine.workProgramStatus) {
        case 1:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        subComBudgetFC: value.subComBudgetFC,
                        subComBudgetLC: value.subComBudgetLC,
                        subComBudgetUSD: value.subComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 2:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        tecComBudgetFC: value.tecComBudgetFC,
                        tecComBudgetLC: value.tecComBudgetLC,
                        tecComBudgetUSD: value.tecComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 3:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        malComBudgetFC: value.malComBudgetFC,
                        malComBudgetLC: value.malComBudgetLC,
                        malComBudgetUSD: value.malComBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        case 4:
            return _.assign({}, normalize(
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        finalBudgetFC: value.finalBudgetFC,
                        finalBudgetLC: value.finalBudgetLC,
                        finalBudgetUSD: value.finalBudgetUSD,
                        touched: true,
                    }),
                budgetLineSchema));
        default:
            return _.assign({}, normalize(bdLine,
                budgetLineSchema));

    }
}

function updateUnTouched(bdLine: BudgetLines, status: number) {
    switch (bdLine.workProgramStatus) {
        case 1:
            return (bdLine.subComBudgetFC === 0) ?
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        subComBudgetFC: bdLine.opBudgetFC,
                        subComBudgetLC: bdLine.opBudgetLC,
                        subComBudgetUSD: bdLine.opBudgetUSD,
                        touched: true,
                    }) :
                bdLine;

        case 2:
            return (bdLine.tecComBudgetFC === 0) ?
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        tecComBudgetFC: (bdLine.subComBudgetFC === 0) ?
                            bdLine.opBudgetFC : bdLine.subComBudgetFC,
                        tecComBudgetLC: (bdLine.subComBudgetLC === 0) ?
                            bdLine.opBudgetLC : bdLine.subComBudgetLC,
                        tecComBudgetUSD: (bdLine.subComBudgetUSD === 0) ?
                            bdLine.opBudgetUSD : bdLine.subComBudgetUSD,
                        touched: true,
                    }) :
                bdLine;
        case 3:
            return (bdLine.malComActualFC === 0) ?
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        malComBudgetFC: (bdLine.tecComBudgetFC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetFC,
                        malComBudgetLC: (bdLine.tecComBudgetLC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetLC,
                        malComBudgetUSD: (bdLine.tecComBudgetUSD === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetUSD,
                        touched: true,
                    }) :
                bdLine;
        case 4:
            return (bdLine.finalBudgetFC === 0) ?
                _.assign({}, bdLine,
                    {
                        lineStatus: status,
                        finalBudgetFC: (bdLine.malComBudgetFC === 0) ?
                            bdLine.tecComBudgetFC : bdLine.malComBudgetFC,
                        finalBudgetLC: (bdLine.tecComBudgetLC === 0) ?
                            bdLine.subComBudgetFC : bdLine.tecComBudgetLC,
                        finalBudgetUSD: (bdLine.malComBudgetUSD === 0) ?
                            bdLine.tecComBudgetFC : bdLine.malComBudgetUSD,
                        touched: true,
                    }) :
                bdLine;
        default:
            return bdLine;

    }
}
