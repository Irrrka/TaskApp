import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {


  myform: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.myform = this.fb.group({
      firstName : ['', [Validators.required, Validators.minLength(3)]],
      lastName : ['', [Validators.required, Validators.minLength(3)]],
      startingDate : ['', [Validators.required]],
      salary : ['', [Validators.required, Validators.min(500)]],
      vacationsDay : ['20', [Validators.required, Validators.min(20), Validators.max(250)]],
      //experienceLevel : ['', [Validators.required]],
      //company : ['', [Validators.nullValidator]],
    });
  };

  createEmployee() {
    console.log(this.myform);
  }

  get f(){
    return this.myform.controls;
  }
  get invalid(){
    return this.myform.invalid;
  }

}
