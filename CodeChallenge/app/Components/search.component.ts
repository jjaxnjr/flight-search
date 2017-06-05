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
    sortAscending: boolean = true;
    sortColumn: string;

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

    fromSelected(data: any): void {
        // Refresh the to options and filter out the selected from.
        this._airportService.get(Global.BASE_AIRPORT_ENDPOINT)
            .subscribe(airports => {
                this.toAirports = airports.filter(function (to) {
                    return to.Code !== data;
                })
            })
    }

    sort(columnName: string) {
        if (!this.sortColumn || this.sortColumn !== columnName) {
            this.sortColumn = columnName;
            this.sortAscending = true;
        } else {
            this.sortAscending = !this.sortAscending;
        }

        var reverse = this.sortAscending ? 1 : -1;

        switch (this.sortColumn) {
            case "Departs":
                this.flights.sort(function (a, b) {
                    var a1 = Date.parse("1/1/2017 " + a.Departs);
                    var b1 = Date.parse("1/1/2017 " + b.Departs);
                    return a1 - b1 * reverse;
                });
                break;
            case "Arrives":
                this.flights.sort(function (a, b) {
                    var a1 = Date.parse("1/1/2017 " + a.Arrives);
                    var b1 = Date.parse("1/1/2017 " + b.Arrives);
                    return a1 - b1 * reverse;
                });
                break;
            case "MainCabinPrice":
                this.flights.sort(function (a, b) {
                    var a1 = parseFloat(a.MainCabinPrice);
                    var b1 = parseFloat(b.MainCabinPrice);
                    return a1 - b1 * reverse;
                });
                break;
            case "FirstClassPrice":
                this.flights.sort(function (a, b) {
                    var a1 = parseFloat(a.FirstClassPrice);
                    var b1 = parseFloat(b.FirstClassPrice);
                    return a1 - b1 * reverse;
                });
                break;
        }
    }
}