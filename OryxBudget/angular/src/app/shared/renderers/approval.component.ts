import { Component, ViewChild, ElementRef, Renderer } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular/main';

@Component({
    selector: 'app-approval',
    template: `<form action="#">
                            <div *ngIf="level === '3'" class="col s12">  
                              
      
       <input #checkbox [indeterminate]="chkVal" type="checkbox" [checked]="checkBoxValue" 
        (change)="invokeParentMethod($event.target.checked)" [id]="chkId" [name]="chkId"/>
       <label [for]="chkId">{{val}}</label>
       
                              </div> 
                              
                              
      
                           </form>   
                            `
})

export class ApprovalComponent implements ICellRendererAngularComp {
    public params: any;
    public type: string;
    public checkBoxValue = false;
    public val = 'True';
    public chkId = '';
    public status: 1;
    public level: '3';
    public chkVal = true;

    @ViewChild('checkbox') checkbox: ElementRef;
    constructor(private renderer: Renderer) {

    }

    agInit(params: any): void {
        this.status = params.data.lineStatus;
        if (this.level = '3') {
            switch (params.data.lineStatus) {
                case 1:
                    this.val = 'N/A';
                    this.chkVal = true;
                    break;
                case 2:
                    this.val = 'No';
                    this.chkVal = false;
                    this.checkBoxValue = true;
                    break;
                case 3:
                    this.val = 'Yes';
                    this.chkVal = false;
                    this.checkBoxValue = true;
                    break;
            }
        }
        this.params = params;
        this.chkId = this.params.data.code;
        this.type = this.params.colDef.type;
        this.level = this.params.data.level;
    }

    public invokeParentMethod(type: boolean) {
        this.checkBoxValue = type;
        this.val = (type) ? 'Yes' : 'No';
        this.params.context.componentParent.handleApproval(this.params.data.code, type, this.params.data.level);

    }

}