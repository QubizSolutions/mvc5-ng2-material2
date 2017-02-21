import { Component, OnInit  } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { AuthorService } from '../author.service';
import { Author, Article } from '../../common/common.interface';

@Component({
    moduleId: module.id,
    selector: 'author-detail',
    styleUrls: ['author-detail.component.css'],
    templateUrl: 'author-detail.component.html'
})
export class AuthorDetailComponent implements OnInit {
    author: Author;
    keys(dict: any): Array<string> {
        return Object.keys(dict);
    }
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authorService: AuthorService
    ) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            let id = +params['id'];

            let sub = this.authorService.getAuthorById(id).subscribe(author => {
                this.author = author as Author;
                sub.unsubscribe;
            });
        });
    }

    openAuthorDetail(id: number) {
        this.router.navigate(['/author', id]);
    }
}
