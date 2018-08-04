import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { LayoutComponent } from './layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HeaderComponent } from './header/header.component';
import { NavsearchComponent } from './header/navsearch/navsearch.component';
import { UserblockComponent } from './sidebar/userblock/userblock.component';
import { FooterComponent } from './footer/footer.component';
import { OffsidebarComponent } from './offsidebar/offsidebar.component';

import { UserService } from "../shared/services/user.service";

@NgModule({
  imports: [
    SharedModule
  ],
  providers: [
    UserService
  ],
  declarations: [
    LayoutComponent,
    SidebarComponent,
    UserblockComponent,
    HeaderComponent,
    OffsidebarComponent,
    NavsearchComponent,
    FooterComponent
  ],
  exports: [
    LayoutComponent,
    SidebarComponent,
    UserblockComponent,
    HeaderComponent,
    OffsidebarComponent,
    NavsearchComponent,
    FooterComponent
  ]
})

export class LayoutModule { }
