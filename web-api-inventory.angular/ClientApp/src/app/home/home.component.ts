import { Component } from '@angular/core';
import { WorkoutService } from '../workout.service';
import { OnInit } from '@angular/core';
import {Inventory} from '../model/Inventory.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  ngOnInit(): void {

  }

  public inventories: any;

  constructor (private router: Router, private workoutService: WorkoutService) {
    this.workoutService.get().subscribe((data: any) => this.inventories = data);
  }

  deleteInventory(inventory: Inventory): void {
    this.workoutService.remove(inventory.id)
      .subscribe( data => {
        this.inventories = this.inventories.filter(x => x.id !== data);
      });
  }

  editInventory(inventory: Inventory): void {
    localStorage.removeItem('editInventoryId');
    localStorage.setItem('editInventoryId', inventory.id.toString());
    this.router.navigate(['edit-inventory']);
  }
}
