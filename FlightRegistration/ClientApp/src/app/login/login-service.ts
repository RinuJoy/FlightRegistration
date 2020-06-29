import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable  } from 'rxjs';
import { map, filter, scan, retry, catchError } from 'rxjs/operators';
import { LoginModel } from './Login-Model';

@Injectable()
export class LoginService {
  public token: string;
  constructor(private _http: HttpClient, private _Route: Router) {

  }

  validateLoginUser(loginmodel: LoginModel) {
    let headers = new HttpHeaders({'Content-Type': 'application/json'});
    let options = { headers: headers }
    return this._http.post('http://localhost:51852/api/ValidateLoginUser', loginmodel, options);
  }

  LogoutUser() {
    localStorage.removeItem('currentUser');
  }

  //private handleError(err: any) {
  //  let errorMessage: string;
  //  if (err instanceof Response) {
  //    let body = err.json() || '';
  //    let error = body.error || JSON.stringify(body);
  //    errorMessage = `${err.status} - ${err.statusText} || ''} ${error}`;
  //  }
  //  else {
  //    errorMessage = err.message ? err.message : err.toString();
  //  }

  //  return Observable.throw(errorMessage);
  //}

}
