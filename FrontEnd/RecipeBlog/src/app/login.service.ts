import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class LoginService {
  private apiKey = 'https://localhost:5187/api/Registration';

  constructor(private http: HttpClient) {}

  login(info: any): Observable<any> {
    return this.http.post<any>(`${this.apiKey}/login`, info);
  }

  register(info: any): Observable<any> {
    return this.http.post<any>(`${this.apiKey}/register`, info);
  }
}