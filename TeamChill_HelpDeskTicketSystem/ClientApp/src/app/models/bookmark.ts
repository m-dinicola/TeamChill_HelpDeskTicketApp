interface Bookmark
 {
   bookmarkId: number;
   ticketId: number;
   userEmail: string;
   ticket: Ticket;
   userEmailNavigation?: any;
 }
