import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentBaseComponent } from './parent-base/parent-base.component';


const routes: Routes = [
  {
    path: '',
    component: ParentBaseComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsRoutingModule { }
