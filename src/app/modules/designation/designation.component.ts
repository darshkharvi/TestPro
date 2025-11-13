import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DesignationModel } from 'src/app/models/designationModel';
import { DesignationServiceService } from 'src/app/services/designation/designation-service.service';

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
    private designationService: DesignationServiceService,
  ) {}
 
  ngOnInit(): void {
    this.designationForm = this.fb.group({
      title: ['', Validators.required],
      description: ['']
    });
    this.designationService.getAllDesignation().subscribe(d => {
      this.designations = d;
    });
  }
 
  onSubmit(): void {
    if (this.designationForm.valid) {
      const newDesignation: DesignationModel = this.designationForm.value; 
      console.log('Form Data:', this.designationForm.value);
      this.designationForm.reset();
    } else {
      this.designationForm.markAllAsTouched();
    }
  }
}
