import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppointmentModel } from './AddSlot-model';
import { PassengerAppointmentModel } from '../BookAppointment/BookAppointment-model';


@Injectable()
export class AddSlotService {


  constructor(private _http: HttpClient) {

  }

  addSlots(AppointmentModel: AppointmentModel) {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };
    return this._http.post('http://localhost:51852/api/AddSlot', AppointmentModel, options);
  }

  getSlots() {
    return this._http.get('http://localhost:51852/api/AddSlot');
  }

  bookSlots(passengerAppointmentModel: PassengerAppointmentModel) {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };
    return this._http.post('http://localhost:51852/api/bookSlot', passengerAppointmentModel, options);
  }





}
