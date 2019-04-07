import { Injectable } from '@angular/core';
import { FilterService } from '../core/filter.service';
import { Board } from './interfaces/board';
import { PlaceToSearch } from '../core/enums/place-to-search.enum';

@Injectable({
  providedIn: 'root'
})
export class BoardFilterService extends FilterService {

  public applyTextFilter(item: Board): boolean {
    const nameContains = item.name.includes(this.textFilter);
    let descriptionContains = false;
    if (item.description !== undefined && item.description !== null) {
      descriptionContains = item.description.includes(this.textFilter);
    }

    switch (this.placeToSearchFilter) {
      case PlaceToSearch.Everywhere:
        return nameContains || descriptionContains;
      case PlaceToSearch.Name:
        return nameContains;
      case PlaceToSearch.Description:
        return descriptionContains;
    }
  }

  public applyAllFilters(item: Board): boolean {
    let textFilterResult = true;
    if (this.textFilter.length > 0) {
      textFilterResult = this.applyTextFilter(item);
    }
    return textFilterResult;
  }
}
