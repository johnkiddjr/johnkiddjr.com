import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import HomeView from '../views/HomeView.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
  },
  {
    path: '/about',
    name: 'about',
    component: () => import('../views/AboutView.vue'),
  },
  {
    path: '/contact',
    name: 'contact',
    component: () => import('../views/ContactView.vue'),
  },
  {
    path: '/articles',
    name: 'articles',
    component: () => import('../views/ArticleIndexView.vue'),
  },
  {
    path: '/articles/:slug',
    name: 'article',
    component: () => import('../views/ArticleView.vue'),
  },
  {
    path: '/objectives',
    name: 'objectives',
    component: () => import('../views/ObjectivesView.vue'),
  },
  {
    path: '/portfolio',
    name: 'portfolio',
    component: () => import('../views/PortfolioView.vue'),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
