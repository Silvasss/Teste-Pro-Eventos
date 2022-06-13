import { PalestranteEvento } from "./PalestranteEvento"
import { RedeSocial } from "./RedeSocial"

export interface Palestrante {
  id : number

  nome : string

  miniCurriculo : string

  redesSociais : RedeSocial[]

  imageURL : string

  telefone : string

  email : string

  palestrantesEventos : PalestranteEvento[]

}
