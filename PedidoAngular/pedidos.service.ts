import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  private apiUrl = 'http://localhost:3000/api/pedidos';  // URL da API Node.js

  constructor(private http: HttpClient) { }

  getPedidos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
