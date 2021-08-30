interface Ticket {
  ticketId: number;
  openDateTime: string;
  title: string;
  type?: string;
  department?: string;
  complete: boolean;
  userEmail: string;
  userEmailNavigation?: any;
}
