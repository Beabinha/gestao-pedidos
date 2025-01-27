
import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';



@Injectable({

  providedIn: 'root'

})

export class PedidoService {



  private apiUrl = 'http://api.example.com/pedidos';  // URL da API



  constructor(private http: HttpClient) { }



  getPedidos(): Observable<any[]> {

    return this.http.get<any[]>(this.apiUrl);

  }

}
