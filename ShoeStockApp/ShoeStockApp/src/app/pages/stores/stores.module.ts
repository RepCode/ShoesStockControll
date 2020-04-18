import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoresListComponent } from './stores-list/stores-list.component';
import { MatTableModule } from '@angular/material/table';
import { StoresRoutingModule } from './stores.module-routing';
import { StoreComponent } from './store/store.component';
import { SharedModule } from '../../shared/shared.module';
import { ArticlesService } from '../../shared/services/articles-service/articles.service';
import { StoresService } from '../../shared/services/stores-service/stores.service';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  providers: [ArticlesService, StoresService],
  declarations: [StoresListComponent, StoreComponent],
  imports: [
    CommonModule,
    MatTableModule,
    SharedModule,
    StoresRoutingModule,
    MatButtonModule,
    MatSnackBarModule
  ]
})
export class StoresModule { }
