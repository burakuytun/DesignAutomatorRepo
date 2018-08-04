import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgxSelectModule } from 'ngx-select-ex';
import { ColorPickerModule, ColorPickerService } from 'ngx-color-picker';
import { DndModule } from 'ng2-dnd';
import { SharedModule } from '../../shared/shared.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { DnaManagerComponent } from "./dnamanager/dnamanager.component";
import { AddDnaComponent } from './adddna/adddna.component';
import { ModifyDnaComponent } from './modifydna/modifydna.component';
import { DnaAdministrationComponent } from './dnaadministration/dnaadministration.component';
import { DnaProductManagerComponent } from './dnaproductmanager/dnaproductmanager.component';
import { SelectDefaultDnaComponent } from './selectdefaultdna/selectdefaultdna.component';

const routes: Routes = [
  { path: 'dnamanager', component: DnaManagerComponent },
  { path: 'dnaadministration', component: DnaAdministrationComponent },
  { path: 'adddna', component: AddDnaComponent },
  { path: 'dnaproductmanager', component: DnaProductManagerComponent },
  { path: 'modifydna', component: ModifyDnaComponent },
  { path: 'selectdefaultdna', component: SelectDefaultDnaComponent },

];

@NgModule({
  imports: [
    SharedModule,
    DndModule.forRoot(),
    RouterModule.forChild(routes),
    NgxSmartModalModule.forRoot(),
    NgxSelectModule,
    ColorPickerModule,
    Ng2TableModule,
    NgxDatatableModule
  ],
  providers: [ColorPickerService],
  declarations: [
    DnaManagerComponent,
    AddDnaComponent,
    ModifyDnaComponent,
    DnaAdministrationComponent,
    DnaProductManagerComponent,
    SelectDefaultDnaComponent
  ],
  exports: [
    RouterModule
  ]
})

export class DnaModule { }
