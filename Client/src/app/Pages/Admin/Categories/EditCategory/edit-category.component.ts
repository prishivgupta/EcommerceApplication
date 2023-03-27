import { Component } from '@angular/core';
import { CategoryService } from 'src/app/Services/Categories/category.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/Models/Category';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent {

  constructor(private categoryService: CategoryService, private location: Location, private route: ActivatedRoute) {}

  category: Category = {
    categoryId: 0,
    categoryName: ''
  };

  goBack(): void {
    this.location.back();
  }

  editCategory(category: Category): void {
    this.categoryService.updateCatgeory(category).subscribe(() => this.goBack());
  }

  getCategoryById(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.categoryService.getCategoryById(id).subscribe(category => {
      this.category.categoryId = category.categoryId,
      this.category.categoryName = category.categoryName
    });
  }

  ngOnInit(): void {
    this.getCategoryById()
  }

}
