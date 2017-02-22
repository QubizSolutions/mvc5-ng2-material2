import { Component, OnInit, Input } from '@angular/core';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { MdDialogRef } from '@angular/material';

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

    article: Article = <Article>{
        Id: undefined,
        Title: '',
        ShortDescription: '',
        Year: undefined,
        Link: '',
        Authors: {}
    };
    originalArticle: Article = Object.assign({}, this.article);
    authors: { [id: number]: string; }[] = [];
    errorMessage: string = '';

    constructor(
        private authorService: AuthorService,
        public dialogRef: MdDialogRef<ArticleEditComponent>) { }

    ngOnInit() {
        if (this.articleId) {
            let sub = this.authorService.getArticleById(this.articleId).subscribe(article => {
                this.article = article as Article;
                this.originalArticle = Object.assign({}, article);
                sub.unsubscribe();
            });
        }
        else if (this.authorId && this.authorName) {
            this.article.Authors[this.authorId] = this.authorName;
        }

        let getAuthorsSub = this.authorService.getAuthorNames().subscribe(authors => {
            this.authors = authors as { [id: number]: string; }[];
            getAuthorsSub.unsubscribe();
        });
    }

    save() {
        if (this.isValid()) {
            if (this.hasDataChanged())
                this.authorService.updateArticle(this.article).subscribe(
                    data => {
                        this.dialogRef.close(true);
                    },
                    error => { });
            else
                this.dialogRef.close();
        }
    }

    addArticleAuthor(id: string) {
        if (!this.article.Authors[id])
            this.article.Authors[id] = this.authors[id];
    }

    removeArticleAuthor(id: string) {
        delete this.article.Authors[id];
    }

    private isValid() {
        this.errorMessage = '';

        if (!this.article.Title ||
            !this.article.ShortDescription ||
            !this.article.Link ||
            (isNaN(this.article.Year) || this.article.Year < 1000) ||
            this.keys(this.article.Authors).length == 0) {

            this.errorMessage = 'Please complete all of the fields';
            return false;
        }
        return true;
    }

    private hasDataChanged() {
        if (this.article.Title != this.originalArticle.Title ||
            this.article.ShortDescription != this.originalArticle.ShortDescription ||
            this.article.Year != this.originalArticle.Year ||
            this.article.Link != this.originalArticle.Link)
            return true;

        let originalAuthorIds = this.keys(this.originalArticle.Authors);
        let authorIds = this.keys(this.article.Authors);

        if (authorIds.length != originalAuthorIds.length)
            return true;

        let newAuthors = authorIds.filter(x => !originalAuthorIds.find(y => y == x));

        return newAuthors.length > 0;
    }
}
