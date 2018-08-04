import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { AutomationUtilService } from "../../../shared/services/automationutil.serivce";
import { DnaService } from "../../../shared/services/dna.service";
import { SettingsService } from "../../../core/settings/settings.service";

@Component({
  selector: 'app-cableestimation',
  templateUrl: './cableestimation.component.html',
  styleUrls: ['./cableestimation.component.scss']
})
export class CableEstimationComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  automationUtilService = new AutomationUtilService();
  defaultDna: { clientName: string, dnaName: string, dnaId: number };
  selectedFiles: Array<string> = new Array<string>();

  constructor(private route: ActivatedRoute,
    public settings: SettingsService,
    private dnaService: DnaService,
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
    this.dnaService.defaultDnaObservable.subscribe(
      (res) => {
        if (!res || res.dnaId <= 0) {
          this.settings.layout.offsidebarOpen = true;
        }
        this.defaultDna = res;
        console.log(this.defaultDna);
      },
      error => { console.log(error) });
  }

  uploadedFileChanged(eventArgs) {
    this.selectedFiles = eventArgs;
    console.log(this.selectedFiles);
  }
}
