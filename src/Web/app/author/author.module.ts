import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';

import { CommonModule } from '../common/common.module';

//Components
import { AuthorComponent } from './author.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';

//Services
import { AuthorService } from './author.service';

@NgModule({
    imports: [BrowserModule, FormsModule, MaterialModule, CommonModule],
    declarations: [AuthorComponent, AuthorDetailComponent],
    exports: [AuthorComponent, AuthorDetailComponent],
    providers: [AuthorService]
})
export class AuthorModule { }
