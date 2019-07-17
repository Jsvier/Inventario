import { LIST_INVENTORIES_FAKE } from './ist-inventories.fake.spec';
import { Observable } from 'rxjs';
import { of } from 'rxjs';

export class WorkoutServiceFake {

  get(): Observable<string> {
    return of(JSON.stringify(LIST_INVENTORIES_FAKE));
  }
}
