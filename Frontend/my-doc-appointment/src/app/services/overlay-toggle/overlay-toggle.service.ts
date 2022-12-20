import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OverlayToggleService {
  @Output() clickedEvent = new EventEmitter<number>();

  buttonClicked(n : number){
    this.clickedEvent.emit(n);
  }
}
