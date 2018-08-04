import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { AutomationUtilService } from "../../../shared/services/automationutil.serivce";

@Component({
  selector: 'app-componentcount',
  templateUrl: './componentcount.component.html',
  styleUrls: ['./componentcount.component.scss']
})
export class ComponentCountComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  automationUtilService = new AutomationUtilService();

  constructor(private route: ActivatedRoute,
    fb: FormBuilder,
    private router: Router) {

    this.route.params.subscribe(params => this.functionName = this.automationUtilService.getTheFunctionNameFromRouteParam(Number(params['function'])));

    // Model Driven validation
    this.valForm = fb.group({
      'fieldAllowance': [null, Validators.compose([Validators.required, CustomValidators.number])],
      'equipmentAllowance': [null, Validators.compose([Validators.required, CustomValidators.number])]
    });
  }

  ngOnInit() {
  }

}
