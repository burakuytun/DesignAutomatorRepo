import { Injectable } from "@angular/core";
import { ModalService } from "../services/modal.service";

@Injectable({ providedIn: "root" })
export class FileUploadUtilService {
  constructor(private modalService: ModalService) {
  }

  validateFiles(selectedFiles) {
    let isValid = true;
    if (!selectedFiles || selectedFiles.length <= 0) {
      this.modalService.showModal('If you have selected files click Upload All to continue.', "Please select files to continue");
      isValid = false;
    }

    return isValid;
  }
}
