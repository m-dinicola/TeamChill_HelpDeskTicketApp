import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Logger {
log(msg: any): void {console.log(`[${new Date()}]: ${msg}`)}

error(msg: any): void {console.log(`[${new Date()}]: ${msg}`)}

warn(msg: any): void {console.log(`[${new Date()}]: ${msg}`)}
}
