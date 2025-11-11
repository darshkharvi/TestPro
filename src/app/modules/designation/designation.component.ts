import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DesignationModel } from 'src/app/models/designationModel';

@Component({
  selector: 'app-designation',
  templateUrl: './designation.component.html',
  styleUrls: ['./designation.component.css']
})
export class DesignationComponent implements OnInit {
 
  designationForm!: FormGroup;
  designations: DesignationModel[] = [];
 
  constructor(
    private fb: FormBuilder,
    // private designationService: DesignationService
  ) {}
 
  ngOnInit(): void {
    this.designationForm = this.fb.group({
      title: ['', Validators.required],
      description: ['']
    });
 
    // Load existing designations
    // this.designations = this.designationService.getDesignations();
  }
 
  onSubmit(): void {
    if (this.designationForm.valid) {
      const newDesignation: DesignationModel = this.designationForm.value;
      // this.designationService.addDesignation(newDesignation);
      // this.designations = this.designationService.getDesignations();
 
      console.log('Form Data:', this.designationForm.value);
      this.designationForm.reset();
    } else {
      this.designationForm.markAllAsTouched();
    }
  }
}
