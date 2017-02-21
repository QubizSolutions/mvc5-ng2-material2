import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { MdDialog, MdDialogConfig } from '@angular/material';
import { AuthorEditComponent } from '../author-edit/author-edit.component';
import { ArticleEditComponent } from '../article-edit/article-edit.component';

@Component({
    moduleId: module.id,
    selector: 'author-detail',
    styleUrls: ['author-detail.component.css'],
    templateUrl: 'author-detail.component.html',
    providers: [MdDialog]
})
export class AuthorDetailComponent implements OnInit {
    author: Author;

    keys(dict: any): Array<string> {
        return Object.keys(dict);
    }
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authorService: AuthorService,
        private dialog: MdDialog
    ) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            let id = params['id'];

            let sub = this.authorService.getAuthorById(id).subscribe(author => {
                this.author = author as Author;
                sub.unsubscribe;
            });
        });
    }

    openAuthorDetail(id: string) {
        this.router.navigate(['/author', id]);
    }

    openArticleDetail(id: string) {
        this.router.navigate(['/article', id]);
    }

    addArticle() {
        let config: MdDialogConfig = {
            width: '500px',
            height: '430px',
        };

        let dialogRef = this.dialog.open(ArticleEditComponent, config);
        dialogRef.componentInstance.dialogRef = dialogRef;
        dialogRef.componentInstance.authorId = this.author.Id;
        dialogRef.componentInstance.authorName = `${this.author.FirstName} ${this.author.LastName}`;
    }

    editAuthor(id: string) {
        let config: MdDialogConfig = {
            width: '500px',
        };

        let dialogRef = this.dialog.open(AuthorEditComponent, config);
        dialogRef.componentInstance.dialogRef = dialogRef;
        dialogRef.componentInstance.authorId = id;
    }
}
