import { AppointmentModel} from '../addSlots/AddSlot-model'

export class PassengerModel {
  public passengerModelId: number;
  public firstName: string;
  public lastName: string;
  public weight: number;
  public status: number;
  public userId: number;
}

export class PassengerAppointmentModel {
  public passengerAppointmentModelId: number;
  public passengerModelId: number;  
  public appointmentModelId: number;
  public isConfirmed: boolean;
  public passengerModels: PassengerModel[];
  public appointmentModels: AppointmentModel[];
}

export class PassengerAppointmentViewModel {
  public firstName: string;
  public lastName: string;
  public weight: number;
  public status: number;
  public appointmentDate: Date;
  public capacity: number;
  public isConfirmed: boolean;
  public PassengerAppointmentModel: number;
}
