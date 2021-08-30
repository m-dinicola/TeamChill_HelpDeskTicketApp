import { TicketService } from './../services/ticket.service';
import { Component, Input, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-short-ticket',
  templateUrl: './short-ticket.component.html',
  styleUrls: ['./short-ticket.component.css']
})
export class ShortTicketComponent implements OnInit {
  @Input("ticket") ticketId:number;
  ticket:Ticket;
  constructor(private ticketService:TicketService) { }

  ngOnInit(): void {
    this.ticketService.getTicketById(this.ticketId).subscribe(data=>this.ticket=data);
  }

  getFormattedDate(dateString: string, format:string){
    const datePipe = new DatePipe('en-US');
    return datePipe.transform(new Date(dateString), format);
  }

}
