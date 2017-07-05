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
}

export const initBudgetLineState: BudgetLineState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
    untouched: {},
    touched: false,
    signOffStatus: 0,
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
        case AllActions.RESET:
            return initBudgetLineState;
        case AllActions.UPDATE_STATUS:
            const line = () => {
                const bdLine = state.entities[action.payload.code];
                switch (bdLine.workProgramStatus) {
                    case 1:
                        return _.assign({}, normalize(
                            _.assign({}, bdLine,
                                {
                                    lineStatus: action.payload.status,
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
                                    lineStatus: action.payload.status,
                                    tecComBudgetFC: bdLine.subComBudgetFC,
                                    tecComBudgetLC: bdLine.subComBudgetLC,
                                    tecComBudgetUSD: bdLine.subComBudgetUSD,
                                    touched: true,
                                }),
                            budgetLineSchema));
                    default:
                        return _.assign({}, normalize(line,
                            budgetLineSchema));

                }
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
                switch (bdLine.workProgramStatus) {
                    case 1:
                        return _.assign({}, normalize(
                            _.assign({}, bdLine,
                                {
                                    lineStatus: action.payload.lineStatus,
                                    subComBudgetFC: action.payload.subComBudgetFC,
                                    subComBudgetLC: action.payload.subComBudgetLC,
                                    subComBudgetUSD: action.payload.subComBudgetUSD,
                                    touched: true,
                                }),
                            budgetLineSchema));
                    case 2:
                        return _.assign({}, normalize(
                            _.assign({}, bdLine,
                                {
                                    lineStatus: action.payload.lineStatus,
                                    tecComBudgetFC: action.payload.tecComBudgetFC,
                                    tecComBudgetLC: action.payload.tecComBudgetLC,
                                    tecComBudgetUSD: action.payload.tecComBudgetUSD,
                                    touched: true,
                                }),
                            budgetLineSchema));
                    default:
                        return _.assign({}, normalize(line,
                            budgetLineSchema));

                }
            };
            return Object.assign({}, state, {
                ids: state.ids,
                entities: _.merge({}, state.entities, line1().entities.BudgetLine),
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

export const getSelectedBudgetLine = createSelector(getBudgetLineEntities, getSelectedBudgetLineId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudgetLines;
    }
    return entities[selectedId];
});
