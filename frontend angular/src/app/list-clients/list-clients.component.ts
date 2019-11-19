import { Component, OnInit, Input } from '@angular/core';
import { Client } from '../models/client.model';
import { ClientService } from '../client.service';


@Component({
  selector: 'app-list-clients',
  templateUrl: './list-clients.component.html',
  styleUrls: ['./list-clients.component.css']
})
export class ListClientsComponent implements OnInit {
  @Input() ClientResults ;


  constructor() { }

  ngOnInit() {
  }

}
