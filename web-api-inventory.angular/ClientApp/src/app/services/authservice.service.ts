import { Injectable, Inject } from '@angular/core';
import { Signup } from '../models/signup.model';
import { Login } from '../models/login.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  signupUser(user: Signup) {
    return this.http.post( 'http://localhost:5000/api/account', user)
      .subscribe(data => {
        console.log(data);
      });
  }

  loginUser(user: Login) {
    return this.http.post('http://localhost:5000/api/auth/login', user)
      .subscribe(data => {
        console.log(data);
      });
  }
}
