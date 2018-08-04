import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { TokenService } from "../../../shared/services/token.service";
import { AuthenticationModel } from "../../../models/authentication/authentication.model";
import { ModalService } from "../../../shared/services/modal.service";
import { AuthenticatedModel } from "../../../models/authentication/authenticated.model";
import { UserService } from "../../../shared/services/user.service";
import { MenuService } from "../../../core/menu/menu.service";
import { DnaService } from "../../../shared/services/dna.service";
import { menu } from "../../menu";

declare var $: any;

@Injectable({ providedIn: "root" })
export class AuthenticationService {
  private service = "AuthenticationService";
  authenticatedModel = new AuthenticatedModel();

  constructor(
    private http: HttpClient,
    private router: Router,
    private tokenService: TokenService,
    private modalService: ModalService,
    private userService: UserService,
    public menuService: MenuService,
    private dnaService: DnaService) { }

  authenticate(authentication: AuthenticationModel) {
    this.http.post(`api/${this.service}/Authenticate`, authentication, { responseType: "text" }).subscribe(
      result => {
        if (result) {
          this.tokenService.set(result);

          this.userService.setUser.subscribe((user) => {
            this.menuService.addMenu(menu, user);
            this.dnaService.getDna();
            this.dnaService.getDefaultDna();
          });
        } else {
          this.modalService.showModal('Result is empty', "Something went wrong");
        }

        this.router.navigate(["/home"]);
      },
      error => {
        var message;
        if (error.status) {
          if (error.status === 404)
            message = "404 - Authentication service is not accessible";
          else if (error.status === 500)
            message = "500 - Please try again later";
          else
            message = `${error.error}. Please try again later.`;
        }

        this.modalService.showModal(message, "Something went wrong");
      },
      () => {
        this.router.navigate(["/home"]);
      }
    );
  }

  isAuthenticated(): boolean {
    return this.tokenService.exists();
  }

  logout() {
    this.tokenService.clear();
    this.dnaService.clear();
    this.router.navigate(["/login"]);
  }
}
