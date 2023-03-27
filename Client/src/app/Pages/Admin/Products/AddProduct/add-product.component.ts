import { Component } from '@angular/core';
import { ProductService } from 'src/app/Services/Products/product.service';
import { Location } from '@angular/common';
import { Product } from 'src/app/Models/Product';
import { CategoryService } from 'src/app/Services/Categories/category.service';
import { Category } from 'src/app/Models/Category';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

  constructor(private productService: ProductService, private categoryService: CategoryService, private location: Location) {}

  product: Product = {
    productId: 0,
    productName: '',
    productDescription: '',
    productPrice: 0,
    productDiscountedPrice: 0,
    productQuantity: 0,
    rating: 0,
    productImages: '',
    categoryId: 0
  };

  categories: Category[] = [];

  productImages: string[] = [];

  goBack(): void {
    this.location.back();
  }

  addProduct(product: Product): void {
    this.productService.addProduct(product).subscribe(() => this.goBack());
  }

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe(categories => this.categories = categories);
  }

  ngOnInit(): void {
    this.getAllCategories();
  }

}

