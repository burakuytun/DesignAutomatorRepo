import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';
import { ErrorCheckComponent } from "./errorcheck/errorcheck.component";
import { ComponentCountComponent } from './componentcount/componentcount.component';
import { EstimatingToolsComponent } from './estimatingtools/estimatingtools.component';
import { CableEstimationComponent } from './cableestimation/cableestimation.component';
import { HardwareSheetComponent } from './hardwaresheet/hardwaresheet.component';
import { RevisionTrackerComponent } from './revisiontracker/revisiontracker.component';
import { CommissioningSheetsComponent } from './commissioningsheets/commissioningsheets.component';
import { SchematicsComponent } from './schematics/schematics.component';
import { HardwareOandMComponent } from './hardwareoandm/hardwareoandm.component';
import { SystemConfigurationFilesComponent } from './systemconfigurationfiles/systemconfigurationfiles.component';
import { SortablejsModule } from 'angular-sortablejs';

const routes: Routes = [
  { path: 'componentcount/:function', component: ComponentCountComponent },
  { path: 'errorcheck/:function', component: ErrorCheckComponent },
  { path: 'estimatingtools/:function', component: EstimatingToolsComponent },
  { path: 'cableestimation/:function', component: CableEstimationComponent },
  { path: 'hardwaresheet/:function', component: HardwareSheetComponent },
  { path: 'revisiontracker/:function', component: RevisionTrackerComponent },
  { path: 'commissioningsheets/:function', component: CommissioningSheetsComponent },
  { path: 'schematics/:function', component: SchematicsComponent },
  { path: 'hardwareoandm/:function', component: HardwareOandMComponent },
  { path: 'systemconfigurationfiles/:function', component: SystemConfigurationFilesComponent }
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    SortablejsModule.forRoot({ animation: 150 })
  ],
  declarations: [
    ErrorCheckComponent,
    ComponentCountComponent,
    EstimatingToolsComponent,
    CableEstimationComponent,
    HardwareSheetComponent,
    RevisionTrackerComponent,
    CommissioningSheetsComponent,
    SchematicsComponent,
    HardwareOandMComponent,
    SystemConfigurationFilesComponent
  ],
  exports: [
    RouterModule
  ]
})
export class SharedFunctionsModule { }
