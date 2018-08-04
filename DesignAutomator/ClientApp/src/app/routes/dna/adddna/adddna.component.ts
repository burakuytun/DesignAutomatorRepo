import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { Countries } from "../../../models/countries/countries";

@Component({
  selector: 'app-adddna',
  templateUrl: './adddna.component.html',
  styleUrls: ['./adddna.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AddDnaComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;

  // country list
  public countries = Countries;
  colour1 = '#555555';
  colour2 = '#555555';
  colour3 = '#555555';
  colour4 = '#555555';
  colour5 = '#555555';

  listAvailableLibraries: Array<string> = ['Auto-Lock Type B', 'Auto-Key Switch', 'Auto-Intercorn', 'Auto-Monitored Input', 'Auto-OCTS', 'Auto=Break Glass', 'Auto-Central Security', 'Auto CCTV', 'Auto-Electrical', 'Auto-Crash Bar'];
  listAssignedLibraries: Array<string> = [];

  public value: any = {};

  public selected(value: any): void {
    console.log('Selected value is: ', value);
  }

  public removed(value: any): void {
    console.log('Removed value is: ', value);
  }

  public typed(value: any): void {
    console.log('New search input: ', value);
  }

  public refreshValue(value: any): void {
    this.value = value;
  }

  constructor(fb: FormBuilder) {

    // Model Driven validation
    this.valForm = fb.group({
      'dnaName': [null, Validators.compose([Validators.required])],
      'dnaPrefix': [null, Validators.compose([Validators.required])],
      'clientName': [null, Validators.compose([Validators.required])],
      'addressLine1': [],
      'addressLine2': [],
      'postcode': [],
      'colour1': []
    });

  }

  ngOnInit() {
  }

}
