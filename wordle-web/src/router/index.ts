import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import GameView from '../views/WordleView.vue'
import GithubView from '../views/GithubView.vue'
import AboutView from '../views/AboutView.vue'
import PracticeView from '../views/PracticeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/game',
      name: 'game',
      component: GameView
    },
    {
      path: '/github',
      name: 'github',
      component: GithubView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },
    {
      path: '/practice',
      name: 'practice',
      component: PracticeView
    }
  ]
})

export default router
