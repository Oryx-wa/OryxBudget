import { Component, ViewChild, ElementRef, Renderer, AfterViewInit } from '@angular/core';
import { ICellRendererAngularComp, AgEditorComponent } from 'ag-grid-angular/main';

@Component({
    selector: 'app-approval',
    template: `<form action="#">
                            <div *ngIf="level === '3'" class="col s12"> 
       <input #checkbox  type="checkbox"  [checked]="checkBoxValue" [disabled]="disabled" 
        (change)="invokeParentMethod($event.target.checked)" [id]="chkId" [name]="chkId"/>
       <label [for]="chkId">{{val}}</label>       
                              </div> 
                              
                              
      
                           </form>   
                            `
})

export class ApprovalComponent implements ICellRendererAngularComp, AfterViewInit, AgEditorComponent {
    public params: any;
    public type: string;
    public checkBoxValue = false;
    public val = '';
    public chkId = '';
    public status: 1;
    public level: '3';
    public chkVal = true;
    public disabled = true;

    @ViewChild('checkbox') checkbox: ElementRef;
    constructor(private renderer: Renderer) {

    }
    // dont use afterGuiAttached for post gui events - hook into ngAfterViewInit instead for this
    ngAfterViewInit() {


    }
    getValue(): any {

    }
    agInit(params: any): void {
        this.status = params.data.lineStatus;
        this.params = params;
        this.level = this.params.data.level;
        const operator = <boolean>this.params.data.operator;
        const subCom = <boolean>this.params.data.subCom;
        const tecCom = <boolean>this.params.data.tecCom;
        const malCom = <boolean>this.params.data.malCom;
        const prgStatus = +this.params.data.workProgramStatus;

        switch (prgStatus) {
            case 1:
                if (subCom) {
                    this.disabled = false;
                } else {
                    this.disabled = true;
                }

                break;
            case 2:
                if (tecCom) {
                    this.disabled = false;
                } else {
                    this.disabled = true;
                }
                break;
            case 3:
                if (malCom) {
                    this.disabled = false;
                } else {
                    this.disabled = true;
                }
                break;
            default:
                this.disabled = true;
        }

        if (operator) {
            this.disabled = true;
        }


        if (this.level === '3') {            
            switch (params.data.lineStatus) {
                case 1:
                    this.val = 'N/A';
                    this.chkVal = true;
                    this.checkBoxValue = false;

                    break;
                case 2:
                    this.val = 'No';
                    this.chkVal = false;
                    this.checkBoxValue = false;

                    break;
                case 3:
                    this.val = 'Yes';
                    this.chkVal = false;
                    this.checkBoxValue = true;

                    break;
            }

            this.chkId = this.params.data.code;
            this.type = this.params.colDef.type;
        }


    }

    public invokeParentMethod(type: boolean) {
        // this.checkBoxValue = type;
        // console.log(type);
        this.val = (type) ? 'Yes' : 'No';
        this.params.context.componentParent.handleApproval(this.params.data.code, type, this.params.data.level);

    }

}