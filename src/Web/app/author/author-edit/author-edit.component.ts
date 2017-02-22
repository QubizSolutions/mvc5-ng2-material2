import { Component, OnInit, Input } from '@angular/core';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { MdDialogRef } from '@angular/material';

@Component({
    moduleId: module.id,
    selector: 'author-edit',
    styleUrls: ['author-edit.component.css'],
    templateUrl: 'author-edit.component.html'
})
export class AuthorEditComponent implements OnInit {
    @Input() authorId: string;

    author: Author = <Author>{
        Id: undefined,
        FirstName: '',
        LastName: '',
        BirthDate: undefined,
        Country: ''
    };
    originalAuthor: Author = Object.assign({}, this.author);
    errorMessage: string = '';

    constructor(
        private authorService: AuthorService,
        public dialogRef: MdDialogRef<AuthorEditComponent>) { }

    ngOnInit() {
        if (this.authorId) {
            let sub = this.authorService.getAuthorById(this.authorId).subscribe(author => {
                this.author = author as Author;
                this.author.BirthDate = this.formatDate(this.author.BirthDate);
                this.originalAuthor = Object.assign({}, this.author);
                sub.unsubscribe();
            });
        }
    }

    save() {
        if (this.isValid()) {
            if (this.hasDataChanged())
                this.authorService.updateAuthor(this.author).subscribe(
                    data => {
                        this.dialogRef.close(true);
                    },
                    error => { });
            else
                this.dialogRef.close();

        }
    }

    private isValid() {
        this.errorMessage = '';

        if (!this.author.FirstName ||
            !this.author.LastName ||
            !this.author.BirthDate ||
            !this.author.Country) {

            this.errorMessage = 'Please complete all of the fields';
            return false;
        }
        return true;
    }

    private hasDataChanged() {
        if (this.author.FirstName != this.originalAuthor.FirstName ||
            this.author.LastName != this.originalAuthor.LastName ||
            this.author.BirthDate != this.originalAuthor.BirthDate ||
            this.author.Country != this.originalAuthor.Country)
            return true;
        return false;
    }

    private formatDate(date: any) {
        let d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [year, month, day].join('-');
    }
}
