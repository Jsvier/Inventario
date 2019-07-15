import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

/*
    Mantienen el estado privado para evitar manipulaciones
    Recibe de forma controlada las acciones de cambio
    Emite clones del estado
    Expone observables para que se suscriban los interesados.
*/
export class NotificationsStoreService {
  private notifications = [];

  private notifications$ = new BehaviorSubject<any[]>([]);

  constructor() {}

  public select$ = () => this.notifications$.asObservable();

  public dispatch(notification) {
    this.notifications.push(notification);
    this.notifications$.next([...this.notifications]);
  }
}
