import { Component, OnInit, ViewChild, ViewContainerRef, AfterViewInit } from '@angular/core';
import { ICellEditorAngularComp,  } from 'ag-grid-angular/main';
@Component({
    moduleId: module.id,
    selector: 'app-text',
    template: `<textarea #input [(ngModel)]="value" id="textarea1" class="materialize-textarea"></textarea>`
})

export class TextComponent implements ICellEditorAngularComp, AfterViewInit {
    public params: any;
    public value: string;
    @ViewChild('input', {read: ViewContainerRef}) public input;
    agInit(params: any): void {
        this.params = params;
        this.value = this.params.value;
        // // console.log(this.params);
    }
    isPopup(): boolean {
        return true;
    }
    ngAfterViewInit() {
        this.input.element.nativeElement.focus();
    }
    getValue(): any {
        return this.value;
    }
}