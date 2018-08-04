import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'app-modalext',
  templateUrl: './modalext.component.html',
  styleUrls: ['./modalext.component.scss']
})
export class ModalExtComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }

}

@Component({
  selector: 'modal-content',
  templateUrl: './modalext.component.html'
})
export class ModalContentComponent implements OnInit {
  public title: string;
  public list: any[] = [];
  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
    console.log('BsModalRef from modal content component', this.bsModalRef);
  }
}
