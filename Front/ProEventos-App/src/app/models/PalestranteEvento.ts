import { Evento } from "./Evento"
import { Palestrante } from "./Palestrante"

export interface PalestranteEvento {
  palestranteIde : number

  palestrante : Palestrante[]

  eventoId : number

  evento : Evento[]
}
