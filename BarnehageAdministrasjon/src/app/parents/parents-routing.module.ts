import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentBaseComponent } from './parent-base/parent-base.component';
import { ChildListComponent } from './child-list/child-list.component';


const routes: Routes = [
  {
    path: '',
    component: ChildListComponent
  },
  {
    path: 'parentbase',
    component: ParentBaseComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsRoutingModule { }
