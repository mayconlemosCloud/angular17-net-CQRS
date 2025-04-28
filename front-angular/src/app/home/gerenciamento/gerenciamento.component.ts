import { Component } from '@angular/core';
import { FrameComponent } from '../../components/frame/frame.component';
import { NgIf } from '@angular/common';
import { SalesComponent } from './Sales/Sales.component';
@Component({
  selector: 'app-gerenciamento',
  templateUrl: './gerenciamento.component.html', 
  imports: [FrameComponent, NgIf,SalesComponent],  
})
export class GerenciamentoComponent {
  showModal = false;
  tab: string = 'vendas';

  openModal() {
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }
}
