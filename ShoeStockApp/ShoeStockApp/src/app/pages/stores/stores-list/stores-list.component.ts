import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { StoresService } from 'src/app/shared/services/stores-service/stores.service';
import { Store } from 'src/app/shared/models/store';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stores-list',
  templateUrl: './stores-list.component.html',
  styleUrls: ['./stores-list.component.scss']
})

export class StoresListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'address', 'name'];
  stores: Store[];
  isLoading = true;
  hasFailed = false;

  constructor(private storesService: StoresService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.storesService.getStores().pipe(first()).subscribe(x => {
      this.stores = x;
      this.isLoading = false;
    }, error => {
      this.hasFailed = true;
      this.isLoading = false;
    });
  }

  goToStoreDetail(row) {
    this.router.navigate([row.id], { relativeTo: this.activatedRoute });
  }
}
