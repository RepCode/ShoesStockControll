import { Component, OnInit } from '@angular/core';
import { Article } from '../../../shared/models/article';
import { first } from 'rxjs/operators';
import { ArticlesService } from '../../../shared/services/articles-service/articles.service';
import { Store } from 'src/app/shared/models/store';
import { StoresService } from 'src/app/shared/services/stores-service/stores.service';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ArticleModalComponent, } from 'src/app/shared/components/article-modal/article-modal.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/auth/auth.service';

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
  canCreate = false;

  constructor(
    private articlesService: ArticlesService,
    private storesService: StoresService,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private snackBar: MatSnackBar,
    private authService: AuthService) {
      this.canCreate = this.authService.isAdmin();
     }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.storesService.getStore(params.id).pipe(first()).subscribe(x => {
        this.store = x;
        this.storeLoading = false;
        this.setLoading();
      }, error => {
        this.hasFailed = true;
        this.storeLoading = false;
        this.setLoading();
      });
      this.articlesService.getStoreArticles(params.id).pipe(first()).subscribe(x => {
        this.articles = x;
        this.articlesLoading = false;
        this.setLoading();
      }, error => {
        this.hasFailed = true;
        this.articlesLoading = false;
        this.setLoading();
      });
    });
  }

  setLoading() {
    this.isLoading = (this.storeLoading && this.articlesLoading);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ArticleModalComponent, {
      width: '100%',
      maxWidth: '700px',
      height: '100%',
      maxHeight: '820px',
      panelClass: 'modal-styles'
    });

    dialogRef.afterClosed().subscribe(result => {
      result.store_id = this.store.id;
      this.articlesService.createStoreArticle(result).pipe(first()).subscribe((x) => {
        this.articles.push(x);
        this.articles = Object.assign([], this.articles);
        this.snackBar.open('Artículo creado con éxito', '', {
          duration: 2000,
        });
      }, () => {
        this.snackBar.open('Ocurrió un error al crear el árticulo', '', {
          duration: 2000,
        });
      });
    });
  }

}
