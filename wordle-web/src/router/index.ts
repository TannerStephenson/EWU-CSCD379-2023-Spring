import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '@/views/LeaderboardView.vue'
import WordOfTheDayView from '@/views/WordOfTheDayView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/wordle/:wordId',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/wordOfTheDay',
      name: 'Word of the Day',
      component: WordleView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardView
    },
    {
<<<<<<< HEAD
      path: '/',
      name: 'wordle',
      component: WordleView
=======
      path: '/wordoftheday',
      name: 'wordOfTheDay',
      component: WordOfTheDayView
>>>>>>> Assignment-5
    }
  ]
})

export default router
