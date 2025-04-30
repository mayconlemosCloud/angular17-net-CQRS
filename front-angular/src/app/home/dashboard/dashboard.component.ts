import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SalesService } from '../../../services/SalesService';
import { map, firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  imports: [NgFor], 
})
export class DashboardComponent implements OnInit {
  orders: any[] = []; // Lista de pedidos
  totalSales: number = 0; // Total de vendas
  totalDiscounts: number = 0; // Total de descontos
  totalOrders: number = 0; // Número total de pedidos
  topProducts: { name: string; quantity: number }[] = [];
  topCustomers: { name: string; totalAmount: number }[] = [];
  topBranches: { branch: string; totalAmount: number }[] = [];

  constructor(private salesService: SalesService) {}

  async loadDatas(): Promise<void> {
    const response: any = await firstValueFrom(this.salesService.list());
    this.orders = response.data.data;

  }

  async ngOnInit(): Promise<void> {
    await this.loadDatas(); 
    this.calculateAggregates();
    this.calculateTopProducts();
    this.calculateTopCustomers();
    this.calculateTopBranches();
  }

  private calculateAggregates(): void {
    this.totalSales = this.orders.reduce((sum, order) => sum + order.totalAmount, 0);
    this.totalDiscounts = this.orders.reduce((sum, order) => sum + order.discount, 0);
    this.totalOrders = this.orders.length;
  }

  private calculateTopProducts(): void {
    const productMap: { [key: string]: { name: string; quantity: number } } = {};

    this.orders.forEach((order: { items: { productId: string; product: { name: string }; quantity: number }[] }) => {
      order.items.forEach((item: { productId: string; product: { name: string }; quantity: number }) => {
        if (!productMap[item.productId]) {
          productMap[item.productId] = { name: item.product.name, quantity: 0 };
        }
        productMap[item.productId].quantity += item.quantity;
      });
    });

    this.topProducts = Object.values(productMap)
      .sort((a, b) => b.quantity - a.quantity)
      .slice(0, 5); // Top 5 produtos
  }

  private calculateTopCustomers(): void {
    const customerMap: { [key: string]: { name: string; totalAmount: number } } = {};

    this.orders.forEach(order => {
      if (!customerMap[order.customerId]) {
        customerMap[order.customerId] = { name: order.customer.name, totalAmount: 0 };
      }
      customerMap[order.customerId].totalAmount += order.totalAmount;
    });

    this.topCustomers = Object.values(customerMap)
      .sort((a, b) => b.totalAmount - a.totalAmount)
      .slice(0, 5); // Top 5 clientes
  }

  private calculateTopBranches(): void {
    const branchMap: { [key: string]: number } = {};

    this.orders.forEach(order => {
      if (!branchMap[order.branch]) {
        branchMap[order.branch] = 0;
      }
      branchMap[order.branch] += order.totalAmount;
    });

    this.topBranches = Object.entries(branchMap)
      .map(([branch, totalAmount]) => ({ branch, totalAmount }))
      .sort((a, b) => b.totalAmount - a.totalAmount)
      .slice(0, 5); // Top 5 filiais
  }
}
