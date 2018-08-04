import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { ModalService } from "../services/modal.service";
import { ApplicationError } from "./applicationerror";

@Injectable()
export class CustomErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) {
  }

  handleError(error: any) {
    const modalService = this.injector.get(ModalService);
    const router = this.injector.get(Router);

    if (error instanceof ApplicationError)
      modalService.showModal(error.message ? error.message : error.toString());

    //enable this for prod
    //if (!error.status) { console.log('!!!ERROR OCCURED!!:' + error); return; }

    switch (error.status) {
      case 400: { modalService.showModal(error.error); }
      case 401: { router.navigate(["/login"]); }
    }

  }
}
