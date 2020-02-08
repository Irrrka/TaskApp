import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CompanyService } from 'src/app/company.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  myform: FormGroup;
  constructor(private fb: FormBuilder, private companyService: CompanyService, private router: Router) {}

  ngOnInit() {
    this.myform = this.fb.group({
      name : ['', [Validators.required, Validators.minLength(3)]],
      creationDate : ['', [Validators.required]],
      //office : ['', [Validators.nullValidator]],
      //employee : ['', [Validators.nullValidator]],
    });
  };

  createCompany() {
    this.companyService.createCompany(this.myform.value).subscribe((data)=>{
      this.router.navigate(['/companies'])
    });
  }

  get f(){
    return this.myform.controls;
  }
}
