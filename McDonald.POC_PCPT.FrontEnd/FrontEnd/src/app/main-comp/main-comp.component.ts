import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import {RequestOptions, Request, RequestMethod} from '@angular/http';
import { HttpHeaders } from '@angular/common/http';
import {ApiService} from '../Services/api.service';

import {MatPaginator, MatTableDataSource} from '@angular/material';
import {GeneralCompComponent} from '../general-comp/general-comp.component';
import {DrivethruCompComponent} from '../drivethru-comp/drivethru-comp.component';
import {FrontcounterCompComponent} from '../frontcounter-comp/frontcounter-comp.component';
import {KitchenCompComponent} from '../kitchen-comp/kitchen-comp.component';

import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-main-comp',
  templateUrl: './main-comp.component.html',
  styleUrls: ['./main-comp.component.css']
})
export class MainCompComponent implements AfterViewInit, OnInit {

  // Creates Object of Children conponents to access data
  @ViewChild(GeneralCompComponent) generalchild: GeneralCompComponent;
  @ViewChild(DrivethruCompComponent) drivethruchild: DrivethruCompComponent;
  @ViewChild(FrontcounterCompComponent) frontCounterchild: FrontcounterCompComponent;
  @ViewChild(KitchenCompComponent) kitchenchild: KitchenCompComponent;

 pocMain = {} as PocMain;
 dataSource: any;
 dropdowns: any[];

// define column names of table
 displayedColumns: string[] = ['country', 'dayPart', 'dayPartVersion', 'dTtype', 'dtRemoteOT',
 'drinkMode', 'servMode', 'fcRemoteOT', 'fcDrinkMode', 'operatingPlatform', 'archDispenser', 'fryerWall'];

  constructor(public http: HttpClient, public api: ApiService, public toastr: ToastrManager) {
  }
  ngOnInit() {

    // Load Data to table
    this.api.GetAll().subscribe(data => {
      this.dataSource = data;
    });

    // get data from single end point
    // and distribute to all child component
    this.DistributeDataToChildComp();


  }

  ngAfterViewInit() {
  }

  // success popup message
  showSuccess() {
    this.toastr.successToastr('You have successfully added data', 'Success!');
  }

  // error popup message
  showError() {
    this.toastr.errorToastr('Your data has not posted', 'Oops!');
  }

  // Post data
  public PostData() {
    // get data from child components's form
    // General component
    this.pocMain.country = this.generalchild.countryControl.value.name;
    this.pocMain.dayPart = this.generalchild.DaypartControl.value.name;
    this.pocMain.dayPartVersion = this.generalchild.DaypartVersionControl.value.name;

    // DriveThru component
    this.pocMain.dTtype = this.drivethruchild.DtTypesControl.value.name;
    this.pocMain.dtRemoteOT = this.drivethruchild.DTRemoteOTControl.value.name;
    this.pocMain.drinkMode = this.drivethruchild.DrinkModeControl.value.name;

    // FrontChild component
    this.pocMain.servMode = this.frontCounterchild.ServModeControl.value.name;
    this.pocMain.fcRemoteOT = this.frontCounterchild.FcRemoteOTControl.value.name;
    this.pocMain.fcDrinkMode = this.frontCounterchild.FCDrinkModeControl.value.name;

    // Kitchen component
    this.pocMain.operatingPlatform = this.kitchenchild.OperatingPlatformControl.value.name;
    this.pocMain.archDispenser = this.kitchenchild.ArchDispenserControl.value.name;
    this.pocMain.fryerWall = this.kitchenchild.FryerWallControl.value.name;

    // View Red line error messages when its invalid
   this.DisplayValidationMessage();

   if (this.ValidateGeneralComp() && this.ValidateDriveThruComp() && this.ValidateFrontCOunterComp()
        && this.ValidateKitchenComp())
    {
      console.log('Added');
       this.api.Post(this.pocMain).subscribe(
         res => {
        console.log(res);
        this.showSuccess();
        this.Refresh();
      },
      err => {
        console.log('Error occured');
        this.showError();
      });
    }else{
      console.log('Failed');
    }
  }

  public Refresh() {
    this.http.get(`https://localhost:44354/api/Main`).subscribe(data => {
      this.dataSource = data;
      console.log(data);
  });
  }

  // validate each components
 // General component
  public ValidateGeneralComp(){
    if(this.generalchild.countryControl.invalid || this.generalchild.DaypartControl.invalid
      || this.generalchild.DaypartVersionControl.invalid)
      {
        return false;
      }
      return true;
  }
  // Drivethru component
  public ValidateDriveThruComp() {
    if(this.drivethruchild.DtTypesControl.invalid || this.drivethruchild.DTRemoteOTControl.invalid
      ||this.drivethruchild.DrinkModeControl.invalid)
      {
        return false;
      }
      return true;
  }
  // FrontCounter component
  public ValidateFrontCOunterComp() {
    if(this.frontCounterchild.ServModeControl.invalid || this.frontCounterchild.FcRemoteOTControl.invalid
      ||this.frontCounterchild.FCDrinkModeControl.invalid)
      {
        return false;
      }
      return true;
  }
  // kitchen Component
  public ValidateKitchenComp() {
    if(this.kitchenchild.OperatingPlatformControl.invalid || this.kitchenchild.ArchDispenserControl.invalid
      || this.kitchenchild.FryerWallControl.invalid)
      {
        return false;
      }
      return true;
  }

  // Display Error Messages
  public DisplayValidationMessage(){

    if(this.generalchild.countryControl.invalid)
    {
      this.generalchild.countryControl.markAsTouched();
    }
  if(this.generalchild.DaypartControl.invalid){
    this.generalchild.DaypartControl.markAsTouched();
    }
  if(this.generalchild.DaypartVersionControl.invalid){
      this.generalchild.DaypartVersionControl.markAsTouched();
  }


  if(this.drivethruchild.DtTypesControl.invalid){
      this.drivethruchild.DtTypesControl.markAsTouched();
    }
  if(this.drivethruchild.DTRemoteOTControl.invalid){
      this.drivethruchild.DTRemoteOTControl.markAsTouched();
    }
  if(this.drivethruchild.DrinkModeControl.invalid){
    this.drivethruchild.DrinkModeControl.markAsTouched();
    }


    if(this.frontCounterchild.ServModeControl.invalid){
      this.frontCounterchild.ServModeControl.markAsTouched();
    }
  if(this.frontCounterchild.FcRemoteOTControl.invalid){
    this.frontCounterchild.FcRemoteOTControl.markAsTouched();
    }
  if( this.frontCounterchild.FCDrinkModeControl.invalid){
    this.frontCounterchild.FCDrinkModeControl.markAsTouched();
    }

    if(this.kitchenchild.OperatingPlatformControl.invalid){
      this.kitchenchild.OperatingPlatformControl.markAsTouched();
    }
  if(this.kitchenchild.ArchDispenserControl.invalid){
    this.kitchenchild.ArchDispenserControl.markAsTouched();
    }
  if( this.kitchenchild.FryerWallControl.invalid){
    this.kitchenchild.FryerWallControl.markAsTouched();
    }
  }

  // distribute dropdown data to all components
  public DistributeDataToChildComp() {
    this.api.GetDropDowns().subscribe(data => {
      this.dropdowns = data as any[];

      // General component
      this.generalchild.countries = this.dropdowns[0];
      this.generalchild.dayparts = this.dropdowns[1];
      this.generalchild.daypartsversions = this.dropdowns[2];

      // DriveThru component
      this.drivethruchild.DtTypes = this.dropdowns[3];
      this.drivethruchild.DrinkModes = this.dropdowns[4];
      this.drivethruchild.DtRemoteOTs = this.dropdowns[5];


      // FrontCounter component
      this.frontCounterchild.ServModes = this.dropdowns[6];
      this.frontCounterchild.FCDrinkModes = this.dropdowns[7];
      this.frontCounterchild.FcRemoteOTs = this.dropdowns[8];


      // Kitchen component
      this.kitchenchild.OperatingPlatforms = this.dropdowns[9];
      this.kitchenchild.FryerWalls = this.dropdowns[10];
      this.kitchenchild.ArchDispensers = this.dropdowns[11];

    });
  }
}

// main interface for path data to actual properties
interface PocMain {
  country;
  dayPart;
  dayPartVersion;
  dTtype;
  dtRemoteOT;
  drinkMode;
  servMode;
  fcRemoteOT;
  fcDrinkMode;
  operatingPlatform;
  archDispenser;
  fryerWall;
}

