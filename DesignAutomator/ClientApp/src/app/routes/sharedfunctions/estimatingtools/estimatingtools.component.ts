import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { AutomationUtilService } from "../../../shared/services/automationutil.serivce";
import { DnaService } from "../../../shared/services/dna.service";
import { SettingsService } from "../../../core/settings/settings.service";
import { FileUploadUtilService } from "../../../shared/utils/fileupload.util.service";
import { AutomationFunctionsService } from "../../../shared/services/automationfunctions.service";


@Component({
  selector: 'app-estimatingtools',
  templateUrl: './estimatingtools.component.html',
  styleUrls: ['./estimatingtools.component.scss']
})

export class EstimatingToolsComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  automationUtilService = new AutomationUtilService();
  defaultDna: { clientName: string, dnaName: string, dnaId: number };
  selectedFiles: Array<string> = new Array<string>();
  isProcessButtonDisabled: boolean;
  functionId: number;

  constructor(private route: ActivatedRoute,
    public settings: SettingsService,
    private dnaService: DnaService,
    private fileUploadUtilService: FileUploadUtilService,
    fb: FormBuilder,
    private router: Router,
    private automationFunctionsService: AutomationFunctionsService) {

    this.route.params.subscribe(params => {
      this.functionId = Number(params['function']);
      this.functionName =
        this.automationUtilService.getTheFunctionNameFromRouteParam(this.functionId);
    });
    // Model Driven validation
    this.valForm = fb.group({
    });

    console.log('from constructor' + this.defaultDna);
  }

  ngOnInit() {
    this.dnaService.defaultDnaObservable.subscribe(
      (res) => {
        if (!res || res.dnaId <= 0) {
          this.settings.layout.offsidebarOpen = true;
        }
        this.defaultDna = res;
        console.log('from observable' + this.defaultDna);
      },
      error => { console.log(error) });

    this.defaultDna= this.dnaService.getCurrentDefaultDna();

    console.log('from ngonitit' + this.defaultDna);

    this.isProcessButtonDisabled = false;
  }

  uploadedFileChanged(eventArgs) {
    this.selectedFiles = eventArgs;
  }

  runFunction() {
    console.log(this.defaultDna);

    this.isProcessButtonDisabled = this.fileUploadUtilService.validateFiles(this.selectedFiles);

    let postObject = { functionId: this.functionId, fileList: this.selectedFiles, dnaId: this.defaultDna.dnaId };
    this.automationFunctionsService.runFunction(postObject).subscribe
      (
      () => alert('woop'),
      () => alert('no'),
      () => this.isProcessButtonDisabled = false
      );
  }
}
