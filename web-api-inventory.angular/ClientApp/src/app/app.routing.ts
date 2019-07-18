import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import {EditInventoryComponent} from './components/edit-inventory/edit-inventory.component';
import {UserComponent} from './components/user/user.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';

const routes: Routes = [
  { path: 'edit-inventory', component: EditInventoryComponent },
  { path: 'list-inventory', component: HomeComponent },
  { path: 'user-inventory', component: UserComponent },
  { path: '', component: HomeComponent },
  { path: 'login-inventory', component: LoginComponent },
  { path: 'signup-inventory', component: SignupComponent }
];


export const routing = RouterModule.forRoot(routes);
