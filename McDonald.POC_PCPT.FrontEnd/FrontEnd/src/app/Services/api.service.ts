import { Injectable, Inject } from '@angular/core';
import {RequestOptions, Request, RequestMethod} from '@angular/http';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable()
export class ApiService {

  // get base api URL from enviroment variable
  API_URL_Main = environment.APIUrl_Main;
  DropDownsURL = environment.APIUrl_DropDowns;
  constructor(public http: HttpClient){}


  // Post data to DB through Http post
  public Post(object: any) {
    // create header
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    // create request option
   const options = {
    headers: headers
    };
    return this.http.post<object>(`${this.API_URL_Main}`, object, options);

  }


  // Get table data through API
  public GetAll() {
     // create header
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    // create request option
    const options = {
    headers: headers
    };
    return this.http.get(`${this.API_URL_Main}`, options);
  }

  // Get dropdown data from db through API
  public GetDropDowns() {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

   const options = {
    headers: headers
  };
    return this.http.get(`${this.DropDownsURL}`, options);
  }

}
