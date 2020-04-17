import { Component, OnInit } from '@angular/core';
import { Article } from '../../../shared/models/article';
import { first } from 'rxjs/operators';
import { ArticlesService } from '../../../shared/services/articles-service/articles.service';
import { Store } from 'src/app/shared/models/store';
import { StoresService } from 'src/app/shared/services/stores-service/stores.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'description', 'price', 'total_in_shelf', 'total_in_vault'];
  articles: Article[];
  store: Store;
  isLoading = true;
  hasFailed = false;
  articlesLoading = true;
  storeLoading = true;

  constructor(private articlesService: ArticlesService, private storesService: StoresService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.storesService.getStore(params.id).pipe(first()).subscribe(x => {
        this.store = x;
        this.storeLoading = false;
        this.setLoading();
      }, error => {
        this.hasFailed = true;
        this.storeLoading = false;
        this.setLoading(true);
      });
      this.articlesService.getArticles().pipe(first()).subscribe(x => {
        this.articles = x;
        this.articlesLoading = false;
        this.setLoading();
      }, error => {
        this.hasFailed = true;
        this.articlesLoading = false;
        this.setLoading(true);
      });
    });
  }

  setLoading(setFalse = false) {
    this.isLoading = (this.storeLoading && this.articlesLoading) || setFalse;
  }

}
