import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticlesService } from '../../shared/services/articles-service/articles.service';
import { StoresService } from '../../shared/services/stores-service/stores.service';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  providers: [ArticlesService, StoresService],
  declarations: [ArticlesListComponent],
  imports: [
    CommonModule,
    ArticlesRoutingModule,
    MatTableModule,
    SharedModule
  ]
})
export class ArticlesModule { }
