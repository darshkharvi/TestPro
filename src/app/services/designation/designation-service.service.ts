import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environment/environment';
import { DesignationModel } from 'src/app/models/designationModel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DesignationServiceService {
  baseURL: string = environment.backend.baseURL;
  private designationMethod = this.baseURL;

  constructor(private httpclient: HttpClient) { }

  public getAllDesignation(): Observable<DesignationModel[]> {
      return this.httpclient.get<DesignationModel[]>(this.designationMethod+"api/DesignationQuery/getalldesignations");
  }

  public addDesignation(designation: DesignationModel): Observable<DesignationModel> {
    return this.httpclient.post<DesignationModel>(this.designationMethod+"api/DesignationCommand/adddesignation",designation);
  }

}
