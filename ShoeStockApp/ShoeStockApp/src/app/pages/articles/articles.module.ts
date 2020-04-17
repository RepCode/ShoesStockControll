import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesListComponent } from './articles-list/articles-list.component';


@NgModule({
  declarations: [ArticlesListComponent],
  imports: [
    CommonModule,
    ArticlesRoutingModule,
    MatTableModule
  ]
})
export class ArticlesModule { }
