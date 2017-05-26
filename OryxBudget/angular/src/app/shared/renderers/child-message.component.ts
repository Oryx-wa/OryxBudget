import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-child-cell',
    template: `<span><a class="waves-effect waves-light"
     (click)="invokeParentMethod()"><i class="material-icons right" >{{icon}}</i></a></span>`
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

    public invokeParentMethod() {
        this.params.context.componentParent.methodFromParent(this.params.data.code, this.type );
    }
}