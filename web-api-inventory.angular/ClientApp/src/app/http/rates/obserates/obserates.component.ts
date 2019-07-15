import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap, share } from 'rxjs/operators';

@Component({
  selector: 'app-obserates',
  templateUrl: './obserates.component.html',
  styleUrls: ['./obserates.component.css']
})
export class ObseratesComponent implements OnInit {
  private ratesApi = 'https://api.exchangeratesapi.io/latest';
  public currentEuroRates$: Observable<any> = null;
  public myRates$: Observable<any[]> = null;

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.getCurrentEuroRates();
  }
  /*
  Al utilizar el pipe async ya no es necesaria la suscripción en código.
  La propia función del framework se ocupa de ello. Por tanto la llamada se realiza igualmente aunque no veamos la suscripción.
  HttpClient no devuelve los datos tal cual sino un stream de estados de dichos datos.
  La manipulación será sobre el stream no directamente sobre los datos; y, claro, para manipular un torrente hay que encauzarlo en tuberías.
  pipe(operator1, operator2...) aplicado a un observable.
  Suele hacerse en lugar, o antes, del .susbcribe(okCallback, errCallback).
  Este método canaliza una serie de operadores predefinidos que manipulan el chorro de estados observados.
  El operador más utilizado es map(sourceStream => targetStream).
  Este operador recibe una función callBack que será invocada ante cada dato recibido.
  Esa función tienen que retornar un valor para sustituir al actual y así transformar el contenido del chorro.
  share() permite compartir el resultado de una primera llamada con subsiguientes suscriptores.
  Evitando de ese modo la repetición de costosas peticiones http.
  tap(callback) es similar en nombre al map().
  Pero la gran diferencia es que está pensado para no manipular los datos que recibe.
  Los usa y puede causar otros efectos colaterales, pero nunca modifica el propio stream.
  Es muy utilizado para inspeccionar o auditar el flujo de otros operadores
  */

 private getCurrentEuroRates() {
  const url = `${this.ratesApi}?symbols=USD,GBP,CHF,JPY`;
    this.currentEuroRates$ = this.httpClient.get(url)
        .pipe(share());
    this.myRates$ = this.currentEuroRates$
        .pipe(
          tap(d => console.log(d)),
          map(this.transformData),
          tap(t => console.log(t))
        );
  }
  private transformData(currentRates) {
    const current = currentRates.rates;
    return Object.keys(current).map(key => ({
      date: currentRates.date,
      currency: key,
      euros: current[key]
    }));
  }
}
