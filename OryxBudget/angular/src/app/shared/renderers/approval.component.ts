import { Component, ViewChild, ElementRef, Renderer } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular/main';

@Component({
    selector: 'app-approval',
    template: `<form action="#">
                            <div class="col s12">  
                              
      
       <input #checkbox type="checkbox"  (change)="invokeParentMethod($event.target.checked)" [id]="chkId" [name]="chkId"/>
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

    @ViewChild('checkbox') checkbox: ElementRef;
    constructor(private renderer: Renderer) {

    }

    agInit(params: any): void {

        this.renderer.setElementProperty(this.checkbox.nativeElement, 'indeterminate', true);
        this.val = 'No yet';
        this.params = params;
        this.chkId = this.params.data.code;
        this.type = this.params.colDef.type;
    }

    public invokeParentMethod(type: boolean) {
        this.val = (type) ? 'Yes' : 'No';
        this.params.context.componentParent.methodFromParent(this.params.data.code, type, this.params.data.level);
        
    }

}