import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../company.service';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  get selectedCompany() { return this.companyService.selectedCompany;}

  constructor(private companyService:CompanyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(data => {
      let id = data['id'];
      this.companyService.getCompany(id);
    })
  }

  deleteCompany(id){
    this.companyService.deleteCompany(id).subscribe(data => {
      this.companyService.getCompanies();
    })
  }

}
