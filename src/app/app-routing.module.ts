import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './modules/department/department.component';
import { DesignationComponent } from './modules/designation/designation.component';

const routes: Routes = [
  {path: 'departments', component: DepartmentComponent},
  {path: 'designations', component: DesignationComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
