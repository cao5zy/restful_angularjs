import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpModule } from '@angular/http';
import { HttpService, Service } from './services';
import { RouterModule, Routes } from '@angular/router';
import { MembersComponent } from './members/members.component';
import { RolesComponent } from './roles/roles.component';
import { AppConfig } from './appConfig';

const appRoutes: Routes = [
  { path: 'members', component: MembersComponent },
  { path: 'roles', component: RolesComponent},
  { path: '', redirectTo: '/members', pathMatch: "full"}
];

@NgModule({
  declarations: [
    AppComponent,
    MembersComponent,
    RolesComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    ModalModule.forRoot(),
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  bootstrap: [AppComponent],
  providers: [AppConfig, {provide: Service, useClass: HttpService}]
})
export class AppModule { }
