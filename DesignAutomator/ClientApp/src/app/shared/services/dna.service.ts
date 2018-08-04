import { Injectable } from '@angular/core';
import { UserDnaClient } from '../../models/dna/userdnaclient.model';
import { HttpClient } from '@angular/common/http';
import { UserService } from './user.service';
import { FilteredUserDna } from "../../models/dna/filtereduserdna";
import { Observable, Subject } from "rxjs";
import { ApplicationError } from "../handlers/applicationerror";
import { stringifyOnce } from "../utils/jsonstringfyonce.util";
import 'rxjs/add/operator/map';
import { ISelectedDna } from "../components/dnaselector/dnaselector.component";
import { AuthenticatedModel } from "../../models/authentication/authenticated.model";

@Injectable({ providedIn: 'root' })
export class DnaService {

  private dnaLocalStorageName = 'dnaStorage';

  loggedInUser: AuthenticatedModel;

  private dnaSubject = new Subject<FilteredUserDna[]>();
  filteredUserDnaList = this.dnaSubject.asObservable();

  private defaultDnaSubject = new Subject<{ clientName: string, dnaName: string, dnaId: number }>();
  defaultDnaObservable = this.defaultDnaSubject.asObservable();

  defaultDna: { dnaName: string, clientName: string, dnaId: number };

  constructor(private http: HttpClient,
    private userService: UserService) {
    this.userService.getUserObs.subscribe((user: AuthenticatedModel) => {
      this.loggedInUser = user;
      this.getDefaultDna();
    });

    if (this.loggedInUser)
      this.setDnaToStorage();
  }

  private service = 'DnaService';

  getDna(): Array<FilteredUserDna> {
    var userDnaClient = new Array<FilteredUserDna>();
    const dnaInfo = localStorage.getItem(this.dnaLocalStorageName);

    if (dnaInfo) {
      this.dnaSubject.next(Object.assign(userDnaClient, JSON.parse(localStorage.getItem(this.dnaLocalStorageName))));
      return Object.assign(userDnaClient, JSON.parse(localStorage.getItem(this.dnaLocalStorageName)));
    } else {
      userDnaClient = this.setDnaToStorage();
    }

    return userDnaClient;
  }

  getCurrentDefaultDna() {
    return this.defaultDna;
  }

  getDefaultDna() {
    var userDnaClient: Array<FilteredUserDna>;

    this.dnaSubject.subscribe((dnaList: Array<FilteredUserDna>) => {

      userDnaClient = dnaList;

      if (userDnaClient && userDnaClient.length > 0 && userDnaClient.filter(p => p.isDefault)) {
        this.defaultDna = {
          clientName: userDnaClient.filter(p => p.isDefault)[0].clientName,
          dnaName: userDnaClient.filter(p => p.isDefault)[0].uname,
          dnaId: userDnaClient.filter(p => p.isDefault)[0].dnaClientId
        };
      }

      this.defaultDnaSubject.next(this.defaultDna);
    });
  };

  setDnaToStorage() {
    var _userDnaClient = new Array<FilteredUserDna>();

    this.getDnaClientsOfUser()
      .subscribe((userDnaClient: UserDnaClient[]) => {
        _userDnaClient = this.createFilteredDna(userDnaClient);
        this.dnaSubject.next(_userDnaClient);

        localStorage.setItem(this.dnaLocalStorageName,
          stringifyOnce(
            _userDnaClient,
            '',
            ''));
      });

    return _userDnaClient;
  }

  clear() {
    localStorage.removeItem(this.dnaLocalStorageName);
  }

  changeDefaultDnaOfUser(selectedDna: ISelectedDna) {
    if (this.loggedInUser === null)
      throw new ApplicationError('Logged in user can\'t be loaded. Refresh the page and try again');

    if (!selectedDna || selectedDna.dnaId === 0)
      throw new ApplicationError('Select a Dna from Dna panel to continue');

    this.updateUserDefaultDna(selectedDna).subscribe(() => {
      localStorage.removeItem(this.dnaLocalStorageName);
      this.setDnaToStorage();
      this.getDefaultDna();
    });
  }

  updateUserDefaultDna(selectedDna) {
    //let postObject = { 'newDefaultDna': selectedDna.dnaId };
    return this.http.post(`api/${this.service}/UpdateUserDefaultDna`, selectedDna.dnaId, { responseType: 'text' });
  };

  getDnaClientsOfUser() {
    return this.http.get<UserDnaClient[]>(`api/${this.service}/GetUserDnaForStorage`)
      .map((response) => response);
  }

  createFilteredDna(userDna) {
    var filteredUserDna = new Array<FilteredUserDna>();
    userDna.forEach((item) => {
      let tempItem: FilteredUserDna = {
        isDefault: item.isDefault,
        clientId: item.dnaClient.clientId,
        uname: item.dnaClient.uname,
        dnalogo: item.dnaClient.dnalogo,
        colour1: item.dnaClient.colour1,
        colour2: item.dnaClient.colour2,
        colour3: item.dnaClient.colour3,
        colour4: item.dnaClient.colour4,
        colour5: item.dnaClient.colour5,
        naming: item.dnaClient.naming,
        clientName: item.dnaClient.clientName,
        clientAddress1: item.dnaClient.clientAddress1,
        clientAddress2: item.dnaClient.clientAddress2,
        clientCountry: item.dnaClient.clientCountry,
        clientPostCode: item.dnaClient.clientPostCode,
        dnaClientId: item.dnaClientId
      };
      filteredUserDna.push(tempItem);
    });

    return filteredUserDna;
  }

}
