import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';

import { FaqComponent } from "./faq/faq.component";
import { HelpcenterComponent } from "./helpcenter/helpcenter.component";
import { SearchComponent } from "./search/search.component";
import { NgxSelectModule } from 'ngx-select-ex';
import { PageContentComponent } from "./pagecontent/pagecontent.component";
import { PageContentAdminComponent } from "./pagecontentadmin/pagecontentadmin.component";
import { FaqAdminComponent } from "./faqadmin/faqadmin.component";

const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'helpcenter', component: HelpcenterComponent },
  { path: 'pagecontent', component: PageContentComponent },
  { path: 'pagecontentadmin', component: PageContentAdminComponent },
  { path: 'faqadmin', component: FaqAdminComponent }
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    NgxSelectModule
  ],
  declarations: [
    SearchComponent,
    FaqComponent,
    HelpcenterComponent,
    PageContentComponent,
    PageContentAdminComponent,
    FaqAdminComponent
  ],
  exports: [
    RouterModule
  ]
})
export class HelpModule { }

