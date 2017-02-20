import { Component, OnInit } from '@angular/core';
import { AuthorService } from './author.service';
import { Author, Article } from '../common/common.interface';

@Component({
    moduleId: module.id,
    selector: 'author',
    templateUrl: 'author.component.html'
})
export class AuthorComponent implements OnInit {
    authors: Author[] = [];

    constructor(private authorService: AuthorService) { }

    ngOnInit() {
        let obs = this.authorService.getAuthors().subscribe(authors => {
            this.authors = authors as Author[];
            obs.unsubscribe();
        });
    }
}
