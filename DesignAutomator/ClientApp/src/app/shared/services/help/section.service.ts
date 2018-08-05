import { HttpClient } from '@angular/common/http';
import { Section } from "../../../models/help/section";
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })

export class SectionService {

  private service = 'SectionService';

  constructor(private http: HttpClient) {
    
  }

  getList() {
    return this.http.get<Section[]>(`api/${this.service}/List`)
      .map((response) => response);
  }

}
