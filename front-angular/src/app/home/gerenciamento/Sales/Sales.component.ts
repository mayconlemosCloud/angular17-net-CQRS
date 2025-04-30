import { Component, OnInit } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { SalesService } from '../../../../services/SalesService';
import { map } from 'rxjs/operators';

interface SalesResponse {
  data: {
    data: any[];
    success: boolean;
    message: string;
    errors: any[];
  };
  success: boolean;
  message: string;
  errors: any[];
}

@Component({
  selector: 'app-sales',
  templateUrl: './Sales.component.html',
  imports: [FormsModule, NgFor],
})
export class SalesComponent implements OnInit {
  datas: any[] = [];
  data: any = { branch: '', customerId: '', items: [] };
  item: any = { productId: '', quantity: 0 };

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.loadDatas();
  }

  loadDatas(): void {
    this.salesService.list()
      .pipe(
        map((response: any) => response.data.data)
      )
      .subscribe((data: any[]) => {
        console.log(data);
        this.datas = data;
      });
  }

  addItem(): void {
    if (this.item.productId && this.item.quantity > 0) {
      this.data.items.push({ ...this.item });
      this.item = { productId: '', quantity: 0 };
    }
  }

  onSubmit(): void {
    if (this.data.id) {
      this.salesService.update(this.data.id, this.data).subscribe(() => {
        this.loadDatas();
        this.data = { branch: '', customerId: '', items: [] };
      });
    } else {
      this.salesService.create(this.data).subscribe(() => {
        this.loadDatas();
        this.data = { branch: '', customerId: '', items: [] };
      });
    }
  }

  edit(data: any): void {
    this.data = { ...data, items: [...data.items] };
  }

  delete(id: string): void {
    this.salesService.delete(id).subscribe(() => {
      this.loadDatas();
    });
  }
}
