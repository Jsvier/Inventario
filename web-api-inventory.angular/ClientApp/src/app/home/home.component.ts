import { Component } from '@angular/core';
import { WorkoutService } from '../workout.service'
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  ngOnInit(): void {

  }
  public currentJogging: any;

  constructor (private workoutService: WorkoutService) {
    workoutService.get().subscribe((data: any) => this.currentJogging = data);
    console.log(this.currentJogging);
  }
}
