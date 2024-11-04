import { HttpClient } from '@angular/common/http';
import { HospitalService } from './services/hospital.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Service } from '../models/service.model';
import { Observable } from 'rxjs';
import { Doctor } from '../models/doctor.model';
import { Patient } from '../models/patient.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // 'styleUrl' yerine 'styleUrls' olmalı
})
export class AppComponent {
  title = 'HospitalClientSide';
/*
  constructor(private router: Router) {}

  ngOnInit() {
    this.router.navigate(['/home']);
  }
*/
}


