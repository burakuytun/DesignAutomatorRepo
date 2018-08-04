import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { trigger, transition, animate, style } from '@angular/animations'

@Component({
  selector: 'app-clearanceimporter',
  templateUrl: './clearanceimporter.component.html',
  styleUrls: ['./clearanceimporter.component.scss'],
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

export class ClearanceImporterComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  advancedClearanceConfiguration = false;

  slideClearanceSettings() { this.advancedClearanceConfiguration = !this.advancedClearanceConfiguration }

  constructor(fb: FormBuilder) {

    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }
}
