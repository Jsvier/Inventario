import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-rates',
  templateUrl: './rates.component.html',
  styleUrls: ['./rates.component.css']
})
export class RatesComponent implements OnInit {
  private urlapi = 'https://api.exchangeratesapi.io/latest';
  private myRatesApi = 'https://api-base.herokuapp.com/api/pub/rates';
  public currentEuroRates: any = null;

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.getCurrentEuroRates();
  }

  private getCurrentEuroRates() {
    const currencies = 'USD,GBP,CHF,JPY';
    const url = `${this.urlapi}?symbols=${currencies}`;
    this.httpClient
      .get(url)
      .subscribe(apiData => (this.currentEuroRates = apiData));
  }
  public postRates() {
    const rates = this.transformData();
    rates.forEach(rate =>
      this.httpClient
        .post(this.myRatesApi, rate)
        .subscribe()
    );
  }

  private transformData() {
    const current = this.currentEuroRates.rates;
    return Object.keys(current).map(key => ({
      date: this.currentEuroRates.date,
      currency: key,
      euros: current[key]
    }));
  }

  public deleteMyRates() {
    this.httpClient
      .delete(this.myRatesApi)
      .subscribe();
  }
}
