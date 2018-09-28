import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import {ApiService} from '../Services/api.service';

@Component({
  selector: 'app-general-comp',
  templateUrl: './general-comp.component.html',
  styleUrls: ['./general-comp.component.css']
})
export class GeneralCompComponent implements OnInit {

    // craete form contoller with validation
  countryControl = new FormControl('', [Validators.required]);
  DaypartControl = new FormControl('', [Validators.required]);
  DaypartVersionControl = new FormControl('', [Validators.required]);

    // dropdown resourses
  dropdowns: any[];
  countries: Countries[];
  dayparts: DayParts[];
  daypartsversions: DayPartVersions[];
  constructor(public api: ApiService) { }

  ngOnInit() {
  }

}
interface Countries {
  id: number;
  name: string;
}
interface DayParts {
  id: number;
  name: string;
}

interface DayPartVersions {
  id: number;
  name: string;
}
