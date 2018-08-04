import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FileUploader, FileUploaderOptions, FileItem, ParsedResponseHeaders } from "ng2-file-upload";
import { TokenService } from "../../services/token.service";

const URL = '/api/FileUploadService/upload';

@Component({
  selector: 'app-customfileupload',
  templateUrl: './customfileupload.component.html',
  styleUrls: ['./customfileupload.component.scss']
})
export class CustomFileUploadComponent implements OnInit {
  @Input() allowedFile: Array<{ extension: string, count: number }> = new Array<{ extension: string, count: number }>();
  @Output() uploadedFileChanged = new EventEmitter();

  uploadedFiles: Array<string> = new Array<string>();
  isProcessEnabled: boolean;

  public uploader: FileUploader = new FileUploader(
    {
      url: URL,
      filters: [{
        name: 'daExtension',
        fn: (item: any): boolean => {
          let fileExt = item.name.slice(item.name.lastIndexOf('.') + 1).toLowerCase();
          return this.allowedFile.map(x => x.extension).includes(fileExt)
            &&
            this.allowedFile.filter(p => p.extension === fileExt).map(x => x.count)[0] >
            this.uploader.queue.filter(p => p.file.name.includes(`.${fileExt}`)).length;
        }
      }],
      //,allowedMimeType: ["text/auto", "text/xml", "application/acad", "text/x-swift"],
      headers: [
        { name: "X-XSRF-TOKEN", value: this.getCookie("XSRF-TOKEN") },
        { name: "Accept", value: "application/json" },
        { name: 'Authorization', value: `Bearer ${this.tokenService.get()}` }
      ],
      maxFileSize: 10 * 1024 * 1024,
      removeAfterUpload: false
    });


  public hasBaseDropZoneOver: boolean = false;

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  dropped(e: any) {
  }

  constructor(private tokenService: TokenService) {
    const authHeader: Array<{
      name: string;
      value: string;
    }> = [];
    authHeader.push({ name: 'Authorization', value: 'Bearer ' + tokenService.get() });

    const uploadOptions = <FileUploaderOptions>{ headers: authHeader };
    this.uploader.setOptions(uploadOptions);
  }

  onSuccessItem(item: FileItem, response: string, status: number, headers: ParsedResponseHeaders): any {
    if (status === 200) {
      this.uploadedFiles.push(`${response}`);
      this.addNewUploadedFile(item);
    }
  }


  ngOnInit() {
    this.uploader.onSuccessItem = (item, response, status, headers) => this.onSuccessItem(item, response, status, headers);
  }

  //do we really need this???
  getCookie(name: string): string {
    const value = "; " + document.cookie;
    const parts = value.split("; " + name + "=");
    if (parts.length === 2) {
      const lastItem = parts.pop();
      if (lastItem) {
        const uri = lastItem.split(";").shift();
        if (uri) {
          return decodeURIComponent(uri);
        }
      }
    }
    return "";
  }

  addNewUploadedFile(file) {
    this.uploadedFileChanged.emit(this.uploadedFiles);
    console.log(this.uploadedFiles);
  }

  clearFiles() {
    this.uploader.clearQueue();

    //we need to delete files from server before emptying file list
    //emrah this kisses your hands
    this.uploadedFiles = [];
    this.uploadedFileChanged.emit(this.uploadedFiles);

    console.log(this.uploadedFiles);
  }
}
