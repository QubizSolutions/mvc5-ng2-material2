import { Component, OnInit, Input } from '@angular/core';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { MdDialogRef } from '@angular/material';
import { FormGroup, FormControl, FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
    moduleId: module.id,
    selector: 'article-edit',
    styleUrls: ['article-edit.component.css'],
    templateUrl: 'article-edit.component.html'
})
export class ArticleEditComponent implements OnInit {
    @Input() authorId: string;
    @Input() authorName: string;
    @Input() articleId: string;

    keys(dict: any): Array<string> {
        return Object.keys(dict);
    }

    articleForm: FormGroup;
    
    article: Article = <Article>{
        Id: undefined,
        Title: '',
        ShortDescription: '',
        Year: undefined,
        Link: '',
        Authors: {}
    };
    submitted: boolean = false;

    authorsControl: FormControl;
    authors: { [id: number]: string; } = {};
    authorNames: string[] = [];
    filteredAuthors: any;

    constructor(
        private formBuilder: FormBuilder,
        private authorService: AuthorService,
        public dialogRef: MdDialogRef<ArticleEditComponent>) {

        this.articleForm = this.setFormGroup();
        this.authorsControl = new FormControl();
        this.filteredAuthors = this.authorsControl.valueChanges
            .startWith(null)
            .map(name => name ? this.filterAuthorNames(name) : this.keys(this.authors));
    }

    ngOnInit() {
        if (this.articleId) {
            let sub = this.authorService.getArticleById(this.articleId).subscribe(article => {
                this.article = article as Article;
                
                this.articleForm = this.setFormGroup();
                sub.unsubscribe();
            });
        }
        else if (this.authorId && this.authorName) {
            this.article.Authors[this.authorId] = this.authorName;
            this.articleForm = this.setFormGroup();
        }

        let getAuthorsSub = this.authorService.getAuthorNames().subscribe(authors => {
            this.authors = authors as { [id: number]: string; };
            getAuthorsSub.unsubscribe();
        });
    }

    save() {
        this.submitted = true;

        if (this.articleForm.valid) {
            if (this.articleForm.dirty) {

                let articleToSave = <Article>this.articleForm.value;
                articleToSave.Authors = {};

                this.articleForm.controls['Authors'].value.forEach((author: { id: string, name: string }) => {
                    articleToSave.Authors[author.id] = author.name;
                });
                
                this.authorService.updateArticle(articleToSave).subscribe(
                    data => {
                        this.dialogRef.close(true);
                    },
                    error => { });
            }
            else
                this.dialogRef.close();
        }
    }

    addArticleAuthor(id: string) {
        let control = <FormArray>this.articleForm.controls['Authors'];
        let index = (<any[]>control.value).findIndex((item) => item.id == id);

        if (index == -1) {
            control.push(this.formBuilder.group({
                id: [id],
                name: [this.authors[id]]
            }));
            control.markAsTouched(true);
            this.articleForm.markAsDirty();
        }
    }

    removeArticleAuthor(index: number) {
        let control = <FormArray>this.articleForm.controls['Authors'];
        control.removeAt(index);
        control.markAsTouched(true);
        this.articleForm.markAsDirty();
    }
    
    private setFormGroup() {
        return this.formBuilder.group({
            'Id': [this.article.Id],
            'Title': [this.article.Title, Validators.required],
            'ShortDescription': [this.article.ShortDescription, Validators.required],
            'Link': [this.article.Link, Validators.required],
            'Year': [this.article.Year, Validators.compose([Validators.required, Validators.pattern(/^\d{4}$/)])],
            'Authors': this.formBuilder.array(
                this.initAuthors(),
                Validators.compose([Validators.required, Validators.minLength(1)]))
        });
    }

    private initAuthors() {
        let authors: any[] = [];
        this.keys(this.article.Authors).forEach((key) => {
            authors.push(this.formBuilder.group({
                id: [key],
                name: [this.article.Authors[key]]
            }));
        });
        return authors;
    }

    private filterAuthorNames(val: string) {
        let filteredKeys = val ? this.keys(this.authors).filter((key) => new RegExp(val, 'gi').test(this.authors[key])) : this.keys(this.authors);
        if (filteredKeys.length == 1 && this.authors[filteredKeys[0]].toLowerCase() == val.toLowerCase()) {
            this.addArticleAuthor(filteredKeys[0]);
        }
        return filteredKeys;

    }
}
