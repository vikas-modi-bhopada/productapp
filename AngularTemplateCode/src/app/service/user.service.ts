import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUser } from '../models/login-user';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private httpclient: HttpClient) { }
  registerUser(user: User): Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:44326/api/User/RegisterUser', user)
  }
  login(loginUser: LoginUser): Observable<string> {
    
    
    return this.httpclient.post<string>('https://localhost:44326/api/User/LogIn',loginUser);
  }


}
