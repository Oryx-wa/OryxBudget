import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Action, ActionReducer } from '@ngrx/store';
import { Menu, initMenu } from '../models';
import { MenuActions } from '../actions';


export const MenuReducer: ActionReducer<Menu[]> = (state: Menu[] = initMenu, action: MenuActions.Actions) => {
    switch (action.type) {
        case MenuActions.INIT_MENU:
            return initMenu;
        case MenuActions.LOAD_MENU:
            return state;
        case MenuActions.LOAD_MENU_SUCCESS:
            return action.payload;
        // tslint:disable-next-line:no-switch-case-fall-through
        default:
            return state;
    };
};
