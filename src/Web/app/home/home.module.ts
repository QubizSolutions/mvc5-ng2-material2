import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';

//Components
import { HomeComponent } from './home.component';

@NgModule({
    imports: [BrowserModule, FormsModule, MaterialModule],
    declarations: [HomeComponent],
    exports: [HomeComponent],
})
export class HomeModule { }
