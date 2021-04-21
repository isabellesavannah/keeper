import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  },
  {
    path: '/profilePage/:id',
    name: 'ProfilePage',
    component: loadPage('ProfilePage'),
    beforeEnter: authGuard
  },
  {
    path: '/vaultPage/:id',
    name: 'VaultPage',
    component: loadPage('VaultPage'),
    beforeEnter: authGuard
  }
  // NOTE params means the path it takes
]

const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})

export default router
