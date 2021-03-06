"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var airport_service_1 = require("../Service/airport.service");
var flight_service_1 = require("../Service/flight.service");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var global_1 = require("../shared/global");
var SearchComponent = (function () {
    function SearchComponent(fb, _airportService, _flightService) {
        this.fb = fb;
        this._airportService = _airportService;
        this._flightService = _flightService;
        this.indLoading = false;
        this.sortAscending = true;
    }
    SearchComponent.prototype.ngOnInit = function () {
        this.searchFrm = this.fb.group({
            FromAirport: ['', forms_1.Validators.required],
            ToAirport: ['', forms_1.Validators.required]
        });
        this.loadAirports();
    };
    SearchComponent.prototype.loadAirports = function () {
        var _this = this;
        this.indLoading = true;
        this._airportService.get(global_1.Global.BASE_AIRPORT_ENDPOINT)
            .subscribe(function (airports) {
            _this.fromAirports = airports;
            _this.toAirports = airports;
            _this.indLoading = false;
        }, function (error) { return _this.msg = error; });
    };
    SearchComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        this._flightService.post(global_1.Global.BASE_FLIGHT_ENDPOINT, formData._value)
            .subscribe(function (data) {
            _this.flights = data;
        }, function (error) {
            _this.msg = error;
        });
    };
    SearchComponent.prototype.fromSelected = function (data) {
        var _this = this;
        // Refresh the to options and filter out the selected from.
        this._airportService.get(global_1.Global.BASE_AIRPORT_ENDPOINT)
            .subscribe(function (airports) {
            _this.toAirports = airports.filter(function (to) {
                return to.Code !== data;
            });
        });
    };
    SearchComponent.prototype.sort = function (columnName) {
        if (!this.sortColumn || this.sortColumn !== columnName) {
            this.sortColumn = columnName;
            this.sortAscending = true;
        }
        else {
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
    };
    return SearchComponent;
}());
SearchComponent = __decorate([
    core_1.Component({
        selector: 'search',
        templateUrl: 'app/Components/search.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, airport_service_1.AirportService, flight_service_1.FlightService])
], SearchComponent);
exports.SearchComponent = SearchComponent;
//# sourceMappingURL=search.component.js.map