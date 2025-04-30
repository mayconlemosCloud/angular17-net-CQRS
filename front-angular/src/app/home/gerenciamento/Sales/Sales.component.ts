import { Component, OnInit } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
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
  isEditModalOpen = false;
  editData: any = null;
  products: { id: string; name: string; unitPrice: number }[] = [];

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.loadDatas();
    this.loadProducts(); // Load products when the component initializes
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

  loadProducts(): void {
    // Replace this with an API call if products are fetched from the backend
    this.products = [
        { id: '11111111-1111-1111-1111-111111111111', name: 'Budweiser Original', unitPrice: 10 },
        { id: '22222222-2222-2222-2222-222222222222', name: 'Budweiser Zero', unitPrice: 20 },
        { id: '33333333-3333-3333-3333-333333333333', name: 'Stella Artois Premium', unitPrice: 30 }
    ];
  }

  addItem(): void {
    if (this.item.productId && this.item.quantity > 0) {
      this.data.items.push({ ...this.item });
      this.item = { productId: '', quantity: 0 };
    }
  }

  removeItem(index: number): void {
    this.data.items.splice(index, 1);
  }

  openEditModal(data: any): void {
    this.isEditModalOpen = true;
    this.editData = { ...data, items: [...data.items] };
  }

  closeEditModal(): void {
    this.isEditModalOpen = false;
    this.editData = null;
  }

  onEditSubmit(): void {
    const updatedData = {
      id: this.editData.id,
      updatedAt: new Date().toISOString(),
      customerId: this.editData.customerId,
      branch: this.editData.branch,
      items: this.editData.items.map((item: { productId: string; quantity: number }) => ({
        productId: item.productId,
        quantity: item.quantity
      })),
      isCancelled: this.editData.isCancelled
    };
    // ...API call logic...
    this.closeEditModal();
  }

  onSubmit(): void {
    if (this.data.id) {
      this.salesService.update(this.data.id, this.data).subscribe(() => {
        this.loadDatas();
        this.data = { branch: '', customerId: '', items: [] };
      });
    } else {
      const newData = {
        createdAt: new Date().toISOString(),
        customerId: this.data.customerId,
        branch: this.data.branch,
        items: this.data.items.map((item: { productId: string; quantity: number }) => ({
          productId: item.productId,
          quantity: item.quantity
        })),
        isCancelled: false
      };
      // ...API call logic...
      this.salesService.create(newData).subscribe(() => {
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
