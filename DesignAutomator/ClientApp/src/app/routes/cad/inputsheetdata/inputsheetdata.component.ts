import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-inputsheetdata',
  templateUrl: './inputsheetdata.component.html',
  styleUrls: ['./inputsheetdata.component.scss']
})
export class InputSheetDataComponent implements OnInit {
  valForm: FormGroup;

  constructor(fb: FormBuilder) {
    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }

}
