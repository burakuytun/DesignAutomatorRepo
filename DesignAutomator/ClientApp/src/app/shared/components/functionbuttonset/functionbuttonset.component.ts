import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-functionbuttonset',
  templateUrl: './functionbuttonset.component.html',
  styleUrls: ['./functionbuttonset.component.scss']
})
export class FunctionButtonsetComponent implements OnInit {
  @Output() processButtonClicked = new EventEmitter();
  @Input() isProcessDisabled: boolean;

  constructor() { }

  ngOnInit() {
  }

  onProcessClick() {
    this.processButtonClicked.emit();
  }
}
