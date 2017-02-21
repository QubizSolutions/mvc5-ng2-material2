import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorService } from './author.service';
import { Author, Article } from '../common/common.interface';

@Component({
    moduleId: module.id,
    selector: 'author',
    templateUrl: 'author.component.html'
})
export class AuthorComponent implements OnInit {
    authors: Author[] = [];

    constructor(private authorService: AuthorService, private router: Router) { }

    ngOnInit() {
        let obs = this.authorService.getAuthors().subscribe(authors => {
            this.authors = authors as Author[];
            obs.unsubscribe();
        });
    }

    openAuthorDetail(id: number) {
        this.router.navigate(['/author', id]);
    }
}
