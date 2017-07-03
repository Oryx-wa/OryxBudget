import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular/main';

@Component({
    selector: 'app-child-cell',
    template: `  
     <div class="col s12">
    <span><a class="waves-effect waves-light"
     (click)="invokeParentMethod('actual')"><i class="material-icons">receipt</i></a></span>
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