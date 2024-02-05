// src/app/login/login.component.ts

import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  providers:[LoginService],
  imports: [RouterOutlet],
  styleUrls: ['./login.component.css'],
})

export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private http: HttpClient, private LoginService: LoginService) {}

  login() {
    const credentials = {
      username: this.username,
      password: this.password,
    };

      this.LoginService.login(credentials).subscribe(
        response => {
          console.log('Login successful', response);
        },
        error => {
          this.errorMessage = 'Invalid username or password';
          console.error('Login failed', error);
        }
      );
  }
}
