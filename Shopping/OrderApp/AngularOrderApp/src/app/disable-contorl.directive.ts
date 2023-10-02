import { Directive, Input } from '@angular/core';
import { FormControl, NgControl } from '@angular/forms';

@Directive({
  selector: '[disableContorl]'
})
export class DisableContorlDirective {

  constructor(private ngcontrol: NgControl) { }
  @Input() set disableControl(condition: boolean) {
    var control = this.ngcontrol.control as FormControl;

    if (control) {
      if (condition)
        control.disable();
      else control.enable();


    }

  


  }

}
