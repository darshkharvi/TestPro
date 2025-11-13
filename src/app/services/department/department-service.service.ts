import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environment/environment';
import { departmentModel } from 'src/app/models/departmentModel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DepartmentServiceService {

  baseURL: string = environment.backend.baseURL;
  private departmentMethod = this.baseURL;

  constructor(private httpclient: HttpClient) { }

  public addDepartment(department: departmentModel): Observable<departmentModel> {
    return this.httpclient.post<departmentModel>(this.departmentMethod+"api/DepartmentCommand/adddepartment",department);
  }

  public getAllDepartment(): Observable<departmentModel[]> {
    return this.httpclient.get<departmentModel[]>(this.departmentMethod+"getalldepartment");
  }
  
}
