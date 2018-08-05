import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // this is needed!
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AppComponent } from './app.component';

import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { LayoutModule } from './layout/layout.module';
import { RoutesModule } from './routes/routes.module';
import { UserService } from "./shared/services/user.service";
import { CustomErrorHandler } from "./shared/handlers/error.handler";
import { DnaService } from "./shared/services/dna.service";
import { SectionService } from "./shared/services/help/section.service";
import { PaginationModule } from 'ngx-bootstrap/pagination';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    LayoutModule,
    CoreModule,
    SharedModule.forRoot(),
    BrowserAnimationsModule, // required for ng2-tag-input
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RoutesModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    }),
    PaginationModule.forRoot()
  ],
  providers: [DnaService, UserService,SectionService],
  bootstrap: [AppComponent]
})
export class AppModule { }

//use below for enabling custom error handling
//providers: [DnaService, UserService, { provide: ErrorHandler, useClass: CustomErrorHandler }],
//
