import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PassengerModel, PassengerAppointmentModel } from './BookAppointment-model';


@Injectable()
export class BookAppointmentService {


  constructor(private _http: HttpClient) {
  }

    addPassenger(PassengerModel: PassengerModel) {
      let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      let options = { headers: headers };
      return this._http.post('http://localhost:51852/api/PassengerModel', PassengerModel, options);
    }

    addAppointment(PassengerModel: PassengerModel) {
      let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      let options = { headers: headers };
      return this._http.put('http://localhost:51852/api/PassengerModel', PassengerModel, options);
    }

  getPassengerModel(userId: number) {
    return this._http.get('http://localhost:51852/api/PassengerModel' + '/GetById/' + userId);
    }

    getAllPassengerAppointmentModel() {
      return this._http.get('http://localhost:51852/api/PassengerAppointmentModel');
    }

    getAllPendingPassengerAppointmentModel() {
      return this._http.get('http://localhost:51852/api/PassengerAppointmentModel' +'/GetPending');
    }

    getByIdPassengerAppointmentModel(id: number) {
      return this._http.get('http://localhost:51852/api/PassengerAppointmentModel' +'/GetById/' + id);
    }

    addPassengerAppointmentModel(passengerAppointmentModel: PassengerAppointmentModel) {
      let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      let options = { headers: headers };
      return this._http.post('http://localhost:51852/api/PassengerAppointmentModel', passengerAppointmentModel, options);
    }

    updatePassengerAppointmentModel(id: number) {
      let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      let options = { headers: headers };
      return this._http.put('http://localhost:51852/api/PassengerAppointmentModel', id, options);
    }
}
