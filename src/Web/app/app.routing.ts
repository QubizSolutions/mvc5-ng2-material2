import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { MaterialComponent } from './material/material.component';
import { AuthorComponent } from './author/author.component';
import { AuthorDetailComponent } from './author/author-detail/author-detail.component';
import { ArticleDetailComponent } from './author/article-detail/article-detail.component';

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
        path: 'material',
        component: MaterialComponent
    },
    {
        path: 'authors',
        component: AuthorComponent
    },
    {
        path: 'author/:id',
        component: AuthorDetailComponent
    },
    {
        path: 'article/:id',
        component: ArticleDetailComponent
    }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { useHash: true });