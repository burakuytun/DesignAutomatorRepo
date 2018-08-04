import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';

import { Dashboardv1Component } from './dashboardv1.component';

const routes: Routes = [
    { path: '', redirectTo: 'dashboard' },
    { path: 'v1', component: Dashboardv1Component }
];

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Dashboardv1Component
    ],
    exports: [
        RouterModule
    ]
})
export class DashboardModule { }
