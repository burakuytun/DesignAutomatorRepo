import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';
import { DoorWizardComponent } from "./doorwizard/doorwizard.component";
import { ReverseAutomatorComponent } from './reverseautomator/reverseautomator.component';
import { ClearanceImporterComponent } from './clearanceimporter/clearanceimporter.component';
import { SystemConversiontoHardwareSheetComponent } from './systemconversiontohardwaresheet/systemconversiontohardwaresheet.component';
import { EighthundredUpdateMigratorComponent } from './eighthundredupdatemigrator/eighthundredupdatemigrator.component';

const routes: Routes = [
  { path: 'doorwizard', component: DoorWizardComponent },
  { path: 'reverseautomator', component: ReverseAutomatorComponent },
  { path: 'clearanceimporter', component: ClearanceImporterComponent },
  { path: 'systemconversiontohardwaresheet', component: SystemConversiontoHardwareSheetComponent },
  { path: 'eighthundredupdatemigrator', component: EighthundredUpdateMigratorComponent },
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    DoorWizardComponent,
    ReverseAutomatorComponent,
    ClearanceImporterComponent,
    SystemConversiontoHardwareSheetComponent,
    EighthundredUpdateMigratorComponent,
  ],
  exports: [
    RouterModule
  ]
})
export class AACSModule { }
