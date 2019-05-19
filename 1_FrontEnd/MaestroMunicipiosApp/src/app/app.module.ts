import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartamentoComponent } from './departamento/departamento.component';
import { MunicipioComponent } from './municipio/municipio.component';
import { NavbarComponent } from './navbar/navbar.component';

import {MunicipioService} from './services/municipio.service';
import {DepartamentoService} from './services/departamento.service';

@NgModule({
  declarations: [
    AppComponent,
    MunicipioComponent,
    NavbarComponent,
    DepartamentoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    FormsModule,
    HttpModule,
  ],
  providers: [
    MunicipioService,
    DepartamentoService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
