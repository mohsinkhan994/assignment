import { Component, OnInit } from '@angular/core';
import { Client } from '../models/Client.model';
import { ClientService } from '../client.service';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  constructor(private clientService: ClientService) { }

  client = new Client();
  ClientResults = [];
  searchClients(client: Client) {
    this.clientService.searchClients(this.client).subscribe(response => {
        this.ClientResults = response;
      });
    }


  ngOnInit() {

  }

}
