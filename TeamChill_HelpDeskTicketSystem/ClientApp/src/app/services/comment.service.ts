import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getComments(ticket:number):Observable<Comment[]>{
    return this.http.get<Comment[]>(`https://localhost:5001/api/HDComment/${ticket}`);
  }

}
