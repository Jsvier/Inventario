import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RatesComponent } from './rates/rates.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ObseratesComponent } from './obserates/obserates.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuditInterceptorService } from './audit-interceptor.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'app-obserates', component: ObseratesComponent }
    ]),
    RouterModule,
    HttpClientModule
  ],
  providers: [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuditInterceptorService,
    multi: true
  }
],
  declarations: [RatesComponent, ObseratesComponent]
})
export class RatesModule { }

