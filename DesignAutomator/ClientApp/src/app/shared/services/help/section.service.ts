import { HttpClient } from '@angular/common/http';
import { Section } from "../../../models/help/section";
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })

export class SectionService {

  private service = 'SectionService';

  constructor(private http: HttpClient) {
    
  }

  getListWithQuestions() {
    return this.http.get<Section[]>(`api/${this.service}/list-with-questions`)
      .map((response) => response);
  }

  getList(index:number) {
    return this.http.get<Section[]>(`api/${this.service}/list/${index}`)
      .map((response) => response);
  }

  count() {
    return this.http.get<Section[]>(`api/${this.service}/count`)
      .map((response) => response);
    
  }
}
