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
    @Input() dialogRef: MdDialogRef<AuthorEditComponent>;

    author: Author = <Author>{
        Id: undefined,
        FirstName: '',
        LastName: '',
        BirthDate: undefined,
        Country: ''
    };

    constructor(private authorService: AuthorService) { }

    ngOnInit() {
        if (this.authorId) {
            let sub = this.authorService.getAuthorById(this.authorId).subscribe(author => {
                this.author = author as Author;
                this.author.BirthDate = this.formatDate(this.author.BirthDate);
                sub.unsubscribe;
            });
        }
    }

    save() {
        this.authorService.updateAuthor(this.author).subscribe(
            data => {
                this.dialogRef.close();
            },
            error => { });
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
