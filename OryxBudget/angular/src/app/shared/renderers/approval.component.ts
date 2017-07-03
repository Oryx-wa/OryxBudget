import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-approval',
    template: `<div class="row">
                              <div class="">
                                <select materialize="material_select" id="status" 
                                name="status" (change)="operatorSelected($event.target.value)>										
                                <option  value="" disabled selected ></option>	
                    <option  [value]="accepted" >Accepted</option>          
                    <option  [value]="rejected" >Rejected</option>                                
                      </select>
                               
                              </div>
                            </div>`
})

export class NameComponent implements ICellRendererAngularComp {
    constructor() { }

    agInit(params: any): void {
       
    }

     public invokeParentMethod(type: string) {
        this.params.context.componentParent.methodFromParent(this.params.data.code, type );
    }

}