import { Component, OnInit } from '@angular/core';
import { AuthService, LoginForm } from '../../core/auth/auth.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  displayError = false;
  constructor(private authService: AuthService, private formBuilder: FormBuilder, public router: Router) {
    this.loginForm = this.formBuilder.group({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
  }

  onSubmit(form: LoginForm) {
    this.authService.login(form).pipe(first()).subscribe(success => {
      if (success) {
        this.router.navigate(['/']);
        this.displayError = false;
      } else {
        this.displayError = true;
      }
    });
  }

}
