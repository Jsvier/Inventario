import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {Inventory} from '../../models/inventory.model';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { WorkoutService } from '../../services/workout.service';

@Component({
  selector: 'app-edit-inventory',
  templateUrl: './edit-inventory.component.html'
})

export class EditInventoryComponent implements OnInit {

  inventory: Inventory;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private workoutService: WorkoutService) { }

  ngOnInit() {
    const userId = localStorage.getItem('editInventoryId');
    if (!userId) {
      alert('Invalid action.');
      this.router.navigate(['list-inventory']);
      return;
    }
    this.editForm = this.formBuilder.group({
      id: [],
      datE_PLANNED: ['', Validators.required],
      storE_NO: ['', Validators.required],
      descripcion: ['', Validators.required],
      tipo: [],
      status: []
    });

    this.workoutService.getInventoryById(+userId)
     .subscribe( data => {
       console.warn(data);
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    // this.userService.updateUser(this.editForm.value)
     // .pipe(first())
     // .subscribe(
      //  data => {
          this.router.navigate(['list-inventory']);
       // },
       // error => {
       //   alert(error);
       // });
  }

}
