import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoresListComponent } from './stores-list/stores-list.component';
import { MatTableModule } from '@angular/material/table';
import { StoresRoutingModule } from './stores.module-routing';
import { StoreComponent } from './store/store.component'


@NgModule({
  declarations: [StoresListComponent, StoreComponent],
  imports: [
    CommonModule,
    MatTableModule,
    StoresRoutingModule
  ]
})
export class StoresModule { }
