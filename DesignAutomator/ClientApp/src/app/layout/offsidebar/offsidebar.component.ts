import { Component, OnInit, OnDestroy } from '@angular/core';

declare var $: any;

import { SettingsService } from '../../core/settings/settings.service';
import { ThemesService } from '../../core/themes/themes.service';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn } from '@angular/forms';
import { DnaService } from "../../shared/services/dna.service";
import { ISelectedDna } from "../../shared/components/dnaselector/dnaselector.component";


@Component({
  selector: 'app-offsidebar',
  templateUrl: './offsidebar.component.html',
  styleUrls: ['./offsidebar.component.scss']
})

export class OffsidebarComponent implements OnInit, OnDestroy {
  valForm: FormGroup;
  currentTheme: any;
  selectedLanguage: string;
  clickEvent = 'click.offsidebar';
  $doc: any = null;
  selectedDna: ISelectedDna;
  defaultDna: { clientName: string, dnaName: string, dnaId: number };

  constructor(public settings: SettingsService,
    public themes: ThemesService,
    fb: FormBuilder,
    private dnaService: DnaService) {
    this.currentTheme = themes.getDefaultTheme();
    this.selectedLanguage = 'en';

    this.valForm = fb.group({
    });
  }

  ngOnInit() {
    this.anyClickClose();
    this.dnaService.defaultDnaObservable.subscribe((res) => {
      this.defaultDna = res;
    });
  }

  setTheme() {
    this.themes.setTheme(this.currentTheme);
  }

  getLangs() {
    return [{ code: 'en', text: 'English' }];
  }

  anyClickClose() {
    this.$doc = $(document).on(this.clickEvent, (e) => {
      if (!$(e.target).parents('.offsidebar').length) {
        this.settings.layout.offsidebarOpen = false;
      }
    });
  }

  setDnaAsDefaultEvent() {
    this.dnaService.changeDefaultDnaOfUser(this.selectedDna);
  }

  ngOnDestroy() {
    if (this.$doc)
      this.$doc.off(this.clickEvent);
  }

  defaultDnaChanged(eventArgs) {
    this.selectedDna = eventArgs;
  }
}
