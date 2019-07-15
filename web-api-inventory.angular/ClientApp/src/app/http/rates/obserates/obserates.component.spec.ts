import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObseratesComponent } from './obserates.component';

describe('ObseratesComponent', () => {
  let component: ObseratesComponent;
  let fixture: ComponentFixture<ObseratesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObseratesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObseratesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
