import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { CategoryService } from 'src/app/Services/Categories/category.service';
import { Category } from 'src/app/Models/Category';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

  constructor(private categoryService: CategoryService, private location: Location) {}

  category: Category = {
    categoryId: 0,
    categoryName: ''
  };

  goBack(): void {
    this.location.back();
  }

  addCategory(category: Category): void {
    this.categoryService.addCategory(category).subscribe(() => this.goBack());
  }

}
