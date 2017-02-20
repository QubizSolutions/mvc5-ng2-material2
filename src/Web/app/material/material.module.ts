import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { MaterialModule as NgMaterialModule } from '@angular/material';

//Components
import { MaterialComponent } from './material.component';

@NgModule({
    imports: [BrowserModule, FormsModule, NgMaterialModule],
    declarations: [MaterialComponent],
    exports: [MaterialComponent],
})
export class MaterialModule { }
