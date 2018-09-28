import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { GeneralCompComponent } from './general-comp/general-comp.component';
import { KitchenCompComponent } from './kitchen-comp/kitchen-comp.component';
import { DrivethruCompComponent } from './drivethru-comp/drivethru-comp.component';
import { FrontcounterCompComponent } from './frontcounter-comp/frontcounter-comp.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MainCompComponent } from './main-comp/main-comp.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule} from '@angular/material';
import {MatSelectModule} from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import {ApiService} from './Services/api.service';
import {MatTableModule} from '@angular/material/table';
import { ToastrModule } from 'ng6-toastr-notifications';




@NgModule({
  declarations: [
    AppComponent,
    GeneralCompComponent,
    KitchenCompComponent,
    DrivethruCompComponent,
    FrontcounterCompComponent,
    MainCompComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    NgbModule.forRoot(),
    ReactiveFormsModule,
    MatButtonModule, MatCheckboxModule,
    MatSelectModule,
    HttpClientModule,
    MatTableModule,
    ToastrModule.forRoot()


  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
