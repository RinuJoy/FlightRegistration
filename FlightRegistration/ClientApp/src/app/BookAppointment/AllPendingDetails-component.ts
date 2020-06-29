import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { AddSlotService } from '../addSlots/AddSlot-service'
import { BookAppointmentService } from './BookAppointment-service'
import { UserRegistrationService } from '../UserRegistration/UserRegistration-service'
import { AppointmentModel } from '../addSlots/AddSlot-model'
import { PassengerModel, PassengerAppointmentModel, PassengerAppointmentViewModel} from './BookAppointment-model'
import { UserDetailModel } from '../UserRegistration/userRegistration-model'
import { BtnCellRenderer } from '../gridControls/button-cell-renderer.component';

@Component({
  templateUrl: './AllPendingDetails-component.html',
  styleUrls: ['../css/dashboard.css'],
  providers: [AddSlotService, BookAppointmentService, UserRegistrationService]
})
export class AllPendingDetailsComponent implements OnInit {

  AppointmentModels: AppointmentModel[];
  PassengerModel: PassengerModel;
  UserDetailModel: UserDetailModel;
  PassengerAppointmentModels: PassengerAppointmentModel[];s
  selectedAppointmentModelId: number = 0;
  frameworkComponents;
  columnDefs = [
    { headerName: 'FirstName', field: 'firstName' },
    { headerName: 'LastName', field: 'lastName' },
    { headerName: 'Weight', field: 'weight' },
    { headerName: 'Status', field: 'status' },
    { headerName: 'AppointmentDate', field: 'appointmentDate' },
    { headerName: 'Capacity', field: 'capacity' },
    { headerName: 'IsConfirmed', field: 'isConfirmed' },    {
      headerName: 'Actions', field: 'passengerAppointmentModelId',
      cellRenderer: 'btnCellRenderer',
      cellRendererParams: {
        clicked: function (field: any) {
          return field;
        }
      },
      minWidth: 150,
    },
  ];
  rowData = [];

  constructor(private _Route: Router, private _AddSlotService: AddSlotService,
    private _BookAppointmentService: BookAppointmentService, private _UserRegistrationService: UserRegistrationService) {

  }
  ngOnInit()
  {

    this.frameworkComponents = {
      btnCellRenderer: BtnCellRenderer
    }
    this._BookAppointmentService.getAllPendingPassengerAppointmentModel().subscribe(data => {
      this.rowData = data as PassengerAppointmentViewModel[]
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
  }
  
}
