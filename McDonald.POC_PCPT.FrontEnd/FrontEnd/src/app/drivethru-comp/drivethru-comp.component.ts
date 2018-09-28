import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-drivethru-comp',
  templateUrl: './drivethru-comp.component.html',
  styleUrls: ['./drivethru-comp.component.css']
})
export class DrivethruCompComponent implements OnInit {

  // craete form contoller with validation
  DtTypesControl = new FormControl('', [Validators.required]);
  DTRemoteOTControl = new FormControl('', [Validators.required]);
  DrinkModeControl = new FormControl('', [Validators.required]);

  DtTypes: DtTypes[];
  DtRemoteOTs: DTRemoteOT[];
  DrinkModes: DrinkMode[];

  constructor() { }

  ngOnInit() {
  }


}

// patch data properties
interface DtTypes {
  name: string;
}
interface DTRemoteOT {
  name: string;
}

interface DrinkMode {
  name: string;
}
