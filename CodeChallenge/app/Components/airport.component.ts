import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DropdownModule } from 'ngx-dropdown';
import { IAirport } from '../Models/airport';

@Component({
    selector: 'airport-dropdown',
    template: 'app/Components/search.component.html'
})

export class AirportComponent {
    @Input() title: string;
    airports: IAirport[];
    airport: IAirport;
    @Output() notify: EventEmitter<IAirport> = new EventEmitter<IAirport>();

    select() {

        this.notify.emit(this.airport);
    }
}