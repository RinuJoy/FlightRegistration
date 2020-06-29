import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { AddSlotService } from '../addSlots/AddSlot-service'
import { BookAppointmentService } from './BookAppointment-service'
import { UserRegistrationService } from '../UserRegistration/UserRegistration-service'
import { AppointmentModel } from '../addSlots/AddSlot-model'
import { PassengerModel, PassengerAppointmentModel} from './BookAppointment-model'
import { UserDetailModel } from '../UserRegistration/userRegistration-model'

@Component({
  templateUrl: './BookAppointment-component.html',
  styleUrls: ['../css/dashboard.css'],
  providers: [AddSlotService, BookAppointmentService, UserRegistrationService]
})
export class BookAppointmentComponent implements OnInit {

  AppointmentModels: AppointmentModel[] = [{ AppointmentModelId: 0, AppointmentDate: new Date(), Capacity:100}];
  PassengerModel: PassengerModel;
  UserDetailModel: UserDetailModel;
  PassengerAppointmentModel: PassengerAppointmentModel = new PassengerAppointmentModel() ;
  selectedAppointmentModelId: number = 0;

  constructor(private _Route: Router, private _AddSlotService: AddSlotService,
    private _BookAppointmentService: BookAppointmentService, private _UserRegistrationService: UserRegistrationService) {

  }
  ngOnInit()
  {
    var userName = localStorage.getItem('currentUser');
    this._UserRegistrationService.getUserDetails(userName)
      .subscribe(data =>
      {
        this.UserDetailModel = data as UserDetailModel
      },
        error => {
          if (error) {
            alert("An Error has occured please try again after some time !");
          }
        });

    this._AddSlotService.getSlots().subscribe(data => {
      this.AppointmentModels = data as AppointmentModel[]
    },
      error => {
        if (error) {
          alert("An Error has occured please try again after some time !");
        }
      });
  }
 
  filterForeCasts(filterVal: any) {
    this.selectedAppointmentModelId = filterVal;
  }

  onSubmit() {
    this._BookAppointmentService.getPassengerModel(this.UserDetailModel.userId)
      .subscribe(data => {
        this.PassengerModel = data as PassengerModel
        var formdata = this.PassengerAppointmentModel;
        formdata.appointmentModelId = Number(this.selectedAppointmentModelId);
        formdata.passengerModelId = this.PassengerModel.passengerModelId;
        formdata.isConfirmed = false;

        this._BookAppointmentService.addPassengerAppointmentModel(formdata).subscribe
          (
            data => {

              if (data == true) {
                alert("Slots Booked Successfully ");
                this._Route.navigate(['UserDashboard']);
              }
              else {
                alert("Problem While Booking Slot, Slots full !!");
              }
            },
            err => {
              if (err) {
                alert("An Error has occured please try again after some time !");
              }
            });

      },
        error => {
          if (error) {
            alert("An Error has occured please try again after some time !");
          }
        });
  

   

  }
}
