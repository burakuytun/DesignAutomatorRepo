import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-outputtagdata',
  templateUrl: './outputtagdata.component.html',
  styleUrls: ['./outputtagdata.component.scss']
})
export class OutputTagDataComponent implements OnInit {
  valForm: FormGroup;

  constructor(fb: FormBuilder) {
    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  ngOnInit() {
  }

}
