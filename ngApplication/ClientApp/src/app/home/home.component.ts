import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../services/file-upload.service';
import { Result } from '../models/result';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  loading = false;
  textFile;
  fileData = new FormData();
  result: Result;
  DefaultStatus: string;
  status: string;
  maxFileSize: number;
  isValidFile = true;

  constructor(private fileUploadService: FileUploadService) {
    this.DefaultStatus = "Please upload a test file";
    this.status = this.DefaultStatus;
    this.maxFileSize = 4 * 1024 * 1024; // 4MB
  }

  uploadFile(event) {

    this.textFile = event.target.files[0];

    if (this.textFile.size > this.maxFileSize) {
      this.status = `The file size is ${this.textFile.size} bytes, this is more than the allowed limit of ${this.maxFileSize} bytes.`;
      this.isValidFile = false;
    }

  }

  GetCount() { 

      this.loading = true;
      this.fileData.append('textFile', this.textFile);

      this.fileUploadService.fileUpload(this.fileData).subscribe(
        (result: Result) => {

          this.result = result;         
            this.loading = false;
        });
    
  }

}
