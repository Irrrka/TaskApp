import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from '../../src/app/models/company';

const createCendpoint = "https://localhost:44306/api/companies";
const getCendpoint = "https://localhost:44306/api/companies";
const getSingleCendpoint = "https://localhost:44306/api/companies/";

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  companies: Company[];
  selectedCompany: Company;
  constructor(private http: HttpClient) { }

  createCompany(data){
    return this.http.post(createCendpoint, data);
  }

  getCompanies(){
    this.http.get<Company[]>(getCendpoint).subscribe(companies=>{
      this.companies = companies;
    });
  }

  getCompany(id){
    //console.log(getSingleCendpoint+id);
    this.http.get<Company>(getSingleCendpoint+id).subscribe(company=>{
    this.selectedCompany = company;
    });
  }

  deleteCompany(id){
    return this.http.delete(getSingleCendpoint+id);
  }

  editCompany(id, data){
    return this.http.put(getSingleCendpoint+id, data);
  }

}
