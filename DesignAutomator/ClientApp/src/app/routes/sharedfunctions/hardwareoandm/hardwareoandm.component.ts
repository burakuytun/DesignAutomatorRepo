import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hardwareoandm',
  templateUrl: './hardwareoandm.component.html',
  styleUrls: ['./hardwareoandm.component.scss']
})
export class HardwareOandMComponent implements OnInit {

  functionid: number;

  constructor(private route: ActivatedRoute,
    private router: Router) {
    this.route.params.subscribe(params => this.functionid = params['function']);
  }

  ngOnInit() {
  }

}
