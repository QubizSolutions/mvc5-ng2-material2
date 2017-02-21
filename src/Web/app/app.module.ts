import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { Routing } from './app.routing';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';


//Modules
import { HomeModule } from './home/home.module';
import { MaterialModule as MyMaterialModule } from './material/material.module';
import { AuthorModule } from './author/author.module';

//Components
import { AppComponent } from './app.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        Routing,
        FormsModule,
        MaterialModule.forRoot(),
        HomeModule,
        MyMaterialModule,
        AuthorModule
    ],
    declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
