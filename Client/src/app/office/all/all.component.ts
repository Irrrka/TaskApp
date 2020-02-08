import { Component, OnInit } from '@angular/core';
import { OfficeService } from 'src/app/office.service';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {

  get offices() {return this.officeService.offices;}
  constructor(private officeService:OfficeService) { }

  ngOnInit() {
    this.officeService.getOffices();
  }

}
