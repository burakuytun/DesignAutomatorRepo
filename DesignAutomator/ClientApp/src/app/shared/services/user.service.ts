import { Injectable } from "@angular/core";
import { AuthenticatedModel } from "../../models/authentication/authenticated.model";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from "@angular/router";
import { FilteredUserDna } from "../../models/dna/filtereduserdna";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class UserService {
  private authenticatedUser: AuthenticatedModel;
  public userBlockVisible: boolean;

  constructor(private router: Router) {
    // initially visible
    this.userBlockVisible = true;
  }

  getVisibility() {
    return this.userBlockVisible;
  }

  setVisibility(stat = true) {
    this.userBlockVisible = stat;
  }

  toggleVisibility() {
    this.userBlockVisible = !this.userBlockVisible;
  }

  setUser = new Observable<AuthenticatedModel>((observer) => {
    const helper = new JwtHelperService();
    const user = new AuthenticatedModel();

    // get the embbeded information from token and save logged in user info
    // we check if the page refreshed and component cleaned. If yes we repopulate the user
    const rawToken = localStorage.getItem('token');

    if (!rawToken) {
      this.router.navigate(['/login']);
      return;
    }

    Object.assign(user
      , JSON.parse(helper.decodeToken(rawToken).sub));

    this.authenticatedUser = user;

    observer.next(user);
    observer.complete();
  });

  get = new Observable<AuthenticatedModel>((observer) => {
    if (!this.authenticatedUser) {
      this.setUser.subscribe((result) => {
        this.authenticatedUser = result;
        observer.next(this.authenticatedUser);
      });
    }

    observer.next(this.authenticatedUser);
  });

  getUserObs = new Observable<AuthenticatedModel>((observer) => {
    if (!this.authenticatedUser) {
      this.setUser.subscribe();
    }
    observer.next(this.authenticatedUser);
    observer.complete();
  });
}
