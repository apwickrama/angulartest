import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
@Component({
  selector: 'app-frontcounter-comp',
  templateUrl: './frontcounter-comp.component.html',
  styleUrls: ['./frontcounter-comp.component.css']
})
export class FrontcounterCompComponent implements OnInit {

  // craete form contoller with validation
  ServModeControl = new FormControl('', [Validators.required]);
  FcRemoteOTControl = new FormControl('', [Validators.required]);
  FCDrinkModeControl = new FormControl('', [Validators.required]);

  ServModes: ServMode[];
  FcRemoteOTs: FcRemoteOT[];
  FCDrinkModes: FCDrinkMode[];
  constructor() { }

  ngOnInit() {
  }

}
interface ServMode {
  name: string;
}
interface FcRemoteOT {
  name: string;
}

interface FCDrinkMode {
  name: string;
}
