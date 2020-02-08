import { Component, OnInit } from '@angular/core';
import { Company } from '../../models/company';
import { CompanyService } from 'src/app/company.service';
import { Observable } from 'rxjs';
import { EmployeeExperienceLevel } from '../../models/EmployeeExperienceLevev'

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {

  get companies() {return this.companyService.companies;}
  get exp() {return EmployeeExperienceLevel}

  constructor(private companyService:CompanyService) { }

  ngOnInit() {
    this.companyService.getCompanies();
  }

}
