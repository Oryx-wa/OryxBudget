import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-child-cell',
    template: `
     <div class="col s4">
    <span><a class="waves-effect waves-light"
     (click)="invokeParentMethod('details')"><i class="material-icons" >details</i></a></span>
     </div>
      <div class="col s4">
    <span><a class="waves-effect waves-light"
     (click)="invokeParentMethod('comments')"><i class="material-icons " >message</i></a></span>
     </div>
     <div class="col s4">
    <span><a class="waves-effect waves-light"
     (click)="invokeParentMethod('attachments')"><i class="material-icons" >file_upload</i></a></span>
     </div>
`
})
export class ChildMessageComponent implements ICellRendererAngularComp {
    public params: any;
    public icon: string;
    public type: string;

    agInit(params: any): void {
        this.params = params;
        this.icon = this.params.colDef.mIcon;
        this.type = this.params.colDef.type;
        // console.log(this.params);
    }

    public invokeParentMethod(type: string) {
        this.params.context.componentParent.methodFromParent(this.params.data.code, type );
    }
}