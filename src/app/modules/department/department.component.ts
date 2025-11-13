import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { departmentModel } from 'src/app/models/departmentModel';
import { DepartmentServiceService } from 'src/app/services/department/department-service.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  departments:departmentModel[] = [];
  departmentForm!: FormGroup;

constructor(
    private fb: FormBuilder,
    private departmentService: DepartmentServiceService,
  ) {}
 
  ngOnInit(): void {
    this.departmentForm = this.fb.group({
      title: ['', Validators.required],
    });
    this.departmentService.getAllDepartment().subscribe(d => {
      this.departments = d;
    });
  }
 
  onSubmit(): void {
    if (this.departmentForm.valid) {
      const newDesignation: departmentModel = this.departmentForm.value;
      console.log('Form Data:', this.departmentForm.value);
      this.departmentForm.reset();
    } else {
      this.departmentForm.markAllAsTouched();
    }
}
}