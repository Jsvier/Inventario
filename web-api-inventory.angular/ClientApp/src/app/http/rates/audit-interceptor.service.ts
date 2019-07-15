import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, tap } from 'rxjs/operators';

/*
    req: HttpRequest<any> puntero a la petición en curso
    next: HttpHandler puntero a la siguiente función que maneje la petición
    : Observable<HttpEvent<any>> retornamos un stream de eventos http para cada petición
    return next.handle(req); que el siguiente procese la petición, sin hacerle nada en absoluto

    Cuando usas httpClient.get() es como si pides algo a Amazon y te suscribes,
    es decir esperas el paquete. Pasado el tiempo el paquete llegará o no llegará,
    pero ya no lo gestionas tú. Con los interceptores es como si espiases cada proceso de tu pedido:
    stock, picking, packaging, shipping… Cada pedido es tratado en una sucesión de eventos.
    Con un interceptor observas !todos los eventos de todos los pedidos!

    */
@Injectable({
  providedIn: 'root'
})

export class AuditInterceptorService implements HttpInterceptor {
  constructor() {}

  public intercept(req: HttpRequest<any>, next: HttpHandler) {
    const started = Date.now();
    return next.handle(req).pipe(
      filter((event: HttpEvent<any>) => event instanceof HttpResponse),
      tap((resp: HttpResponse<any>) => this.auditEvent(resp, started))
    );
  }

  private auditEvent(resp: HttpResponse<any>, started: number) {
    const elapsedMs = Date.now() - started;
    const eventMessage = resp.statusText + ' on ' + resp.url;
    const message = eventMessage + ' in ' + elapsedMs + 'ms';
    console.log(message);
  }
}
