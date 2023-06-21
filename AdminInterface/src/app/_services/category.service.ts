import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../_models/category';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseurl = 'http://localhost:5115/api/';
  categories: Category[] = [];

  constructor(private http: HttpClient) {}

  getCategories(){
    if(this.categories.length > 0) return of(this.categories); 
    return this.http.get<Category[]>(this.baseurl + 'categories').pipe(
      map(categories => {
        this.categories = categories
        return categories;
      })
    )
  }
}
