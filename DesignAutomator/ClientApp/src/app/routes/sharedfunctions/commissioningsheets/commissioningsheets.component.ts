//http://themicon-001-site1.atempurl.com/elements/sortable
//use this multilist sortable from here if advanced naming has problems
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { trigger, transition, animate, style } from '@angular/animations'
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { AutomationUtilService } from "../../../shared/services/automationutil.serivce";
import { NamingSettingsService } from "./namingsettings.service";
import { SortablejsOptions } from 'angular-sortablejs';

@Component({
  selector: 'app-commissioningsheets',
  templateUrl: './commissioningsheets.component.html',
  styleUrls: ['./commissioningsheets.component.scss'],
  animations: [
    trigger('slideInOut', [
      transition(':enter', [
        style({ transform: 'translateY(-100%)' }),
        animate('400ms ease-in', style({ transform: 'translateY(0%)' }))
      ]),
      transition(':leave', [
        animate('400ms ease-in', style({ transform: 'translateY(-100%)' }))
      ])
    ])
  ]
})
export class CommissioningSheetsComponent implements OnInit {
  functionName: string;
  valForm: FormGroup;
  advancedSystemConfigurationVisibleSate = false;
  advancedNamingVisibleSate = false;
  automationUtilService = new AutomationUtilService();
  namingSettingsService = new NamingSettingsService();

  doorExampleText;
  readerExampleText;
  inputExampleText;
  outputExampleText;
  rmInputExampleText;
  rmOutputExampleText;
  controllerExampleText;
  clusterExampleText;

  doorComponents = this.namingSettingsService.getComponents('door');
  doorCurrentSelected = this.namingSettingsService.getInitialSelected('door');

  readerComponents = this.namingSettingsService.getComponents('reader');
  readerCurrentSelected = this.namingSettingsService.getInitialSelected('reader');

  inputComponents = this.namingSettingsService.getComponents('input');
  inputCurrentSelected = this.namingSettingsService.getInitialSelected('input');

  outputComponents = this.namingSettingsService.getComponents('output');
  outputCurrentSelected = this.namingSettingsService.getInitialSelected('output');

  rmInputComponents = this.namingSettingsService.getComponents('rmInput');
  rmInputCurrentSelected = this.namingSettingsService.getInitialSelected('rmInput');

  rmOutputComponents = this.namingSettingsService.getComponents('rmOutput');
  rmOutputCurrentSelected = this.namingSettingsService.getInitialSelected('rmOutput');

  controllerComponents = this.namingSettingsService.getComponents('controller');
  controllerCurrentSelected = this.namingSettingsService.getInitialSelected('controller');

  clusterComponents = this.namingSettingsService.getComponents('cluster');
  clusterCurrentSelected = this.namingSettingsService.getInitialSelected('cluster');

  slideSystemConfiguration() { this.advancedSystemConfigurationVisibleSate = !this.advancedSystemConfigurationVisibleSate; }
  slideNamingSettings() { this.advancedNamingVisibleSate = !this.advancedNamingVisibleSate; }

  constructor(private route: ActivatedRoute,
    fb: FormBuilder,
    private router: Router) {

    this.updateExampleTexts();

    this.route.params.subscribe(params => this.functionName =
      this.automationUtilService.getTheFunctionNameFromRouteParam(Number(params['function'])));

    // Model Driven validation
    this.valForm = fb.group({
      'buildingType': [null, Validators.maxLength(3)]
    });
  }

  updateExampleTexts() {
    this.doorExampleText = this.namingSettingsService.getExampleText(this.doorCurrentSelected);
    this.readerExampleText = this.namingSettingsService.getExampleText(this.readerCurrentSelected);
    this.inputExampleText = this.namingSettingsService.getExampleText(this.inputCurrentSelected);
    this.outputExampleText = this.namingSettingsService.getExampleText(this.outputCurrentSelected);
    this.rmInputExampleText = this.namingSettingsService.getExampleText(this.rmInputCurrentSelected);
    this.rmOutputExampleText = this.namingSettingsService.getExampleText(this.rmOutputCurrentSelected);
    this.controllerExampleText = this.namingSettingsService.getExampleText(this.controllerCurrentSelected);
    this.clusterExampleText = this.namingSettingsService.getExampleText(this.clusterCurrentSelected);
  }

  executeEvent(event: any) {
    if (event.item &&
      event.item.getAttribute('listtype') &&
      event.item.getAttribute('name') &&
      event.item.getAttribute('listtype').includes('current')) {

      let listSet = event.item.getAttribute('listtype').replace('current', '');

      if (listSet === 'door') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.doorComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.doorComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'reader') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.readerComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.readerComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'input') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.inputComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.inputComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'output') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.outputComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.outputComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'rminput') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.rmInputComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.rmInputComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'rmoutput') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.rmOutputComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.rmOutputComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'cluster') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.clusterComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.clusterComponents.splice(1, 0, ['Space', ' ']);
      } else if (listSet === 'controller') {
        if (event.item.getAttribute('name').includes('Seperator'))
          this.controllerComponents.unshift(['Seperator', '-']);
        else if (event.item.getAttribute('name').includes('Space'))
          this.controllerComponents.splice(1, 0, ['Space', ' ']);
      }
    }
  }


  optionsDoors: SortablejsOptions = {
    group: 'optionsDoors',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsReaders: SortablejsOptions = {
    group: 'optionsReaders',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsInputs: SortablejsOptions = {
    group: 'optionsInputs',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsOutputs: SortablejsOptions = {
    group: 'optionsOutputs',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsRmInputs: SortablejsOptions = {
    group: 'optionsRmInputs',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsRmOutputs: SortablejsOptions = {
    group: 'optionsRmOutputs',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsClusters: SortablejsOptions = {
    group: 'optionsClusters',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };
  optionsControllers: SortablejsOptions = {
    group: 'optionsControllers',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };

  options: SortablejsOptions = {
    group: 'mapping',
    onUpdate: (event: any) => {
      this.updateExampleTexts();
    },
    onAdd: (event: any) => {
      this.executeEvent(event);
      this.updateExampleTexts();
    }
  };

  ngOnInit() {
  }
}
