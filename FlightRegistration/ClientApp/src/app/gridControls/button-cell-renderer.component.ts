import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { BookAppointmentService } from '../BookAppointment/BookAppointment-service'

@Component({
  selector: 'btn-cell-renderer',
  templateUrl: './button-cell-renderer.component.html',
  providers: [BookAppointmentService]
})
export class BtnCellRenderer implements ICellRendererAngularComp {

  constructor( private _BookAppointmentService: BookAppointmentService) {
  }
  private params: any;

  agInit(params: any): void {
    this.params = params;
  }

  refresh(): boolean {
    return true;
  }

  btnClickedHandler() {

    this._BookAppointmentService.updatePassengerAppointmentModel(Number(this.params.value)).subscribe
      (
        data => {

          if (data == true) {
            alert("Approved Successfully ");
            //this._Route.navigate(['UserDashboard']);
          }
          else {
            alert("Problem While Approving Request");
          }
        },
        err => {
          if (err) {
            alert("An Error has occured please try again after some time !");
          }
        });
  }  
}
