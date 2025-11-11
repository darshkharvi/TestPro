import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { departmentModel } from 'src/app/models/departmentModel';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  departmentForm!: FormGroup;

constructor(
    private fb: FormBuilder,
    // private designationService: DesignationService
  ) {}
 
  ngOnInit(): void {
    this.departmentForm = this.fb.group({
      title: ['', Validators.required],
    });
 
    // Load existing designations
    // this.designations = this.designationService.getDesignations();
  }
 
  onSubmit(): void {
    if (this.departmentForm.valid) {
      const newDesignation: departmentModel = this.departmentForm.value;
      // this.designationService.addDesignation(newDesignation);
      // this.designations = this.designationService.getDesignations();
 
      console.log('Form Data:', this.departmentForm.value);
      this.departmentForm.reset();
    } else {
      this.departmentForm.markAllAsTouched();
    }
}
}