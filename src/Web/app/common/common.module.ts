import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Services
import { HttpUtilityService } from './helpers/http-utility.service';

@NgModule({
    imports: [BrowserModule],
    declarations: [],
    exports: [],
    providers: [HttpUtilityService]
})
export class CommonModule { }
