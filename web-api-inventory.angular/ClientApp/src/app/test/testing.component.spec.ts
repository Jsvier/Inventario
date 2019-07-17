import { async, inject, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { WorkoutServiceFake } from './workoutServicefake.component.spec';

describe('ListUsersProxyServiceIT', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientTestingModule],
      providers: [WorkoutServiceFake]
    });
  });

  it('should be created', inject([WorkoutServiceFake], (service: WorkoutServiceFake) => {
    expect(service).toBeTruthy();
  }));

  it('should get inventory', async(() => {
    const service: WorkoutServiceFake = TestBed.get(WorkoutServiceFake);
    service.get().subscribe(
      (response) => expect(response.toString()).not.toBeNull(),
      (error) => fail(error)
    );
  }));
});
