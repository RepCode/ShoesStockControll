import { Component, OnInit, Inject, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ArticleForm } from '../../services/articles-service/articles.service';

@Component({
  selector: 'app-article-modal',
  templateUrl: './article-modal.component.html',
  styleUrls: ['./article-modal.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ArticleModalComponent {
  form: ArticleForm | any = {};
  articleForm: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<ArticleModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ArticleForm,
    private formBuilder: FormBuilder) {
    this.form = data || this.form;
    this.articleForm = this.formBuilder.group({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      total_in_shelf: new FormControl('', Validators.required),
      total_in_vault: new FormControl('', Validators.required),
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.articleForm.valid) {
      this.dialogRef.close(this.articleForm.value);
    }
  }
}
