import { Injectable } from "@angular/core";
import { ModalExtComponent, ModalContentComponent } from "../components/modal/modalext.component";
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Injectable({ providedIn: "root" })
export class ModalService {
  constructor(private modalService: BsModalService) { }
  bsModalRef: BsModalRef;

  showModal(message: string, title = "For your attention"): void {
    this.bsModalRef = this.modalService.show(ModalContentComponent);
    this.bsModalRef.content.title = title;
    this.bsModalRef.content.content = message;
  }
}
