import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { ArticleEditComponent } from '../article-edit/article-edit.component';
import { MdDialog, MdDialogConfig } from '@angular/material';
import { QuestionDialogComponent } from '../../common/components/question-dialog/question-dialog.component';

@Component({
    moduleId: module.id,
    selector: 'article-detail',
    styleUrls: ['article-detail.component.css'],
    templateUrl: 'article-detail.component.html',
    providers: [MdDialog]
})
export class ArticleDetailComponent implements OnInit {
    article: Article;
    keys(dict: any): Array<string> {
        return Object.keys(dict);
    }
    constructor(
        private dialog: MdDialog,
        private route: ActivatedRoute,
        private router: Router,
        private authorService: AuthorService
    ) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            let id = params['id'];

            this.getArticleById(id);
        });
    }

    getArticleById(id: string) {
        let sub = this.authorService.getArticleById(id).subscribe(
            article => {
                this.article = article as Article;
                sub.unsubscribe();
            });
    }

    openAuthorDetail(id: number) {
        this.router.navigate(['/author', id]);
    }

    editArticle(id: string) {
        let config: MdDialogConfig = {
            width: '500px',
        };

        let dialogRef = this.dialog.open(ArticleEditComponent, config);
        dialogRef.componentInstance.dialogRef = dialogRef;
        dialogRef.componentInstance.articleId = id;
        dialogRef.afterClosed().subscribe(result => {
            if(result)
                this.getArticleById(this.article.Id);
        });
    }

    deleteArticle(id: string) {
        let dialogRef = this.dialog.open(QuestionDialogComponent);
        dialogRef.componentInstance.question = 'Do you want to delete this article?';
        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                let sub = this.authorService.deleteArticleById(id).subscribe(
                    data => {
                        sub.unsubscribe();
                        this.router.navigate(['/authors']);
                    });
            }
        });
    }
}
