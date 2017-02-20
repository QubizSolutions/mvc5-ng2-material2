import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Components
import { DashboardComponent } from './dashboard.component';

@NgModule({
    imports: [BrowserModule],
    declarations: [DashboardComponent],
    exports: [DashboardComponent],
})
export class DashboardModule { }
