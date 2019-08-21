import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationService } from '../shared/application.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-child-list',
  templateUrl: './child-list.component.html',
  styleUrls: ['./child-list.component.scss']
})
export class ChildListComponent implements OnInit {
  applications: any;
  constructor(private activateRouter: ActivatedRoute, private applicationService: ApplicationService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
   // this.activateRouter.queryParams.subscribe(params => {
      this.applicationService.getApplicationsByParent('22222222222')
        .subscribe((data) => {
          console.log(data);
          this.applications = data;
        },
          error => {
            console.log(error);
          },
          () => {
            console.log('no errors');
          });
   // });
  }

  gotoChild(application) {
    this.router.navigate(['parents/parentbase'],{ state: { applicationId: application.applicationId }});
  }

}
