import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { AuthGuard } from './guards/auth.guard';
import { CanDeactiveGuard } from './guards/can-deactive.guard';
import { HomeComponent } from './home/home.component';
import { ComponentDetailsComponent } from './return-order/component-details/component-details.component';
import { ProcessingChargeDetailsComponent } from './return-order/processing-charge-details/processing-charge-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'component-details', component: ComponentDetailsComponent, canDeactivate: [CanDeactiveGuard] },
      { path: 'processing-charge-details', component: ProcessingChargeDetailsComponent }
    ]
  },
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
