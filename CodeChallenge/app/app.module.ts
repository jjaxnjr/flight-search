import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { FlightService } from './Service/flight.service';
import { AirportService } from './Service/airport.service';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { SearchComponent } from './components/search.component';



@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing],
    declarations: [AppComponent, SearchComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/'}, FlightService, AirportService],
    bootstrap: [AppComponent]
})

export class AppModule { }