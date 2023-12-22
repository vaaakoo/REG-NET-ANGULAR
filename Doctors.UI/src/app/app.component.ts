import { Component } from '@angular/core';
import { doctor } from './models/doctor';
import { doctorService } from './services/doctor.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Doctor.UI';
  Doctores: doctor[] = [];
  DoctorToEdit?: doctor;

  constructor(private doctorService: doctorService) {}

  ngOnInit(): void {
    this.doctorService
      .getDoctores()
      .subscribe((result: doctor[]) => (this.Doctores = result));
  }

  updateDoctorList(Doctores: doctor[]) {
    this.Doctores = Doctores;
  }

  initNewDoctor() {
    this.DoctorToEdit = new doctor();
  }

  editDoctor(Doctor: doctor) {
    this.DoctorToEdit = Doctor;
  }
}
