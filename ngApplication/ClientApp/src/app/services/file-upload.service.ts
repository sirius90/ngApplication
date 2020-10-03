import { Component, Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  baseURL: string;

  constructor(private http: HttpClient ) {
    this.baseURL = '/api/Upload';
  }


  fileUpload(file: FormData) {
    return this.http.post(this.baseURL, file)
      .pipe(response => {
        return response;
      });
  }
}
