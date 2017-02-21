import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';

import { CommonModule } from '../common/common.module';

//Components
import { AuthorComponent } from './author.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { AuthorEditComponent } from './author-edit/author-edit.component'
import { ArticleEditComponent } from './article-edit/article-edit.component'

//Services
import { AuthorService } from './author.service';

@NgModule({
    imports: [BrowserModule, FormsModule, MaterialModule, CommonModule],
    declarations: [AuthorComponent, AuthorDetailComponent, ArticleDetailComponent, AuthorEditComponent, ArticleEditComponent],
    exports: [AuthorComponent, AuthorDetailComponent, ArticleDetailComponent, AuthorEditComponent, ArticleEditComponent],
    entryComponents: [AuthorEditComponent, ArticleEditComponent],
    providers: [AuthorService]
})
export class AuthorModule { }
