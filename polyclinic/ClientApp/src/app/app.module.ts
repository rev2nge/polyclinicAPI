import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CityComponent } from './city/list-city/city.component';
import { SpecializationComponent } from './specialization/list-specialization/specialization.component';
import { MedicComponent } from './medic/list-medic/medic.component';
import { PolyclinicComponent } from './polyclinic/list-polyclinic/polyclinic.component';
import { CreateCityComponent } from './city/create-city/create-city.component';
import { UpdateCityComponent } from './city/update-city/update-city.component';
import { DeleteCityComponent } from './city/delete-city/delete-city.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { DetailsMedicComponent } from './medic/details-medic/details-medic.component';
import { CreateMedicComponent } from './medic/create-medic/create-medic.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { DeleteMedicComponent } from './medic/delete-medic/delete-medic.component';
import { UpdateMedicComponent } from './medic/update-medic/update-medic.component';
import { DetailsPolyclinicComponent } from './polyclinic/details-polyclinic/details-polyclinic.component';
import { CreatePolyclinicComponent } from './polyclinic/create-polyclinic/create-polyclinic.component';
import { UpdatePolyclinicComponent } from './polyclinic/update-polyclinic/update-polyclinic.component';
import { DeletePolyclinicComponent } from './polyclinic/delete-polyclinic/delete-polyclinic.component';
import { UpdateSpecializationComponent } from './specialization/update-specialization/update-specialization.component';
import { DeleteSpecializationsComponent } from './specialization/delete-specialization/delete-specialization.component';
import { CreateSpecializationComponent } from './specialization/create-specialization/create-specialization.component';
import { CityService } from './services/city.service';
/*import { HttpErrorInterceptorService } from './services/httperor-interceptor.service';*/
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

const appRoutes: Routes = [
  /*  { path: "**", component: CityComponent },*/
  { path: 'city', component: CityComponent },
  { path: 'create-city', component: CreateCityComponent },
  { path: 'update-city', component: UpdateCityComponent },
  { path: 'delete-city', component: DeleteCityComponent },

  { path: 'medic', component: MedicComponent },
  { path: 'details-medic/:id', component: DetailsMedicComponent },
  { path: 'create-medic', component: CreateMedicComponent },
  { path: 'update-medic', component: UpdateMedicComponent },
  { path: 'delete-medic', component: DeleteMedicComponent },

  { path: 'polyclinic', component: PolyclinicComponent },
  { path: 'details-polyclinic/:id', component: DetailsPolyclinicComponent },
  { path: 'create-polyclinic', component: CreatePolyclinicComponent },
  { path: 'update-polyclinic', component: UpdatePolyclinicComponent },
  { path: 'delete-polyclinic', component: DeletePolyclinicComponent },

  { path: 'specialization', component: SpecializationComponent },
  { path: 'create-specialization', component: CreateSpecializationComponent },
  { path: 'update-specialization', component: UpdateSpecializationComponent },
  { path: 'delete-specialization', component: DeleteSpecializationsComponent },

  { path: 'user/login', component: UserLoginComponent },
  { path: 'user/register', component: UserRegisterComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,

    CityComponent,
    CreateCityComponent,
    UpdateCityComponent,
    DeleteCityComponent,

    MedicComponent,
    DetailsMedicComponent,
    CreateMedicComponent,
    UpdateMedicComponent,
    DeleteMedicComponent,

    PolyclinicComponent,
    DetailsPolyclinicComponent,
    CreatePolyclinicComponent,
    UpdatePolyclinicComponent,
    DeletePolyclinicComponent,

    SpecializationComponent,
    CreateSpecializationComponent,
    UpdateSpecializationComponent,
    DeleteSpecializationsComponent,

    UserLoginComponent,
    UserRegisterComponent,
   ],
  imports: [
    BrowserModule,
    //BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    //BrowserAnimationsModule,
    //BsDropdownModule.forRoot()
  ],
  providers: [
    //{
    //  provide: HTTP_INTERCEPTORS,
    //  useClass: HttpErrorInterceptorService,
    //  multi: true
    //},
    AlertifyService,
    AuthService,
    CityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
