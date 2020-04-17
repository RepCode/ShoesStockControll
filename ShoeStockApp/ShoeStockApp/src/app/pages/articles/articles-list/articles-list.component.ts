import { Component, OnInit } from '@angular/core';
import { ArticlesService } from 'src/app/shared/services/articles-service/articles.service';
import { first } from 'rxjs/operators';
import { Article } from '../../../shared/models/article';


@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.scss']
})
export class ArticlesListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'description', 'price', 'total_in_shelf', 'total_in_vault', 'store_name'];
  articles: Article[];
  isLoading = true;
  hasFailed = false;

  constructor(private articlesService: ArticlesService) { }

  ngOnInit(): void {
    this.articlesService.getArticles().pipe(first()).subscribe(x => {
      this.articles = x;
      this.isLoading = false;
    }, error => {
      this.hasFailed = true;
      this.isLoading = false;
    });
  }

}
