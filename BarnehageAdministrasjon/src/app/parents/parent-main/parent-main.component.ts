import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ApplicationService } from '../shared/application.service';

@Component({
  selector: 'app-parent-main',
  templateUrl: './parent-main.component.html',
  styleUrls: ['./parent-main.component.scss']
})
export class ParentMainComponent implements OnInit {
  applicationForm: FormGroup;
  application;
  languages = [
    { value: 1, viewValue: 'Norsk' },
    { value: 2, viewValue: 'English' },
  ];
  isVisible = false;

  constructor(private applicationService: ApplicationService, private fb: FormBuilder) {}

  ngOnInit() {
    this.applicationService.getApplication('8000000A-0000-F400-B63F-84710C7967BB')
      .subscribe((data) => {
        console.log(data);
        this.application = data;
        this.setApplicationForm();
      });
  }

  setApplicationForm() {
    this.applicationForm = this.fb.group({
      applicationId: this.application.applicationId,
      childName: this.application.childName,
      childAddress: this.application.childAddress,
      fatherName: this.application.fatherName,
      motherName: this.application.motherName,
      languageId: 'Norsk',
      levelOfLanguage: ''
    });

  }

  getLanguages() {
    //from http
  }

  selected(event) {
    this.isVisible = event.value === 1 ? false : true;
  }

}
