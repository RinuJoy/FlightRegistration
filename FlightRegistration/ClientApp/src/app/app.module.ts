import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UserDashboardComponent } from './userDashboard/userDashboard-component';
import { AdminDashboardComponent } from './adminDashboard/adminDashboard-component';
import { BookAppointmentComponent } from './bookAppointment/BookAppointment-component'
import { LoginComponent } from '../app/Login/Login-Component';
import { AddSlotComponent } from './addSlots/AddSlot-component';
import { UserRegistrationComponent } from './userRegistration/userRegistration-component';
import { AllDetailsComponent } from './bookAppointment/AllDetails-component';
import { AllPendingDetailsComponent } from './bookAppointment/AllPendingDetails-component';
import { AllMyDetailsComponent } from './bookAppointment/AllMyDetails-component';
import { LogoutComponent } from './login/Logout.Component';
import { AuthGuard } from '../app/_guards/auth.guard'
import { AuthGuardAdmin } from '../app/_guards/auth.adminguard'
import { AgGridModule } from 'ag-grid-angular';
import { BtnCellRenderer } from './gridControls/button-cell-renderer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    UserDashboardComponent,
    AdminDashboardComponent,
    UserRegistrationComponent,
    AddSlotComponent,
    BtnCellRenderer,
    LogoutComponent,
    BookAppointmentComponent, AllDetailsComponent, AllPendingDetailsComponent, AllMyDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AgGridModule.withComponents([BtnCellRenderer]),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/Login', pathMatch: 'full' },
      { path: 'UserDashboard', component: UserDashboardComponent, canActivate: [AuthGuard]},
      { path: 'AdminDashboard', component: AdminDashboardComponent, canActivate: [AuthGuardAdmin] },     
      { path: 'logout', component: LogoutComponent },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      { path: 'Login', component: LoginComponent },
      { path: 'UserRegistration', component: UserRegistrationComponent },
      { path: 'AddSlot', component: AddSlotComponent, canActivate: [AuthGuardAdmin] }, 
      { path: 'Booking', component: BookAppointmentComponent, canActivate: [AuthGuard]},
      { path: 'AllBooking', component: AllDetailsComponent, canActivate: [AuthGuardAdmin] },
      { path: 'PendingBooking', component: AllPendingDetailsComponent, canActivate: [AuthGuardAdmin]}, 
      { path: 'AllMyBooking', component: AllMyDetailsComponent, canActivate: [AuthGuard] }, 
    ])
  ],
  providers: [AuthGuard, AuthGuardAdmin],
  bootstrap: [AppComponent]
})
export class AppModule { }
