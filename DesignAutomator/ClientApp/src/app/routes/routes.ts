import { LayoutComponent } from '../layout/layout.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { RecoverComponent } from './pages/recover/recover.component';
import { LockComponent } from './pages/lock/lock.component';
import { MaintenanceComponent } from './pages/maintenance/maintenance.component';
import { Error404Component } from './pages/error404/error404.component';
import { Error500Component } from './pages/error500/error500.component';
import { AuthenticationGuard } from "../shared/guards/authentication.guard";

export const routes = [

  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthenticationGuard], children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', loadChildren: './home/home.module#HomeModule' },
      { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule', canActivate: [AuthenticationGuard] },
      { path: 'dna', loadChildren: './dna/dna.module#DnaModule', canActivate: [AuthenticationGuard] },
      { path: 'administration', loadChildren: './administration/administration.module#AdministrationModule', canActivate: [AuthenticationGuard] },
      { path: 'cad', loadChildren: './cad/cad.module#CADModule', canActivate: [AuthenticationGuard] },
      { path: 'aacs', loadChildren: './aacs/aacs.module#AACSModule', canActivate: [AuthenticationGuard] },
      { path: 'sharedfunctions', loadChildren: './sharedfunctions/sharedfunctions.module#SharedFunctionsModule', canActivate: [AuthenticationGuard] },
      { path: 'help', loadChildren: './help/help.module#HelpModule' }
    ]
  },

  // Not lazy-loaded routes
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'recover', component: RecoverComponent },
  { path: 'lock', component: LockComponent },
  { path: 'maintenance', component: MaintenanceComponent },
  { path: '404', component: Error404Component },
  { path: '500', component: Error500Component },

  // Not found
  { path: '**', redirectTo: 'home' }

];
