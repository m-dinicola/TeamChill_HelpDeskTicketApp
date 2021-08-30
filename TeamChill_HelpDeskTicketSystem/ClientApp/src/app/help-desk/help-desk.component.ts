import { Logger } from '../services/logger.service';
import { TicketService } from './../services/ticket.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-help-desk',
  templateUrl: './help-desk.component.html',
  styleUrls: ['./help-desk.component.css'],
  providers: [TicketService, Logger]
})
export class HelpDeskComponent implements OnInit {
  tickets: Ticket[] = [];

  constructor(private ticketService:TicketService, private logger:Logger) {
   }

  ngOnInit(): void {
    this.ticketService.getTickets().subscribe(data => this.tickets = data);
    if(this.tickets){
      this.logger.log("Printed tickets from ticketService");
    }
    else{
      this.logger.warn("Array returned empty from ticketService");
    }
  }

  getFormattedDate(dateString: string, format:string){
    const datePipe = new DatePipe('en-US');
    return datePipe.transform(new Date(dateString), format);
  }




}
