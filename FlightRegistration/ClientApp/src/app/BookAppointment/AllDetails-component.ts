import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { AddSlotService } from '../addSlots/AddSlot-service'
import { BookAppointmentService } from './BookAppointment-service'
import { UserRegistrationService } from '../UserRegistration/UserRegistration-service'
import { AppointmentModel } from '../addSlots/AddSlot-model'
import { PassengerModel, PassengerAppointmentModel, PassengerAppointmentViewModel} from './BookAppointment-model'
import { UserDetailModel } from '../UserRegistration/userRegistration-model'

@Component({
  templateUrl: './AllDetails-component.html',
  styleUrls: ['../css/dashboard.css'],
  providers: [AddSlotService, BookAppointmentService, UserRegistrationService]
})
export class AllDetailsComponent implements OnInit {

  AppointmentModels: AppointmentModel[];
  PassengerModel: PassengerModel;
  UserDetailModel: UserDetailModel;
  PassengerAppointmentModels: PassengerAppointmentModel[];
  selectedAppointmentModelId: number = 0;
  columnDefs = [
    { headerName: 'FirstName', field: 'firstName' },
    { headerName: 'LastName', field: 'lastName' },
    { headerName: 'Weight', field: 'weight' },
    { headerName: 'Status', field: 'status' },
    { headerName: 'AppointmentDate', field: 'appointmentDate' },
    { headerName: 'Capacity', field: 'capacity' },
    { headerName: 'IsConfirmed', field: 'isConfirmed' }
  ];
  rowData = [];

  constructor(private _Route: Router, private _AddSlotService: AddSlotService,
    private _BookAppointmentService: BookAppointmentService, private _UserRegistrationService: UserRegistrationService) {

  }
  ngOnInit()
  {
    this._BookAppointmentService.getAllPassengerAppointmentModel().subscribe(data => {
      this.rowData= data as PassengerAppointmentViewModel[]      
    },
      error => {
        if (error) {
          alert("An Error has occured please try again after some time !");
        }
      });
  }
  filterForeCasts(filterVal: any) {
  }

  onSubmit() {   

  }
}
