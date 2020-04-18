import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '../../models/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/auth/auth.service';

export interface StoresResponse {
  sucess: boolean;
  total_elements: number;
  stores: Store[];
}

export interface StoreResponse {
  sucess: boolean;
  total_elements: number;
  store: Store;
}

@Injectable({
  providedIn: 'root'
})
export class StoresService {

  url: string;

  constructor(private http: HttpClient, private authService: AuthService) {
    this.url = environment.apiBaseUrl + 'services/stores';
   }

  getStores(): Observable<Store[]> {
    return this.http.get<StoresResponse>(this.url, this.authService.getAuthHeader()).pipe(map(x => x.stores));
  }

  getStore(id: number): Observable<Store> {
    return this.http.get<StoreResponse>(this.url + '/' + id, this.authService.getAuthHeader()).pipe(map(x => x.store));
  }
}
