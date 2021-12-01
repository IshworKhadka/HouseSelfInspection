import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { HouseComponent } from './house/house.component';

const appRoutes: Routes = [
  {
    path: 'dashboard', component: HeaderComponent,
    children: [
      {path: 'home', component: HomeComponent},
      {path: 'about', component: AboutComponent},
    ]
  },
  {
    path: 'house', component: HouseComponent,
    children: [
      {path: 'add-house', component: HomeComponent},
      {path: 'view-all', component: AboutComponent},
    ]
  },
  {
    path: 'login', component:  LoginComponent
  },
  {
    path: '**', redirectTo: '/login', pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    HomeComponent,
    AboutComponent,
    HouseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
