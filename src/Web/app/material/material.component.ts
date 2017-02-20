import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'material',
    styleUrls: ['material.component.css'],
    templateUrl: 'material.component.html'
})
export class MaterialComponent {
    checked = false;
    indeterminate = false;
    align = 'start';
    disabled = false;
}
