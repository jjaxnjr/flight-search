import { AirportService } from '../Service/airport.service';
import { FlightService } from '../Service/flight.service';
import { Component, OnInit } from '@angular/core';
import { IFlightSearch } from '../Models/flight.search';
import { IFlight } from '../Models/flight';
import { IAirport } from '../Models/airport';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Rx';
import { Global } from '../shared/global';

@Component({
    selector: 'search',
    templateUrl: 'app/Components/search.component.html'
})

export class SearchComponent implements OnInit {
    fromAirports: IAirport[];
    toAirports: IAirport[];
    flightSearch: IFlightSearch;
    msg: string;
    indLoading: boolean = false;
    searchFrm: FormGroup;
    flights: IFlight[];

    constructor(private fb: FormBuilder, private _airportService: AirportService, private _flightService: FlightService) { }

    ngOnInit(): void {
        this.searchFrm = this.fb.group({
            FromAirport: ['', Validators.required],
            ToAirport: ['', Validators.required]
        });

        this.loadAirports();
    }

    loadAirports(): void {
        this.indLoading = true;
        this._airportService.get(Global.BASE_AIRPORT_ENDPOINT)
            .subscribe(airports => {
                this.fromAirports = airports;
                this.toAirports = airports;
                this.indLoading = false;
            },
            error => this.msg = <any>error
        );
    }

    onSubmit(formData: any) {
        this.msg = "";

        this._flightService.post(Global.BASE_FLIGHT_ENDPOINT, formData._value)
            .subscribe(data => {
                this.flights = data;
            },
            error => {
                this.msg = error;
            }
        );
    }

    fromSelected(formData: IFlightSearch): void {
        // Refresh the to options and filter out the selected from.
        this._airportService.get(Global.BASE_AIRPORT_ENDPOINT)
            .subscribe(airports => {
                this.toAirports = airports.filter(to => to.Code != formData.FromAirport);
            })
    }
}