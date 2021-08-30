import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  tickets: Ticket[] = [
    {
      ticketId: 3,
      title: 'Test',
      userEmail: 'test@tm.nt',
      complete: false,
      openDateTime: "1/1/2000"
    }
  ];

  constructor(private http: HttpClient) { }

  getTickets(): Observable<Ticket[]>{
    return this.http.get<Ticket[]>("https://localhost:5001/api/HDTicket");
  }

  getTicketById(id:number):Ticket{
    return this.tickets[id];
  }
}
