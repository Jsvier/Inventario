import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import {routing} from './app.routing';

// Componentes
import {EditInventoryComponent} from './components/edit-inventory/edit-inventory.component';
import {UserComponent} from './components/user/user.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { SignupComponent } from './components/signup/signup.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/dashboard/profile/profile.component';
import { AuthService } from './services/authservice.service';
import { AdminModule } from './components/dashboard/admin.module';

// Servicios
import { WorkoutService } from './services/workout.service';

// redux
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';

// Action Redux
import { CounterState } from './store/counter.state';
import { UsersState } from './store/users.state';

// Modulos
import {RatesModule} from './http/rates/rates.module';
import { NotificationsModule } from './notifications/notifications.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EditInventoryComponent,
    UserComponent,
    SignupComponent,
    LoginComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserModule,
    routing,
    ReactiveFormsModule,
    HttpClientModule,
    routing,
    NgxsModule.forRoot([CounterState, UsersState], { developmentMode: true }),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsLoggerPluginModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    RatesModule,
    NotificationsModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    AdminModule
  ],

  providers: [
    WorkoutService,
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
