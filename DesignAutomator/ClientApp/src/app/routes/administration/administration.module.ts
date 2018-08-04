import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { UserAdministrationComponent } from "./useradministration/useradministration.component";

const routes: Routes = [
  { path: 'useradministration', component: UserAdministrationComponent }
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    NgxDatatableModule,
    Ng2TableModule,
    NgxSmartModalModule.forRoot()
  ], 
  declarations: [
    UserAdministrationComponent
  ],
  exports: [
    RouterModule
  ]
})
export class AdministrationModule { }
