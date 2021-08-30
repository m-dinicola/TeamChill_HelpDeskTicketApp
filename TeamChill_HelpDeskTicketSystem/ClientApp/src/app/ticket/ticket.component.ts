import { TicketService } from './../services/ticket.service';
import { Component, OnInit } from '@angular/core';
import { Logger } from '../services/logger.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css'],
  providers: [Logger, TicketService]
})
export class TicketComponent implements OnInit {
  ticket: Ticket;

  constructor(private route:ActivatedRoute, private logger: Logger, private ticketService:TicketService) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    let id: number = Number(routeParams.get("id"));
    this.ticketService.getTicketById(id).subscribe(data=>this.ticket=data);
  }

}
