import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Action, ActionReducer } from '@ngrx/store';
import { HomeDashboardItems, initHomeDashBoardItems } from '../models';
import { DashboardActions } from '../actions';

export const DashboardReducer: ActionReducer<HomeDashboardItems[]> = (state: HomeDashboardItems[] = initHomeDashBoardItems,
    action: Action) => {
    switch (action.type) {
        case DashboardActions.INIT_DASHBOARD:
            return initHomeDashBoardItems;
        case DashboardActions.LOAD_DASHBOARD:
            return state;
        case DashboardActions.LOAD_DASHBOARD_SUCCESS:
            return state;
        // tslint:disable-next-line:no-switch-case-fall-through
        default:
            return state;
    };
};