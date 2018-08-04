import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ToasterModule } from 'angular2-toaster/angular2-toaster';

import { AccordionModule } from 'ngx-bootstrap/accordion';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { RatingModule } from 'ngx-bootstrap/rating';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { DatepickerModule } from 'ngx-bootstrap/datepicker';

import { ColorsService } from './services/colors.service';
import { CheckallDirective } from './directives/checkall/checkall.directive';
import { NowDirective } from './directives/now/now.directive';
import { ScrollableDirective } from './directives/scrollable/scrollable.directive';

import { GuardsModule } from "./guards/guards.module";
import { InterceptorsModule } from "./interceptors/interceptors.module";
import { ModalExtComponent, ModalContentComponent } from "./components/modal/modalext.component";
import { DnaSelectorComponent } from './components/dnaselector/dnaselector.component';
import { CustomFileUploadComponent } from './components/customfileupload/customfileupload.component';
import { FileUploadModule } from 'ng2-file-upload';
import { FunctionButtonsetComponent } from './components/functionbuttonset/functionbuttonset.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    GuardsModule,
    InterceptorsModule,
    AccordionModule.forRoot(),
    AlertModule.forRoot(),
    ButtonsModule.forRoot(),
    CarouselModule.forRoot(),
    CollapseModule.forRoot(),
    DatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    PaginationModule.forRoot(),
    ProgressbarModule.forRoot(),
    RatingModule.forRoot(),
    TabsModule.forRoot(),
    TimepickerModule.forRoot(),
    TooltipModule.forRoot(),
    TypeaheadModule.forRoot(),
    ToasterModule,
    FileUploadModule
  ],
  providers: [
    ColorsService
  ],
  declarations: [
    CheckallDirective,
    NowDirective,
    ScrollableDirective,
    ModalExtComponent,
    ModalContentComponent,
    DnaSelectorComponent,
    CustomFileUploadComponent,
    FunctionButtonsetComponent
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    RouterModule,
    AccordionModule,
    AlertModule,
    ButtonsModule,
    CarouselModule,
    CollapseModule,
    DatepickerModule,
    BsDropdownModule,
    ModalModule,
    PaginationModule,
    ProgressbarModule,
    RatingModule,
    TabsModule,
    TimepickerModule,
    TooltipModule,
    TypeaheadModule,
    ToasterModule,
    CheckallDirective,
    NowDirective,
    ScrollableDirective,
    GuardsModule,
    InterceptorsModule,
    ModalExtComponent,
    ModalContentComponent,
    DnaSelectorComponent,
    CustomFileUploadComponent,
    FunctionButtonsetComponent
  ],
  entryComponents: [ModalExtComponent, ModalContentComponent]
})

// https://github.com/ocombe/ng2-translate/issues/209
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule
    };
  }
}
