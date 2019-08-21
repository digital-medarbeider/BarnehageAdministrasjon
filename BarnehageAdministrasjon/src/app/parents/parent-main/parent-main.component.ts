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

  oddWeekDays = [{ day: 'M', isSeleted: false, value: 1 },
                 { day: 'T', isSeleted: false, value: 2 },
                 { day: 'O', isSeleted: false, value: 3 },
                 { day: 'T', isSeleted: false, value: 4 },
                 { day: 'F', isSeleted: false, value: 5 }
  ];
  evenWeekDays = [{ day: 'M', isSeleted: false, value: 1 },
                  { day: 'T', isSeleted: false, value: 2 },
                  { day: 'O', isSeleted: false, value: 3 },
                  { day: 'T', isSeleted: false, value: 4 },
                  { day: 'F', isSeleted: false, value: 5 }
  ];

  showKindergardens = false;
  toggleSelected = true;
  specialRequirements: any;

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
        }
      });
    });

  }

  setEvenWeekKindergartenCoverages() {
    this.evenWeekDays.forEach(o => {
      o.isSeleted = false;
      this.application.applicationKindergartenCoverages.forEach(ak => {
        if (ak.weekType === 'Even' &&  o.value === ak.weekId) {
          o.isSeleted = true;
        }
      });
    });

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
  OddCalcCoverage(d) {
    if (this.showKindergardens) {
      return;
    }
    let count = 0;
    this.oddWeekDays.forEach(m => {
      if (m.value === d.value) {
        m.isSeleted = !d.isSeleted;
      }
      count += m.isSeleted ? 1 : 0;
    });
    // this.kindergardenCoverage = count * 20 + '%';
  }
  EvenCalcCoverage(d) {
    if (this.showKindergardens) {
      return;
    }
    let count = 0;
    this.evenWeekDays.forEach(m => {
      if (m.value === d.value) {
        m.isSeleted = !d.isSeleted;
      }
      count += m.isSeleted ? 1 : 0;
    });
    // this.kindergardenCoverage = count * 20 + '%';
  }

  isSelectedEvenDays = false;
  onDaysButtonGroupClick($event) {
    console.log(this.applicationForm.controls.kindergartenDays.value);
    let clickedElement = $event.target || $event.srcElement;
    if (clickedElement.nodeName === "LABEL") {
      if (clickedElement.control.defaultValue === "true") {
        this.isSelectedEvenDays = true;
        // this.setEvenKindergartenDaysDefaultValues();
        }
        else {
          this.isSelectedEvenDays = false;
        }
    }
  }
    setEvenKindergartenDaysDefaultValues(): any {
      if (!this.application.isChooseDiffDays) {
        this.evenWeekDays.forEach(e => {
          e.isSeleted = true;
        })
      }
    }
}
