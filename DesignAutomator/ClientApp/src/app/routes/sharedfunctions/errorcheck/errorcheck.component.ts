import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { AutomationUtilService } from "../../../shared/services/automationutil.serivce";

@Component({
  selector: 'app-errorcheck',
  templateUrl: './errorcheck.component.html',
  styleUrls: ['./errorcheck.component.scss']
})
export class ErrorCheckComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  automationUtilService = new AutomationUtilService();

  constructor(private route: ActivatedRoute,
    fb: FormBuilder,
    private router: Router) {

    this.route.params.subscribe(params =>
      this.functionName =
      this.automationUtilService.getTheFunctionNameFromRouteParam(Number(params['function'])));

    // Model Driven validation
    this.valForm = fb.group({
    });
  }


  ngOnInit() {
  }

}
