import { Component } from '@angular/core';
import { LoginModel } from './Login-Model';
import { LoginService } from './Login-Service'
import { Observable } from 'rxjs';
import { Router } from '@angular/router'

@Component({
  templateUrl: './login-component.html',
  styleUrls: ['../css/login.css'],
  providers: [LoginService]
})

export class LoginComponent {
  constructor(private _Route: Router, private _LoginService: LoginService) {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('AdminUser');
  }

  LoginModel: LoginModel = new LoginModel();
  webresponse: any;
  status: boolean;

  onSubmit() {
    var loginmodel = this.LoginModel;
    this._LoginService.validateLoginUser(this.LoginModel).subscribe
      (
        data => {
          this.webresponse = data;

          if (this.webresponse.userTypeID == "0") {
            alert("Invalid Username and Password");
            this._Route.navigate(['Login']);
          }
          else {
            if (this.webresponse.userTypeID == "2") {
              alert("Logged in Successfully");
              localStorage.setItem('currentUser', loginmodel.Username);
              this._Route.navigate(['UserDashboard']);
            }
            else {
              alert("Logged in Successfully");
              localStorage.setItem('AdminUser', loginmodel.Username);
              this._Route.navigate(['AdminDashboard']);
            }
          }
        },
        err => {
          if (err) {
            alert("An Error has occured please try again after some time !");
          }
        });

  }


}
