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

    this.designationService.addDesignation(newDesignation).subscribe({
      next: (addedDesignation) => {
        console.log('Added:', addedDesignation);
        this.designations.push(addedDesignation); 
        this.designationForm.reset();
      },
      error: (err) => {
        console.error('Error adding designation:', err);
      }
    });
  } else {
    this.designationForm.markAllAsTouched();
  }
}

}
