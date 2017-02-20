import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { HttpUtilityService } from '../common/helpers/http-utility.service'

@Injectable()
export class AuthorService {
    private url = 'http://localhost/Tesseract.Api/api/Author';  // URL to web API
    constructor(private http: Http, private httpUtilityService: HttpUtilityService) { }

    getAuthors(): Observable<any[]> {

        return this.http.get(`${this.url}`)
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.handleError);
    }

    getAuthorById(id: number): Observable<any> {
        let params = new URLSearchParams();
        params.set('id', id.toString());
        return this.http.get(`${this.url}/GetAuthorById`, { search: params })
            .map(this.httpUtilityService.extractData)
            .catch(this.httpUtilityService.extractData);
    }
}
