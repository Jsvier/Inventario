import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './login/login.component';
import { NotificationsRoutingModule } from './notifications-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProfileComponent, LoginComponent, DashboardComponent],
  imports: [CommonModule, NotificationsRoutingModule, HttpClientModule, FormsModule]
})
export class AdminModule { }

