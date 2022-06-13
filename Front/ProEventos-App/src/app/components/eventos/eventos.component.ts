import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  modalRef?: BsModalRef

  public eventos : Evento[] = [];

  public eventosFiltrados : Evento[] = [];

  widthImg = 50;
  marginImg = 2;

  exibirImagem = false;

  private _filtroLista = '';

  public get filtroLista() {
    return this._filtroLista
  }

  public set filtroLista(value: string) {
    this._filtroLista = value

    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos
  }

  public filtrarEventos(filtrarPor: string) : Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase()

    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) != -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) != -1
    )
  }


  constructor(private eventoService: EventoService, private modalService: BsModalService, private toastr: ToastrService, private spinner: NgxSpinnerService) {}

  ngOnInit(): void {
    this.getEventos()

    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
    }, 3000);
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe(
      (_evento : Evento[]) => {
        this.eventos = _evento
        this.eventosFiltrados = this.eventos
      },
    )
  }

  public alterarImagem() : void{
    this.exibirImagem = !this.exibirImagem
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('O Evento foi deletado com Sucesso', 'Deletado!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
