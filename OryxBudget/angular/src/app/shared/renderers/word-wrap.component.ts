import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular/main';
@Component({

    selector: 'app-word-wrap',
   
    template: `<div class="col s12">
       {{params.value}} 
    </div>
    `
})

export class WordWrapComponent implements ICellRendererAngularComp {
    public params: any;
    constructor() { }

    agInit(params: any): void {
        this.params = params;
        // // console.log(this.params);
    }
}