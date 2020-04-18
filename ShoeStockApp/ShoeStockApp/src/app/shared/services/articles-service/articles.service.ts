import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Article } from '../../models/article';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/auth/auth.service';

export interface ArticlesResponse {
  sucess: boolean;
  total_elements: number;
  articles: Article[];
}

export interface ArticleForm {
  name: string;
  description: string;
  price: number;
  total_in_shelf: number;
  total_in_vault: number;
  store_id: number;
}

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  url: string;
  constructor(private http: HttpClient, private authService: AuthService) {
    this.url = environment.apiBaseUrl + 'services/articles';
  }

  getArticles(): Observable<Article[]> {
    return this.http.get<ArticlesResponse>(this.url, this.authService.getAuthHeader()).pipe(map(x => x.articles));
  }

  getStoreArticles(storeId: number): Observable<Article[]> {
    return this.http.get<ArticlesResponse>(this.url + '/stores/' + storeId, this.authService.getAuthHeader()).pipe(map(x => x.articles));
  }

  createStoreArticle(article: ArticleForm) {
    return this.http.post<Article>(this.url, article, this.authService.getAuthHeader());
  }
}
