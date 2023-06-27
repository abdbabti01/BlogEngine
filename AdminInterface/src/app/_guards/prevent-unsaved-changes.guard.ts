import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { EditCategoryComponent } from '../edit-category/edit-category.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<EditCategoryComponent> {
  canDeactivate(component:EditCategoryComponent): boolean {
    if(component.editform?.dirty){
      return confirm('they are unsaved changes, Are you sure you want to continue?');
    }
    return true;
  }
  
}
