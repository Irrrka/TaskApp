import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent as CompanyCreateComponent} from './company/create/create.component';
import { CreateComponent as EmployeeCreateComponent} from './employee/create/create.component';
import { AllComponent as CompanyAllComponent} from './company/all/all.component';
import { AllComponent as OfficeAllComponent} from './office/all/all.component';
import { CompanyComponent } from './company/company/company.component';
import { EditComponent } from './company/edit/edit.component';


const routes: Routes = [
  {path:'', pathMatch:'full', redirectTo:'companies'},
  {path:'companies', component:CompanyAllComponent},
  {path:'offices', component:OfficeAllComponent},
  {path:'companies/create', component:CompanyCreateComponent},
  {path:'companies/details/:id', component:CompanyComponent},
  {path:'companies/edit/:id', component:EditComponent},
  {path:'employees/create', component:EmployeeCreateComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
