import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable()

export class EventoService {

  constructor(private http: HttpClient) { }

  baseURL = "https://localhost:5001/Evento"

  public getEventos() : Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL)
  }

  public getEventosByTema(tema : string) : Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`)
  }

  public getEventoById(id : number) : Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`)
  }

}
