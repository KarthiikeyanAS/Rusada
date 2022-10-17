
import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};  

@Injectable()
export class RusadaService {

  private Urlstring: string = '';
  private _baseurl: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseurl = baseUrl;
  }

  public GetFlightDetails() {
    this.Urlstring = this._baseurl + 'rusada/GetFlightDetails';
    return this.http.get(this.Urlstring);
  }

  public AddNewFlight(data: any) {
    this.Urlstring = this._baseurl + 'rusada/AddNewFlight';
    return this.http.post(this.Urlstring, data, httpOptions);
  }

}

export class FlightDetails {
  public Id!: number;
  public Make!: string;
  public Model!: string;
  public Registration!: string;
  public Location!: string;
  public CreatedDate!: Date;
}
