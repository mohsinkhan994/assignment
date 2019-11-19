import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Client } from './models/Client.model';

const httpheader = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};


@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private URL = 'https://localhost:44330/';
  constructor(private httpClient: HttpClient) { }

  searchClients(client: Client): Observable<Client[]> {
    let url = `${this.URL}search/`;
    // tslint:disable-next-line: triple-equals
    if (client.FirstName != undefined) {
      url = `${url}${client.FirstName}/`;
    }
    // tslint:disable-next-line: triple-equals
    if (client.LastName != undefined) {
      url = `${url}${client.LastName}`;
    }
    console.log(url);
    return this.httpClient.get<Client[]>(url, httpheader);
  }

}


 

