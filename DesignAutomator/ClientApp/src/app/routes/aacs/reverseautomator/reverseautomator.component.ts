import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-reverseautomator',
  templateUrl: './reverseautomator.component.html',
  styleUrls: ['./reverseautomator.component.scss']
})
export class ReverseAutomatorComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;

  constructor(fb: FormBuilder) {

    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }
}
