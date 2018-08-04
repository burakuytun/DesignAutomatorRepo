import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { TokenService } from "../services/token.service";

@Injectable()
export class AuthenticationGuard implements CanActivate {
	constructor(
		private router: Router,
		private tokenService: TokenService) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
		if (this.tokenService.exists()) { return true; }
		this.router.navigate(["/login"]);
		return false;
	}
}
