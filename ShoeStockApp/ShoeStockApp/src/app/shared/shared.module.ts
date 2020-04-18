import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LoadedContentComponent } from './components/loaded-content/loaded-content.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ArticleModalComponent } from './components/article-modal/article-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [LoadedContentComponent, ArticleModalComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [LoadedContentComponent]
})
export class SharedModule { }
