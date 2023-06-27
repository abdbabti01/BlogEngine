import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { EditPostComponent } from '../edit-post/edit-post.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChanges2Guard implements CanDeactivate<unknown> {
  canDeactivate(component:EditPostComponent): boolean {
    if(component.editform?.dirty){
      return confirm('they are unsaved changes, Are you sure you want to continue?');
    }
    return true;
  }
  
}
