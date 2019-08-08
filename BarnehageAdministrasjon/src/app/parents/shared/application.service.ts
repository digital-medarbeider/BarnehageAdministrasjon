import { Injectable } from '@angular/core';
import { Application } from './application.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  myAppUrl = 'https://localhost:44366/';
  constructor(private httpClient: HttpClient) { }

  applicaton = {
    applicationId: '1234',
    childName: 'Arne Lillegutt',
    childAddress: 'Heieien 1, 1234 Fjell.',
    fatherName: 'Mrianne',
    motherName: 'Per'
  }

  getApplication(id: string) {
    return this.httpClient.get(this.myAppUrl + "api/Applications/" + id);
  }  
}
