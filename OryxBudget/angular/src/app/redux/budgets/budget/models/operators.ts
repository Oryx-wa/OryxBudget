export interface Operators {
    id: string;
    code: string;
    name: string;
    imageSrc: string;
    budget: number;
    actual: number;
}

export const initOperators: Operators = {
    id: '',
    code: '',
    name: '',
    imageSrc: '',
    budget: 0,
    actual: 0,
};
