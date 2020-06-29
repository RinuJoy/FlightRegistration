import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { AddSlotService } from './AddSlot-service'
import { AppointmentModel } from './AddSlot-model'

@Component({
  templateUrl: './AddSlot-component.html',
  styleUrls: ['../css/dashboard.css'],
  providers: [AddSlotService]
})
export class AddSlotComponent {

  constructor(private _Route: Router,private _AddSlotService: AddSlotService) {

  }

  AppointmentModel: AppointmentModel = new AppointmentModel();

  onSubmit() {

    var formdata = this.AppointmentModel;
    formdata.AppointmentDate = this.AppointmentModel.AppointmentDate;
    formdata.Capacity = this.AppointmentModel.Capacity;
    formdata.AppointmentModelId = 0;

    this._AddSlotService.addSlots(formdata).subscribe
      (
        data => {

          if (data == true) {
            alert("Slots Created Successfully ");
            this._Route.navigate(['AdminDashboard']);
          }
          else {
            alert("Problem While Creating Slot");
          }
        },
        err => {
          if (err) {
            alert("An Error has occured please try again after some time !");
          }
        });


  }
}
