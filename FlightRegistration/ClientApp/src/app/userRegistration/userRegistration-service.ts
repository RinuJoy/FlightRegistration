import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDetailModel } from './UserRegistration-model';


@Injectable()
export class UserRegistrationService {


  constructor(private _http: HttpClient) {

  }

  getUserDetails(userName: string) {
    return this._http.get('http://localhost:51852/api/UserRegistration' +'/userName/'+ userName);
  }

  createUser(Userregistrationmodel: UserDetailModel) {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };
    return this._http.post('http://localhost:51852/api/UserRegistration', Userregistrationmodel, options);
  }

  validateUsername(Username: string) {
    let UsernameModel = { "Username": Username };
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };
    return this._http.post('http://localhost:51852/api/ValidateUsername', UsernameModel, options);
  }



}
