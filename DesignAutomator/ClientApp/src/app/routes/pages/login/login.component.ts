import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../../../core/settings/settings.service';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { AuthenticationService } from "./authentication.service";
import { AuthenticationModel } from "../../../models/authentication/authentication.model";
import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  valForm: FormGroup;
  authentication = new AuthenticationModel();
  isAdAuthentication = false;

  constructor(public settings: SettingsService, private authenticationService: AuthenticationService, fb: FormBuilder) {

    this.valForm = fb.group({
      'email': [null, Validators.compose([Validators.required, CustomValidators.email])],
      'password': [null, Validators.required]
    });
  }

  isAuthLogin() { this.isAdAuthentication = !this.isAdAuthentication; }

  submitForm($ev, value: any) {
    $ev.preventDefault();
    for (let c in this.valForm.controls) {
      this.valForm.controls[c].markAsTouched();
    }

    if (this.valForm.valid) {
      this.authentication.username = this.valForm.value.email;
      this.authentication.password = this.valForm.value.password;
      this.authentication.isActiveDomainAccount = this.isAdAuthentication;
      this.authenticationService.authenticate(this.authentication);
    }
  }

  ngOnInit() {

  }


}

