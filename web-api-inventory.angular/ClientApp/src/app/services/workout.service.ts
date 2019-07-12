import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class WorkoutService {
  private headers: HttpHeaders;
  private accessPointUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public getInventoryById(id) {
    // Get id inventory data
    return this.http.get(this.accessPointUrl + '/Inventory/' + id , {headers: this.headers});
  }

  public get() {
    // Get all inventory data
    return this.http.get(this.accessPointUrl + '/inventory/', {headers: this.headers});
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/Remove?id=' + payload);
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }
}
