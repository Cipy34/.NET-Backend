// src/app/login/login.component.ts

import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  providers:[LoginService],
  imports: [RouterOutlet],
  styleUrls: ['./register.component.css'],
})

export class RegisterComponent {
  username: string = '';
  password: string = '';
  firstname: string = '';
  lastname: string = '';
  errorMessage: string = '';

  constructor(private http: HttpClient, private LoginService: LoginService) {}

  register() {
    const credentials = {
      username: this.username,
      password: this.password,
      firstname: this.firstname,
      lastname: this.lastname
    };

      this.LoginService.register(credentials).subscribe(
        response => {
          console.log('Register successful', response);
        },
        error => {
          console.error('Register failed', error);
        }
      );
  }
}
