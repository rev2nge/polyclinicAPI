import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { UserForLogin, UserForRegister } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public baseApiUrl: string = environment.apiUrL
  constructor(private http: HttpClient) { }

  authUser(user: UserForLogin) {
    return this.http.post(this.baseApiUrl + '/account/login', user);
  }

  registerUser(user: UserForRegister) {
    return this.http.post(this.baseApiUrl + '/account/register', user);
  }
}
