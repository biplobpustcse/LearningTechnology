import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiBase = 'http://localhost:5063/api'; // Base URL

  constructor(private http: HttpClient, private router: Router) {}

  login(data: any) {
    return this.http.post(`${this.apiBase}/Auth/login`, data);
  }

  register(data: any) {
    return this.http.post(`${this.apiBase}/Auth/register`, data);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}
