import { Injectable } from '@angular/core';
import { Office } from './models/office';
import { HttpClient } from '@angular/common/http';


const createOendpoint = "https://localhost:44306/api/offices";
const getOendpoint = "https://localhost:44306/api/offices";

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  offices: Office[];
  constructor(private http: HttpClient) { }

  getOffices(){
    this.http.get<Office[]>(getOendpoint).subscribe(offices=>{
      this.offices = offices;
    });
  }
}
