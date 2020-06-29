import { Component } from '@angular/core'
import { UserDetailModel } from './UserRegistration-Model'
import { PassengerModel } from '../BookAppointment/BookAppointment-model'
import { UserRegistrationService } from './UserRegistration-service'
import { BookAppointmentService} from '../BookAppointment/BookAppointment-service'
import { Router } from '@angular/router'

@Component({
  templateUrl: './UserRegistration-component.html',
  providers: [UserRegistrationService, BookAppointmentService]
})

export class UserRegistrationComponent {


  constructor(private _Route: Router, private _UserRegistrationService: UserRegistrationService,
    private _BookAppointmentService: BookAppointmentService) {


  }

  UserDetailModel: UserDetailModel = new UserDetailModel();
  PassengerModel: PassengerModel = new PassengerModel();
  responseStatus: Object = [];
  status: boolean;

  onSubmit() {

    var formdata = this.UserDetailModel;
    formdata.username = this.UserDetailModel.username;
    formdata.password = this.UserDetailModel.password;
    formdata.address = this.UserDetailModel.address;
    formdata.birthdate = this.UserDetailModel.birthdate;
    formdata.contact_No = this.UserDetailModel.contact_No;
    formdata.email = this.UserDetailModel.email;
    formdata.firstName = this.UserDetailModel.firstName;
    formdata.lastName = this.UserDetailModel.lastName;
    formdata.weight = this.UserDetailModel.weight;

   


    this._UserRegistrationService.createUser(formdata).subscribe
      (
        data => {

          if (data > 0) {

            var passengerData = this.PassengerModel;
            passengerData.firstName = this.UserDetailModel.firstName;
            passengerData.lastName = this.UserDetailModel.lastName;
            passengerData.weight = this.UserDetailModel.weight;
            passengerData.passengerModelId = 0;
            passengerData.status = 1;
            passengerData.userId = data as number;
            this._BookAppointmentService.addPassenger(passengerData).subscribe(item => {
              alert("Your Registration has done Successfully ");
              this._Route.navigate(['Login']);
            });
          }
          else {
            alert("Problem While Registering User");
          }
        },
        err => {
          if (err) {
            alert("An Error has occured please try again after some time !");
          }
        });


  }


  CheckUsernameExist() {
    var registration = this.UserDetailModel;
    if (registration.username != null) {
      this._UserRegistrationService.validateUsername(registration.username).subscribe
        (
          data => {
            this.status = <boolean>data;

            if (this.status == false) {
              this.UserDetailModel.username = "";
              alert("Username Already Exits");
            }
            else {

            }
          },
          err => {
            if (err) {
              alert("An Error has occured please try again after some time !");
            }
          });
    }
  }



}
