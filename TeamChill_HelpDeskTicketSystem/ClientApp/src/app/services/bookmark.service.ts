import { HttpClient, HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookmarkService {

  constructor(private http:HttpClient) { }

  getBookmarks(user:string): Observable<Bookmark[]>{
    return this.http.get<Bookmark[]>(`https://localhost:5001/api/Bookmark/${user}`);
  }

  setBookmark(user:string,ticket:number): Observable<Object>{
    return this.http.post(`https://localhost:5001/api/Bookmark/${user}`,ticket);
  }

  removeBookmark(user:string,ticket:number): Observable<Object>{
    return this.http.delete(`https://localhost:5001/api/Bookmark/${user}/${ticket}`);

  }


}
