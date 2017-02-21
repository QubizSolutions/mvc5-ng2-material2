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
    @Input() dialogRef: MdDialogRef<ArticleEditComponent>;

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

    authors: { [id: number]: string; }[] = [];

    constructor(private authorService: AuthorService) { }

    ngOnInit() {
        if (this.articleId) {
            let sub = this.authorService.getArticleById(this.articleId).subscribe(article => {
                this.article = article as Article;
                sub.unsubscribe;
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
        this.authorService.updateArticle(this.article).subscribe(
            data => {

            },
            error => { });
    }

    addArticleAuthor(id: string) {
        if (!this.article.Authors[id])
            this.article.Authors[id] = this.authors[id];
    }

    removeArticleAuthor(id: string) {
        delete this.article.Authors[id];
    }
}
