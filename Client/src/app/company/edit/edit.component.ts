import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { CompanyService } from 'src/app/company.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  myform: FormGroup;
  
  constructor(
    private fb: FormBuilder, 
    private companyService: CompanyService, 
    private router: Router) {}

  ngOnInit() {
    console.log(this.myform)
    this.myform = this.fb.group({
      name : ['', [Validators.required, Validators.minLength(3)]],
      creationDate : [this.myform.get('creationDate'), [Validators.required]],
      //office : ['', [Validators.nullValidator]],
      //employee : ['', [Validators.nullValidator]],
    });
  };

  editCompany(id) {
    this.companyService.editCompany(id, this.myform.value).subscribe((data)=>{
      this.router.navigate([`/companies/${id}`])
    });
  }

  get f(){
    return this.myform.controls;
  }
}
