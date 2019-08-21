import { Injectable } from '@angular/core';
import { Application } from './application.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
    //return this.httpClient.get(this.myAppUrl + "api/Applications/" + id, { responseType: 'text' })
    //  .map((res: Response) => res.json())
    //  .catch(this._errorHandler); 
  }
  // https://localhost:44366/api/Applications/GetApplicationsByParent/22222222222
  getApplicationsByParent(nationalId: string) {
    return this.httpClient.get(this.myAppUrl + "api/Applications/GetApplicationsByParent/" + nationalId);
  }

  _errorHandler(error: Response) {
    console.error(error);
    return Observable.throw(error || "Server Error");
  }
}
