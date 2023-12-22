import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { doctor } from '../models/doctor';

@Injectable({
  providedIn: 'root',
})
export class doctorService {
  private url = 'Doctors';

  constructor(private http: HttpClient) {}

  public getDoctores(): Observable<doctor[]> {
    return this.http.get<doctor[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updatedoctor(Doctor: doctor): Observable<doctor[]> {
    return this.http.put<doctor[]>(
      `${environment.apiUrl}/${this.url}`,
      Doctor
    );
  }

  public createdoctor(Doctor: doctor): Observable<doctor[]> {
    return this.http.post<doctor[]>(
      `${environment.apiUrl}/${this.url}`,
      Doctor
    );
  }

  public deletedoctor(Doctor: doctor): Observable<doctor[]> {
    return this.http.delete<doctor[]>(
      `${environment.apiUrl}/${this.url}/${Doctor.id}`
    );
  }
}
