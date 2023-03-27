import { Component } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/Products/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {

  constructor(private productService: ProductService) {}

  products: Product[] = [];
  id?: number;
  

  getAllProducts(): void {
    this.productService.getAllProducts().subscribe(products => this.products = products);
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id).subscribe(() => this.getAllProducts());
  }

  ngOnInit(): void {
    this.getAllProducts();
  }

}

