import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MaterialComponent } from './material/material.component';
import { AuthorComponent } from './author/author.component';

const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'material',
        component: MaterialComponent
    },
    {
        path: 'author',
        component: AuthorComponent
    }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);