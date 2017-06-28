export interface User {
    email: string;
    name: string;
    given_name: string;
    family_name: string;
    sub: string;
    authenticated: boolean;
    role: string[];
    token: string;
    full_name: string;
    groups: Group[];
    branch: string;
    showSubCom: boolean;
    showTecCom: boolean;
    showMalCom: boolean;
    showFinal: boolean;
    operator: boolean,
    napims: boolean,
    operatorId: string;
    dept: string;
    
}

export interface Token {
    id: string;
    access: string;
    authenticated: boolean;
    retUrl: string;
}

export interface Group {
    id: string;
    name: string;
    user: User[];
}

export const initUser: User = {
    email: '',
    name: '',
    given_name: '',
    family_name: '',
    sub: '',
    authenticated: false,
    role: [],
    token: '',
    full_name: '',
    groups: [],
    branch: '',
    showSubCom: false,
    showTecCom: false,
    showMalCom: false,
    showFinal: false,
    operator: false,
    napims: false,
    operatorId: '',
    dept: '',
   
};

export const initToken: Token = {
    id: '',
    access: '',
    authenticated: false,
    retUrl: ''
};

