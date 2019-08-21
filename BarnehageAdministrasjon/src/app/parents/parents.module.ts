import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParentsRoutingModule } from './parents-routing.module';
import { ParentMainComponent } from './parent-main/parent-main.component';
import { ParentChooseKingergartenComponent } from './parent-choose-kingergarten/parent-choose-kingergarten.component';
import { ParentBaseComponent } from './parent-base/parent-base.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { ChildListComponent } from './child-list/child-list.component';
import { ChildComponent } from './child/child.component';

@NgModule({
  declarations: [ParentMainComponent, ParentChooseKingergartenComponent, ParentBaseComponent, ChildListComponent, ChildComponent],
  imports: [
    CommonModule,
    ParentsRoutingModule,
    ReactiveFormsModule, FormsModule,
    MaterialModule
  ],
  exports: [
    MaterialModule
  ]
})
export class ParentsModule { }
