

import { Component } from '@angular/core';

import { ICellRendererAngularComp } from 'ag-grid-angular/main';

@Component({
    selector: 'app-currency',
    template: `
            {{params.value | number:'4.0-0'}}
            `
})
export class CurrencyComponent implements ICellRendererAngularComp {
    public params: any;
    

    agInit(params: any): void {
        this.params = params;
        // console.log(this.params);
    }
}
