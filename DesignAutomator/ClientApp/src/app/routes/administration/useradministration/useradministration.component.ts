import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as _ from 'lodash';
import { UserData } from './dummydata';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'app-useradministration',
  templateUrl: './useradministration.component.html',
  styleUrls: ['./useradministration.component.scss']
})
export class UserAdministrationComponent implements OnInit {

  // ng2Table
  public rows: Array<any> = [];

  public columns: Array<any> = [
    { title: 'Name', name: 'name', filtering: { filterString: '', placeholder: 'Filter by name' }, sort: 'asc' },
    { title: 'Active', name: 'active', sort: '' },
    { title: 'SQL Authentication', className: ['permission-header', 'text-success'], name: 'sqlauthentication', filtering: { filterString: '', placeholder: 'Filter by sqlauthentication' }, sort: '' },
    { title: 'Admin', className: ['admin-header', 'text-danger'], name: 'admin', sort: '' },
    { title: 'DNA Manager', className: ['dnamanager-header', 'text-danger'], name: 'dnamanager', sort: '' },
    { title: 'Locked (SQL)', name: 'sqllocked', sort: '' },
    { title: 'Locked Date', name: 'lockdateate', sort: '' },
    { title: 'Locked Date', name: 'lockdateate', sort: '' },
    { title: 'Actions', name: 'actions' },
  ];

  public page: number = 1;
  public itemsPerPage: number = 10;
  public maxSize: number = 5;
  public numPages: number = 1;
  public length: number = 0;

  constructor(public http: HttpClient, public ngxSmartModalService: NgxSmartModalService) {
    this.length = this.ng2TableData.length;
  }

  //configuration for the datatables
  public config: any = {
    paging: true,
    sorting: { columns: this.columns },
    filtering: { filterString: '' },
    className: ['table-striped', 'table-bordered', 'mb-0', 'd-table-fixed']
  };

  public ng2TableData: Array<any> = UserData.map(x => {
    x.actions = `<button class="btn btn-labeled btn-info mb-2" type="button" (click)="ngxSmartModalService.getModal('editUserModal').open()">
                  <span class="btn-label">
                    <i class="fa fa-edit"></i>
                  </span>Edit User
                </button>`;
    return x;
  });

  public ngOnInit(): void {
    this.onChangeTable(this.config);
  }

  public changePage(page: any, data: Array<any> = this.ng2TableData): Array<any> {
    let start = (page.page - 1) * page.itemsPerPage;
    let end = page.itemsPerPage > -1 ? (start + page.itemsPerPage) : data.length;
    return data.slice(start, end);
  }

  public changeSort(data: any, config: any): any {
    if (!config.sorting) {
      return data;
    }

    let columns = this.config.sorting.columns || [];
    let columnName: string = void 0;
    let sort: string = void 0;

    for (let i = 0; i < columns.length; i++) {
      if (columns[i].sort !== '' && columns[i].sort !== false) {
        columnName = columns[i].name;
        sort = columns[i].sort;
      }
    }

    if (!columnName) {
      return data;
    }

    // simple sorting
    return data.sort((previous: any, current: any) => {
      if (previous[columnName] > current[columnName]) {
        return sort === 'desc' ? -1 : 1;
      } else if (previous[columnName] < current[columnName]) {
        return sort === 'asc' ? -1 : 1;
      }
      return 0;
    });
  }

  public changeFilter(data: any, config: any): any {

    let filteredData: Array<any> = data;
    this.columns.forEach((column: any) => {
      if (column.filtering) {
        filteredData = filteredData.filter((item: any) => {
          if (item[column.name])
            return item[column.name].toString().toLowerCase().match(column.filtering.filterString.toLowerCase());
        });
      }
    });

    if (!config.filtering) {
      return filteredData;
    }

    if (config.filtering.columnName) {
      return filteredData.filter((item: any) =>
        item[config.filtering.columnName].toLowerCase().match(this.config.filtering.filterString.toLowerCase()));
    }

    let tempArray: Array<any> = [];
    filteredData.forEach((item: any) => {
      let flag = false;
      this.columns.forEach((column: any) => {
        if (item[column.name] && item[column.name].toString().toLowerCase().match(this.config.filtering.filterString.toLowerCase())) {
          flag = true;
        }
      });
      if (flag) {
        tempArray.push(item);
      }
    });
    filteredData = tempArray;

    return filteredData;
  }

  public onChangeTable(config: any, page: any = { page: this.page, itemsPerPage: this.itemsPerPage }): any {
    if (config.filtering) {
      (<any>Object).assign(this.config.filtering, config.filtering);
    }

    if (config.sorting) {
      (<any>Object).assign(this.config.sorting, config.sorting);
    }

    let filteredData = this.changeFilter(this.ng2TableData, this.config);
    let sortedData = this.changeSort(filteredData, this.config);
    this.rows = page && config.paging ? this.changePage(page, sortedData) : sortedData;
    this.length = sortedData.length;
  }

  public onCellClick(data: any): any {
    this.ngxSmartModalService.getModal('editUserModal').open();
  }

}
