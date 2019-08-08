import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  values: any = [];
  authentication = true;
  isExpandedParent: boolean;
 // @ViewChild('sidenav', { static: false }) sidenav: ElementRef;
  constructor(private http: HttpClient) { }
    ngOnInit(): void {
      this.http.get<String>('/api/values').subscribe(result => {
        this.values = result;
      }, error => console.error(error));
  }

  getMessage(message: boolean) {
    this.isExpandedParent = message;
  }
  title = 'BarnehageAdministrasjon';
}
