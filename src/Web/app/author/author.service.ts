import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { HttpUtilityService } from '../common/helpers/http-utility.service';
import { Article, Author } from './author.interface';

@Injectable()
export class AuthorService {
    private url = 'api/Author';  // URL to web API
    constructor(private http: Http, private httpUtilityService: HttpUtilityService) { }

    getAuthors(): Observable<Author[]> {

        return this.http.get(`${this.httpUtilityService.serverUrl}${this.url}/GetAuthors`)
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.handleError);
    }

    getAuthorNames(): Observable<{ [id: number]: string; }[]> {

        return this.http.get(`${this.httpUtilityService.serverUrl}${this.url}/GetAuthorNames`)
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.handleError);
    }

    getAuthorById(id: string): Observable<Author> {
        let params = new URLSearchParams();
        params.set('id', id);
        return this.http.get(`${this.httpUtilityService.serverUrl}${this.url}/GetAuthorById`, { search: params })
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.extractData);
    }

    updateAuthor(author: Author): Observable<any> {
        return this.http.post(`${this.httpUtilityService.serverUrl }${this.url }/UpdateAuthor`, author)
            .catch(this.httpUtilityService.extractData);
    }
    
    getArticleById(id: string): Observable<Article> {
        let params = new URLSearchParams();
        params.set('id', id);
        return this.http.get(`${this.httpUtilityService.serverUrl}${this.url}/GetArticleById`, { search: params })
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.extractData);
    }

    updateArticle(article: Article): Observable<any> {
        return this.http.post(`${this.httpUtilityService.serverUrl}${this.url}/UpdateArticle`, article)
            .catch(this.httpUtilityService.extractData);
    }

    deleteArticleById(id: string): Observable<any> {
        let params = new URLSearchParams();
        params.set('id', id);
        return this.http.delete(`${this.httpUtilityService.serverUrl}${this.url}/DeleteArticleById`, { search: params })
            .catch(this.httpUtilityService.extractData);
    }
}
