import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { doctor } from '../models/doctor';
import { doctorService } from '../services/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class doctorComponent implements OnInit {
  @Input() doctor?: doctor;
  @Output() doctoresUpdated = new EventEmitter<doctor[]>();

  constructor(private doctorService: doctorService) {}

  ngOnInit(): void {}

  updatedoctor(doctor: doctor) {
    this.doctorService
      .updatedoctor(doctor)
      .subscribe((doctores: doctor[]) => this.doctoresUpdated.emit(doctores));
  }

  deletedoctor(doctor: doctor) {
    this.doctorService
      .deletedoctor(doctor)
      .subscribe((doctores: doctor[]) => this.doctoresUpdated.emit(doctores));
  }

  createdoctor(doctor: doctor) {
    this.doctorService
      .createdoctor(doctor)
      .subscribe((doctores: doctor[]) => this.doctoresUpdated.emit(doctores));
  }
}
