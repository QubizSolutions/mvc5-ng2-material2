import { Component, OnInit, Input } from '@angular/core';
import { AuthorService } from '../author.service';
import { Author, Article } from '../author.interface';
import { MdDialogRef } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    moduleId: module.id,
    selector: 'author-edit',
    styleUrls: ['author-edit.component.css'],
    templateUrl: 'author-edit.component.html'
})
export class AuthorEditComponent implements OnInit {
    @Input() authorId: string;

    authorForm: FormGroup;
    author: Author = <Author>{
        Id: undefined,
        FirstName: '',
        LastName: '',
        BirthDate: undefined,
        Country: ''
    };
    submitted: boolean = false;

    constructor(
        private formBuilder: FormBuilder,
        private authorService: AuthorService,
        public dialogRef: MdDialogRef<AuthorEditComponent>        
        ) { 
        this.authorForm = this.setFormGroup(this.author);
    }

    ngOnInit() {
        if (this.authorId) {
            let sub = this.authorService.getAuthorById(this.authorId).subscribe(author => {
                this.author = author as Author;
                this.author.BirthDate = this.formatDate(this.author.BirthDate);
                this.authorForm = this.setFormGroup(this.author);
                sub.unsubscribe();
            });
        } else {
            this.authorForm = this.setFormGroup(this.author);
        }
    }
    
    save() {
        this.submitted = true;
        
        if (this.authorForm.valid) {
            if (this.authorForm.dirty)
                this.authorService.updateAuthor(<Author>this.authorForm.value).subscribe(
                    data => {
                        this.dialogRef.close(true);
                    },
                    error => { });
            else
                this.dialogRef.close();
        }
    }

    private setFormGroup(author: Author) {
        return this.formBuilder.group({
            'Id': [this.author.Id],
            'FirstName': [this.author.FirstName, Validators.required],
            'LastName': [this.author.LastName, Validators.required],
            'BirthDate': [this.author.BirthDate, Validators.compose([Validators.required, Validators.pattern(/^(\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})$/)])],
            'Country': [this.author.Country, Validators.required],
        });
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
