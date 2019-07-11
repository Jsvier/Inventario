import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {EditInventoryComponent} from './edit-inventory/edit-inventory.component';

const routes: Routes = [
  { path: 'edit-inventory', component: EditInventoryComponent },
  { path: 'list-inventory', component: HomeComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' }
];

export const routing = RouterModule.forRoot(routes);
