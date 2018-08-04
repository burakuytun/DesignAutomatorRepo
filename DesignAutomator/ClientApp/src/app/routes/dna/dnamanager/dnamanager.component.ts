import { Component, OnInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-dnamanager',
  templateUrl: './dnamanager.component.html',
  styleUrls: ['./dnamanager.component.scss']
})
export class DnaManagerComponent implements OnInit {
  valForm: FormGroup;

  constructor(fb: FormBuilder, public ngxSmartModalService: NgxSmartModalService) {
    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }
}
