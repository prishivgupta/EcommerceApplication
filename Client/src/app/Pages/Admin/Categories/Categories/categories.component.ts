import { Component } from '@angular/core';
import { Category } from 'src/app/Models/Category';
import { CategoryService } from 'src/app/Services/Categories/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {

  constructor(private categoryService: CategoryService) {}

  categories: Category[] = [];
  id?: number;
  

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe(categories => this.categories = categories);
  }

  deleteCategory(id: number): void {
    this.categoryService.deleteCategory(id).subscribe(() => this.getAllCategories());
  }

  ngOnInit(): void {
    this.getAllCategories();
  }

}
