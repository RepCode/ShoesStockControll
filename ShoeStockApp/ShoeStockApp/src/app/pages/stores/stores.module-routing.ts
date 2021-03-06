import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StoresListComponent } from './stores-list/stores-list.component';
import { StoreComponent } from './store/store.component';
import { AuthGuardService } from '../../core/auth/auth-guard.service';


const routes: Routes = [
  {
    path: '',
    component: StoresListComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: ':id',
    component: StoreComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoresRoutingModule { }
