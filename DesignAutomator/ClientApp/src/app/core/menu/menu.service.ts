import { Injectable } from '@angular/core';
import { UserService } from "../../shared/services/user.service";
import { AuthenticatedModel } from "../../models/authentication/authenticated.model";

@Injectable()
export class MenuService {

  menuItems: Array<any>;
  user: AuthenticatedModel;

  constructor(private userService: UserService) {
    this.menuItems = [];
  }

  addMenu(items: Array<{
    text: string,
    heading?: boolean,
    link?: string,
    elink?: string,
    target?: string,
    icon?: string,
    alert?: string,
    image?: string,
    requiredRoles?: Array<number>
    submenu?: Array<{
      text: string,
      heading?: boolean,
      link?: string,
      elink?: string,
      target?: string,
      icon?: string,
      alert?: string,
      image?: string
    }>
  }>, user) {

    if (user) {
      this.user = user;
      this.BindMenu(items);
    }
    else if (!this.user) {
      this.userService.get.subscribe((result) => {
        if (result) {
          this.user = result;
          this.BindMenu(items);
        }
      });
    }
  }

  getMenu() {
    return this.menuItems;
  }

  BindMenu(items: any) {
    this.menuItems.length = 0;

    items.forEach((item) => {
      if ((!item.requiredRoles || item.requiredRoles.length <= 0) ||
        (this.user.roles && this.user.roles.length > 0 && this.user.roles.some(p => item.requiredRoles.indexOf(p) >= 0)))
        this.menuItems.push(item);
    });
  }

}
