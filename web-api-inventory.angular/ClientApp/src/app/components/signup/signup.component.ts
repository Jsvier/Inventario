import { Component, OnInit } from '@angular/core';
import { Signup } from '../../models/Signup.model';
import { AuthService } from '../../services/authservice.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})

export class SignupComponent implements OnInit {
  constructor(private auth: AuthService) { }
  ngOnInit() {
  }

  signupUser(event) {
    event.preventDefault();
    const target = event.target;
    const user: Signup = new Signup();
    user.name = target.querySelector('#name').value;
    user.familyName = target.querySelector('#familyName').value;
    user.email = target.querySelector('#email').value;
    user.password = target.querySelector('#password').value;
    user.nickName = target.querySelector('#nickName').value;
    user.location = target.querySelector('#location').value;
    this.auth.signupUser(user);
  }
}
