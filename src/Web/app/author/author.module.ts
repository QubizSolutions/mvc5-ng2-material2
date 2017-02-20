import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Components
import { AuthorComponent } from './author.component';

@NgModule({
    imports: [BrowserModule],
    declarations: [AuthorComponent],
    exports: [AuthorComponent],
})
export class AuthorModule { }
