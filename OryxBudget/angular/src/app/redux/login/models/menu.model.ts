import { Group } from './user.model';

export interface Menu {
    name: string;
    link: string;
    linkActive: string;
    icon: string;
    groups: Group[];
    roles: string[];
}

export const initMenu: Menu[] = [{
    name: '',
    link: '',
    linkActive: '',
    icon: '',
    groups: [],
    roles: []
}]; 
