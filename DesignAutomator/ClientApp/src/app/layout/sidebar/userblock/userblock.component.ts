import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from "../../../routes/pages/login/authentication.service";
import { UserService } from "../../../shared/services/user.service";

@Component({
  selector: 'app-userblock',
  templateUrl: './userblock.component.html',
  styleUrls: ['./userblock.component.scss']
})
export class UserblockComponent implements OnInit {
  user: any;
  constructor(public userService: UserService, private authenticationService: AuthenticationService) {
    userService.get.subscribe((result) => this.user = result);
  }

  ngOnInit() {
  }

  userBlockIsVisible() {
    return this.userService.getVisibility();
  }

  logout() { this.authenticationService.logout(); }

}
