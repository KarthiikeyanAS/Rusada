import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { Table } from 'primeng/table';
import { FlightDetails, RusadaService } from '../rusada.service';
import { OverlayPanel } from 'primeng/overlaypanel';

@Component({
  selector: 'app-rusada-listing',
  templateUrl: './rusada-listing.component.html',
  providers: [MessageService]
})
export class RusadaListingComponent {
  @ViewChild('dt') table!: Table;
  public gridData: FlightDetails[] = [];
  public gridView: FlightDetails[] = [];
  public mylist: FlightDetails[] = [];
  displayMaximizable!: boolean;
  addMaximizable!: boolean;
  public flightdetails: any = new FlightDetails();
  public newflightdetails: any = new FlightDetails();

  cols = [
    { field: 'id', header: 'Id' },
    { field: 'make', header: 'Make' },
    { field: 'model', header: 'Model' },
    { field: 'registration', header: 'Model' },
    { field: 'location', header: 'Location' },
    { field: 'createdDate', header: 'Date' }
  ];

  constructor(private router: Router, private serv: RusadaService, private messageService: MessageService, private primengConfig: PrimeNGConfig) {

  }
  ngOnInit() {
    this.primengConfig.ripple = true;
    this.getAircraftList();
  }

  public getAircraftList() {
    this.serv.GetFlightDetails().subscribe((result: any) => {
      if (result != null) {
        this.mylist = result;
        this.gridView = this.mylist;
        //this.gridData = this.mylist;
      }
    }, error => {
      alert("Looks like we're having some technical issues. Please try again later.");
    });
  }

  selectedFlight(item: any) {
    this.messageService.add({ severity: 'info', summary: 'Selected Model', detail: item.model });
  }

  showMaximizableDialog(item: any) {    
    this.displayMaximizable = true;
    this.flightdetails.Make = item.make;
    this.flightdetails.Model = item.model;
    this.flightdetails.Registration = item.registration;
    this.flightdetails.Location = item.location;
    this.flightdetails.CreatedDate = item.createdDate;
  }

  addMaximizableDialog() {
    this.newflightdetails = new FlightDetails();
    this.addMaximizable = true;
  }

  saveFlightDetails() {
    this.newflightdetails.Id = 0;
    this.serv.AddNewFlight(this.newflightdetails).subscribe((result: any) => {
      if (result != null) {
        alert(result);
        this.getAircraftList();
      } 
    }, error => {
      alert("Looks like we're having some technical issues. Please try again later.");
    });
    this.addMaximizable = false;
  }
}
