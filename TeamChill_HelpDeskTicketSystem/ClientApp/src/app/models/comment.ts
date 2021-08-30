interface Comment {
  commentId: number;
  commentDateTime: string;
  body: string;
  userEmail: string;
  ticketId: number;
  ticket: Ticket;
  userEmailNavigation?: any;
}
