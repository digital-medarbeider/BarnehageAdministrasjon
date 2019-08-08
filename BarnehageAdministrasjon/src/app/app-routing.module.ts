import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


//const routes: Routes = [];
const routes: Routes = [
  {
    path: 'parents',
    loadChildren: () => import('./parents/parents.module').then(mod => mod.ParentsModule)
  },
  {
    path: '',
    redirectTo: 'parents',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
