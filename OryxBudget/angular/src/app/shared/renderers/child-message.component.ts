import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-child-cell',
    template: `<span><a class="waves-effect waves-light"
     (click)="invokeParentMethod()"><i class="material-icons right" >message</i></a></span>`
})
export class ChildMessageComponent implements ICellRendererAngularComp {
    public params: any;

    agInit(params: any): void {
        this.params = params;
        console.log(this.params);
    }

    public invokeParentMethod() {
        this.params.context.componentParent.methodFromParent(this.params.data.code);
    }
}