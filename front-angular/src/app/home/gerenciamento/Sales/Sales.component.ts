import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DecimalPipe, CurrencyPipe } from '@angular/common';
import { SalesRepository } from '../../../../repositories/SalesRepository';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  //imports: [NgFor, FormsModule, NgIf, CurrencyPipe],
 // providers: [CurrencyPipe]
})
export class SalesComponent implements OnInit {
  constructor(
    private salesRepository: SalesRepository,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getSales();
  }

  getSales() {
    this.salesRepository.list().subscribe(
      (response) => {
        console.log(response);
        this.toastr.success('Vendas recuperadas com sucesso!');
      },
      (error) => {
        console.error(error);
        this.toastr.error('Erro ao recuperar vendas!');
      }
    );
  }

}
