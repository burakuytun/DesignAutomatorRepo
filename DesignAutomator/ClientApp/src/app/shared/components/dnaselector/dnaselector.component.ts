import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';
import { FilteredUserDna } from "../../../models/dna/filtereduserdna";
import { DnaService } from "../../services/dna.service";

export interface ISelectedDna {
  dnaName: string;
  dnaId: number;
}

@Component({
  selector: 'app-dnaselector',
  templateUrl: './dnaselector.component.html',
  styleUrls: ['./dnaselector.component.scss']
})
export class DnaSelectorComponent implements OnInit {
  availableClientList = [];
  availableDnaList = [];

  selectedClient: { clientName, clientId };
  selectedDna: ISelectedDna;

  @Input() defaultDna: { clientName: string, dnaName: string, dnaId: number };
  @Output() defaultDnaChanged = new EventEmitter();

  filteredUserDna = new Array<FilteredUserDna>();

  private filteredDnaSubsciption: Subscription;

  constructor(private dnaService: DnaService) {
  }

  ngOnInit() {
    this.filteredDnaSubsciption =
      this.dnaService.filteredUserDnaList.subscribe((dnaList: Array<FilteredUserDna>) => {

        this.availableDnaList = [];
        this.selectedClient = undefined;
        this.filteredUserDna = dnaList;

        this.availableClientList =
          this.filteredUserDna.map(x => { return { clientName: x.clientName, clientId: x.clientId } });

        if (this.filteredUserDna.filter(p => p.isDefault).length > 0) {
          this.defaultDna = {
            clientName: this.filteredUserDna.filter(p => p.isDefault)[0].clientName,
            dnaName: this.filteredUserDna.filter(p => p.isDefault)[0].uname,
            dnaId: this.filteredUserDna.filter(p => p.isDefault)[0].dnaClientId
          };
        }
      });
  }

  onClientChange() {
    this.selectedDna = undefined;

    if (this.selectedClient)
      this.availableDnaList = this.filteredUserDna.filter(p => p.clientId === this.selectedClient.clientId)
        .map(x => { return { dnaName: x.uname, dnaId: x.dnaClientId } });
    else
      this.availableDnaList = [];
  }

  onDnaChange() {
    this.defaultDnaChanged.emit(this.selectedDna);
  }
}
