import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import {SettingsService} from "../../../core/settings/settings.service";

@Component({
  selector: 'app-selectdefaultdna',
  templateUrl: './selectdefaultdna.component.html',
  styleUrls: ['./selectdefaultdna.component.scss']
})
export class SelectDefaultDnaComponent implements OnInit {
  valForm: FormGroup;


  constructor(fb: FormBuilder, public settings: SettingsService) {

    // Model Driven validation
    this.valForm = fb.group({
    });
  }

  openSideBar() {
    this.settings.layout.offsidebarOpen = true;
  };

  ngOnInit() {
  }
}
