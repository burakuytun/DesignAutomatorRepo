import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';
import { InputSheetDataComponent } from './inputsheetdata/inputsheetdata.component';
import { OutputSheetDataComponent } from './outputsheetdata/outputsheetdata.component';
import { OutputTagDataComponent } from './outputtagdata/outputtagdata.component';


const routes: Routes = [
  { path: 'inputsheetdata', component: InputSheetDataComponent },
  { path: 'outputsheetdata', component: OutputSheetDataComponent },
  { path: 'outputtagdata', component: OutputTagDataComponent },
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    InputSheetDataComponent,
    OutputSheetDataComponent,
    OutputTagDataComponent
  ],
  exports: [
    RouterModule
  ]
})
export class CADModule { }
