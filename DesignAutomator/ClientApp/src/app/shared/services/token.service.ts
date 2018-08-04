import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class TokenService {
	private token = "token";

	clear() {
		localStorage.removeItem(this.token);
	}

	exists() {
		return this.get() !== null;
	}

	get(): string {
      return localStorage.getItem(this.token);
	}

	set(token: string) {
	  localStorage.setItem(this.token, token);
	}
}
