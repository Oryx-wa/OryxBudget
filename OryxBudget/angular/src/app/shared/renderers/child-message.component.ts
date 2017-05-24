import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-child-cell',
    template: `<span><button  class="wave-effect wave-light btn btn-small"
    style="height: 30px" (click)="invokeParentMethod()">Comments</button></span>`
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