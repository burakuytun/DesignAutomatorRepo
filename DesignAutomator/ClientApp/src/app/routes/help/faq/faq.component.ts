import { Component, OnInit } from '@angular/core';
import { SectionService } from "../../../shared/services/help/section.service";
import { Section } from "../../../models/help/section";

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FaqComponent implements OnInit {

  oneAtATime=true;
  sections: Section[];

  constructor(private sectionService: SectionService) {}

  ngOnInit() {
    this.sectionService.getListWithQuestions().subscribe(result => {
      this.sections = <Section[]>(result);
    });
  }
}
