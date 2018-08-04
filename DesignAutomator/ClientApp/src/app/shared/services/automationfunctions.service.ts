import { Injectable } from '@angular/core';
import { UserDnaClient } from '../../models/dna/userdnaclient.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { UserService } from './user.service';
import { FilteredUserDna } from "../../models/dna/filtereduserdna";
import { Observable, Subject } from "rxjs";
import { ApplicationError } from "../handlers/applicationerror";
import { stringifyOnce } from "../utils/jsonstringfyonce.util";
import 'rxjs/add/operator/map';
import { ISelectedDna } from "../components/dnaselector/dnaselector.component";
import { AuthenticatedModel } from "../../models/authentication/authenticated.model";

@Injectable({ providedIn: 'root' })
export class AutomationFunctionsService {

  private service = 'AutomationFunctionsService';

  constructor(private http: HttpClient,
    private userService: UserService) {

  }

  runFunction(postObject) {
    return this.http.post(`api/${this.service}/RunAutomationFunction`, JSON.stringify(postObject), { responseType: 'text' });
  };
}
