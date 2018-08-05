import { Component, OnInit } from '@angular/core';
import { SectionService } from "../../../shared/services/help/section.service";
import { Section } from "../../../models/help/section";

@Component({
  selector: 'app-faqadmin',
  templateUrl: './faqadmin.component.html',
  styleUrls: ['./faqadmin.component.scss']
})
export class FaqAdminComponent implements OnInit {

  sections: Section[];
  count: number;
  
  constructor(private sectionService: SectionService) {
    this.count = 0;
  }

  ngOnInit() {
    this.sectionService.count().subscribe(result => {
      this.count = ((result) as any).count;
    });
    this.sectionService.getList(0).subscribe(result => {
      this.sections = <Section[]>(result);
    });
  }

  pageChanged(currentPage: number): void {
    this.sectionService.getList(currentPage).subscribe(result => {
      this.sections = <Section[]>(result);
    });
  }

  newQuestion() {
    
  }

}
