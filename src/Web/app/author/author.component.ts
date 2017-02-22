import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MdDialog, MdDialogConfig } from '@angular/material';
import { AuthorService } from './author.service';
import { Author, Article } from './author.interface';
import { AuthorEditComponent } from './author-edit/author-edit.component'

@Component({
    moduleId: module.id,
    selector: 'author',
    templateUrl: 'author.component.html',
    providers: [MdDialog]
})
export class AuthorComponent implements OnInit {
    authors: Author[] = [];

    constructor(private authorService: AuthorService, private router: Router, private dialog: MdDialog) { }

    ngOnInit() {
        this.getAuthors();
    }

    private getAuthors() {
        let obs = this.authorService.getAuthors().subscribe(authors => {
            this.authors = authors as Author[];
            obs.unsubscribe();
        });
    }

    openAuthorDetail(id: number) {
        this.router.navigate(['/author', id]);
    }

    addAuthor() {
        let config: MdDialogConfig = {
            width: '500px',
        };

        let dialogRef = this.dialog.open(AuthorEditComponent, config);
        dialogRef.afterClosed().subscribe(result => {
            if (result)
                this.getAuthors()
        });
    }
}
