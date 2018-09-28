import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
@Component({
  selector: 'app-kitchen-comp',
  templateUrl: './kitchen-comp.component.html',
  styleUrls: ['./kitchen-comp.component.css']
})
export class KitchenCompComponent implements OnInit {

  // craete form contoller with validation
  OperatingPlatformControl = new FormControl('', [Validators.required]);
  ArchDispenserControl = new FormControl('', [Validators.required]);
  FryerWallControl = new FormControl('', [Validators.required]);

  // dropdown resourses
  OperatingPlatforms: OperatingPlatform[];
  ArchDispensers: ArchDispenser[];
  FryerWalls: FryerWall[];
  constructor() { }

  ngOnInit() {
  }

}

// patch data properties
interface OperatingPlatform {
  name: string;
}
interface ArchDispenser {
  name: string;
}

interface FryerWall {
  name: string;
}
