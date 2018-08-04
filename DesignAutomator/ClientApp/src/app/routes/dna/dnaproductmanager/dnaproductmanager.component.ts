import { Component, OnInit } from '@angular/core';
import { trigger, transition, animate, style } from '@angular/animations'
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'app-dnaproductmanager',
  templateUrl: './dnaproductmanager.component.html',
  styleUrls: ['./dnaproductmanager.component.scss'],
  animations: [
    trigger('slideInOut', [
      transition(':enter', [
        style({ transform: 'translateY(-100%)' }),
        animate('400ms ease-in', style({ transform: 'translateY(0%)' }))
      ]),
      transition(':leave', [
        animate('400ms ease-in', style({ transform: 'translateY(-100%)' }))
      ])
    ])
  ]
})
export class DnaProductManagerComponent implements OnInit {
  libraryParametersVisibleState = false;
  valForm: FormGroup;
  constructor(fb: FormBuilder, public ngxSmartModalService: NgxSmartModalService) {

    // Model Driven validation
    this.valForm = fb.group({
      'buildingType': [null, Validators.maxLength(3)]
    });
  }

  slideShowLibraryParameters() { this.libraryParametersVisibleState = !this.libraryParametersVisibleState }

  ngOnInit() {
  }

}
