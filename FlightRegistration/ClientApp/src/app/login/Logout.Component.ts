import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
@Component({
    template: ''
})
export class LogoutComponent implements OnInit
{
    constructor(private _Route: Router)
    {

    }
    ngOnInit() {
      localStorage.removeItem('AdminUser');
      localStorage.removeItem('currentUser');
      this._Route.navigate(['Login']);
    }
}

