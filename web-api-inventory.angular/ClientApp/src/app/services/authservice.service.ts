import { Injectable, Inject } from '@angular/core';
import { Signup } from '../models/signup.model';
import { Login } from '../models/login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserProfile } from '../models/userProfile.model';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

  constructor(
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  userProfile: UserProfile;

  signupUser(user: Signup) {
    return this.http.post('http://localhost:5000/api/account', user)
      .subscribe(
        data => this.router.navigate(['/login'])
      );
  }

  login(user: Login) {
    return this.http.post<Login>('http://localhost:5000/api/auth/login', user)
      .subscribe(
        data => {
          this.setSession(data);
          this.router.navigate(['/profile']);
        }
      );
  }

  logout() {
    localStorage.removeItem('id_token');
    localStorage.removeItem('auth_token');
    localStorage.removeItem('expires_in');
  }

  getUserProfile() {
    const authToken = localStorage.getItem('auth_token');

    if (this.userProfile == null) {
      this.http.get<UserProfile>('http://localhost:5000/api/profile', { headers: new HttpHeaders({ 'Authorization': 'Bearer ' + authToken }) })
        .subscribe(data => {
          this.userProfile = data;
        });
    }
    return this.userProfile;
  }

  private setSession(authResult) {
    console.warn(authResult);
    const expiresAt = authResult.expiresIn * 1000 + Date.now();
    localStorage.setItem('id_token', authResult.id);
    localStorage.setItem('auth_token', authResult.auth_token);
    localStorage.setItem('expires_in', JSON.stringify(authResult.expires_in.valueOf()));
  }
}
