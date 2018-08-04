import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "../services/token.service";

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
	constructor(private tokenService: TokenService) { }

	intercept(request: HttpRequest<any>, next: HttpHandler) {
		let url = request.url;

		if (!url.startsWith("http")) {
			url = document.getElementsByTagName("base").item(0).href + url;
		}

		request = request.clone({
          setHeaders: { Authorization: `Bearer ${this.tokenService.get()}`, 'Content-Type': 'application/json; charset=utf-8' },
			url
		});

		return next.handle(request);
	}
}
