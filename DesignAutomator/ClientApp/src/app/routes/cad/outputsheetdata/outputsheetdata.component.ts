import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-outputsheetdata',
  templateUrl: './outputsheetdata.component.html',
  styleUrls: ['./outputsheetdata.component.scss']
})
export class OutputSheetDataComponent implements OnInit {
  valForm: FormGroup;

  constructor(fb: FormBuilder) {
    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }

}
