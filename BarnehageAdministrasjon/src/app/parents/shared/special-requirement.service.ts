import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SpecialRequirementService {
  myAppUrl = 'https://localhost:44366/';
  constructor(private httpClient: HttpClient) { }

  getSpecialRequirements() {
    return this.httpClient.get(this.myAppUrl + "api/SpecialRequirements");
  }

}
