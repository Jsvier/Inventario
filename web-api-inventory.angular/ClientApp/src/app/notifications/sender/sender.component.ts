import { Component, OnInit } from '@angular/core';
import { NotificationsStoreService } from '../notifications-store.service';

@Component({
  selector: 'app-sender',
  templateUrl: './sender.component.html'
})

export class SenderComponent implements OnInit {
  public note = '';

  constructor(private notificationsStore: NotificationsStoreService) {}

  ngOnInit() {}

  public send() {
    this.notificationsStore.dispatch(this.note);
  }
}
