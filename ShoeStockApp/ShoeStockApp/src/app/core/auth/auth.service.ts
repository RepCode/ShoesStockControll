import { Injectable } from '@angular/core';
import { User } from './models/user';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map, first } from 'rxjs/operators';

export interface UserResponse {
  success: boolean;
  user: User;
}

export interface LoginForm {
  username: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: User;
  url: string;
  constructor(private http: HttpClient) {
    this.url = environment.apiBaseUrl + 'services/login';
  }

  public login(form: LoginForm): Observable<boolean> {
    return new Observable((subscriber) => {
      this.http.post<UserResponse>(this.url, form).pipe(map(x => x.user)).pipe(first()).subscribe(x => {
        this.user = x;
        subscriber.next(true);
      }, () => subscriber.next(false));
    });
  }

  public isAuthenticated(): boolean {
    return !!this.user?.token;
  }

  public getAuthHeader() {
    return {
      headers: { Authorization: 'Bearer ' + this.user.token }
    };
  }
}

