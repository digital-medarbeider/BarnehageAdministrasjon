import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ApplicationService } from '../shared/application.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SpecialRequirementService } from '../shared/special-requirement.service';

@Component({
  selector: 'app-parent-main',
  templateUrl: './parent-main.component.html',
  styleUrls: ['./parent-main.component.scss']
})
export class ParentMainComponent implements OnInit {
  applicationForm: FormGroup;
  application;
  selectedValue;
  isSpecReqSelected = false;
  languages = [
    { value: 1, viewValue: 'Norsk' },
    { value: 2, viewValue: 'English' },
  ];

  oddWeekDays = [{ day: 'M', dayDetail: 'Monday', isSeleted: false, value: 1 },
                 { day: 'T', dayDetail: 'Tuesday', isSeleted: false, value: 2 },
                 { day: 'O', dayDetail: 'Wednesday',isSeleted: false, value: 3 },
                 { day: 'T', dayDetail: 'Thursday',isSeleted: false, value: 4 },
                 { day: 'F', dayDetail: 'Friday',isSeleted: false, value: 5 }
  ];
  evenWeekDays = [{ day: 'M', dayDetail: 'Monday', isSeleted: false, value: 1 },
                  { day: 'T', dayDetail: 'Tuesday', isSeleted: false, value: 2 },
                  { day: 'O', dayDetail: 'Wednesday', isSeleted: false, value: 3 },
                  { day: 'T', dayDetail: 'Thursday', isSeleted: false, value: 4 },
                  { day: 'F', dayDetail: 'Friday', isSeleted: false, value: 5 }
  ];

  showKindergardens = false;
  toggleSelected = true;
  specialRequirements: any;
  oddDays = [];
  evenDays = [];
  oddDayLabel: string;
  evenDayLabel: string;

  constructor(private activateRouter: ActivatedRoute, private applicationService: ApplicationService, private fb: FormBuilder,
              private specReqsService: SpecialRequirementService) {
    this.applicationForm = new FormGroup({
      applicationId: new FormControl(),
      firstLanguage: new FormControl(),
      levelOfSpoken: new FormControl(),
      childName: new FormControl(),
      childAddress: new FormControl(),
      fatherName: new FormControl(),
      motherName: new FormControl(),
      reducedFee: new FormControl(),
      kindergartenDays: new FormControl()
    });}

  ngOnInit() {
    const applicationId = history.state.applicationId;

    this.activateRouter.queryParams.subscribe(params => {
    this.applicationService.getApplication(applicationId)
        .subscribe((data) => {
          console.log(data);
          this.application = data;
          this.setApplicationForm();
          this.getAppSpecRequirementsData();
        },
          error => {
            console.log(error);
          },
          () => {
            console.log('no errors');
          });
    this.showKindergardens = false;
    });
  }

  getAppSpecRequirementsData() {
    this.specReqsService.getSpecialRequirements()
    .subscribe((data) => {
      console.log(data);
      this.specialRequirements = data;
      this.setAppSpecialRequirements();
      this.setOddWeekKindergartenCoverages();
      this.setEvenWeekKindergartenCoverages();
    },
      error => {
        console.log(error);
      },
      () => {
        console.log('no errors');
      });
  }

  setOddWeekKindergartenCoverages() {
    this.oddWeekDays.forEach(o => {
      o.isSeleted = false;
      this.application.applicationKindergartenCoverages.forEach(ak => {
        if (ak.weekType === 'Odd' && o.value === ak.weekId ) {
          o.isSeleted = true;
          this.count++;
          this.oddDays.push(o.dayDetail);
          //this.dayOddLabel += o.dayDetail +  ', ';
        }
      });
    });
    this.createOddLabel();
  }

  setEvenWeekKindergartenCoverages() {
    this.evenWeekDays.forEach(o => {
      o.isSeleted = false;
      this.application.applicationKindergartenCoverages.forEach(ak => {
        if (ak.weekType === 'Even' &&  o.value === ak.weekId) {
          o.isSeleted = true;
          this.count++;
          this.evenDays.push(o.dayDetail);
         // this.dayEvenLabel += o.dayDetail + ', ';
        }
      });
    });
    this.createEvenLabel();
  }

  setAppSpecialRequirements() {
    this.specialRequirements.forEach(s => {
      s.isSelected = false;
      this.application.applicationSpecRequirements.forEach(element => {
        if (s.specialRequirementId === element.specialRequirementId) {
          s.isSelected = true;
        }
      });
    });
  }

  getLanguageByName(name) {
    return this.languages.filter(obj => {
      return obj.viewValue === name;
    });
  }

  getLanguageByValue(value) {
    return this.languages.filter(obj => {
      return obj.value === value;
    });
  }

  setApplicationForm() {
    const firstLanguageValue = this.getLanguageByName(this.application.child.firstLanguage)[0].value + '';

    this.applicationForm = this.fb.group({
      applicationId: this.application.applicationId,
      firstLanguage: firstLanguageValue,
      levelOfSpoken: this.application.child.levelOfSpoken,
      reducedFee: this.application.isReducedFee,
      childName: this.application.childName,
      childAddress: this.application.childAddress,
      fatherName: this.application.fatherName,
      motherName: this.application.motherName,
      kindergartenDays: this.application.isChooseDiffDays,
    });
    this.selectedLanguage(firstLanguageValue);
    this.isSelectedEvenDays = this.application.isChooseDiffDays;
    // this.createDefaultCount();
  }

  createDefaultCount(): any {
    if (this.application.isChooseDiffDays) {
      this.count = this.application.kindergartenCoverage / 10;
    }
    else {
      this.count = this.application.kindergartenCoverage / 20;
    }
  }

  getLanguages() {
    //from http
  }

  isVisible = false;
  selectedLanguage(value) {
    if (value === "1") {
      this.isVisible = false;
    }
    else {
      this.isVisible = true;
    }
  }
  count = 0;
  OddCalcCoverage(d) {
    if (this.showKindergardens) {
      return;
    }
    this.oddWeekDays.forEach(m => {
      if (m.value === d.value) {
        m.isSeleted = !d.isSeleted;
        this.count += m.isSeleted ? 1 : -1;
        this.addRemoveOddDayItem(m);
      }

    });
    this.CalculateKindergartenCoverage();
    this.createOddLabel();
  }
  EvenCalcCoverage(d) {
    if (this.showKindergardens) {
      return;
    }
    // let count = 0;
    this.evenWeekDays.forEach(m => {
      if (m.value === d.value) {
        m.isSeleted = !d.isSeleted;
        this.count += m.isSeleted ? 1 : -1;
        this.addRemoveEvenDayItem(m);
      }
    });
    this.CalculateKindergartenCoverage();
    this.createEvenLabel();
  }

  addRemoveEvenDayItem(m) {
    if (m.isSeleted) {
      this.evenDays.push(m.dayDetail);
    }
    else {
      this.evenDays.splice(this.oddDays.indexOf(m), 1);
    }
  }

  addRemoveOddDayItem(m) {
    if (m.isSeleted) {
      this.oddDays.push(m.dayDetail);
    }
    else {
      this.oddDays.splice(this.oddDays.indexOf(m), 1);
    }
  }

  CalculateKindergartenCoverage() {
    if (this.isSelectedEvenDays) {
      this.application.kindergartenCoverage = this.count * 10;
    }
    else {
      this.application.kindergartenCoverage = this.count * 20;
    }
  }

  isSelectedEvenDays = false;
  onDaysButtonGroupClick($event) {
    console.log(this.applicationForm.controls.kindergartenDays.value);
    let clickedElement = $event.target || $event.srcElement;
    if (clickedElement.nodeName === "LABEL") {
      if (clickedElement.control.defaultValue === "true") {
        this.isSelectedEvenDays = true;
        }
        else {
          this.isSelectedEvenDays = false;
      }
      this.setEvenKindergartenDaysDefaultValues();
      this.CalculateKindergartenCoverage();
    }
  }
    setEvenKindergartenDaysDefaultValues(): any {
      if (!this.isSelectedEvenDays) {
        this.evenWeekDays.forEach(e => {
          if (e.isSeleted) {
            e.isSeleted = false;
            this.count--;
            this.evenWeekDays.splice(this.evenWeekDays.indexOf(e), 1);
          }
        });
        this.createEvenLabel();
      }
  }

  createOddLabel() {
    this.oddDayLabel = this.oddDays.join(',');
    //this.oddDays.forEach(o => {
    //  this.oddDayLabel += o + ',';
    //});
  }
  createEvenLabel() {
    this.evenDayLabel = this.evenDays.join(',');
    //this.evenDays.forEach(o => {
    //  this.evenDayLabel += o + ',';
    //});
  }
}
