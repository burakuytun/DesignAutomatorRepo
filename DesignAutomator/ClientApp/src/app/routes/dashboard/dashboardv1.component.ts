import { NgModule } from '@angular/core';

import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { ColorsService } from "../../shared/Colors/colors.service";
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'app-dashboardv1',
  templateUrl: './dashboardv1.component.html',
  styleUrls: ['./dashboardv1.component.scss'],
  providers: [ColorsService]
})

export class Dashboardv1Component implements OnInit {
   

  constructor(public colors: ColorsService, public http: HttpClient) {
  }

  ngOnInit() { }

  colorByName(name) {
    return this.colors.byName(name);
  }

}
