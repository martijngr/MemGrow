import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import AddMemGrow from '../views/AddMemGrow';
import EditSeed from '../views/EditSeed';
import SearchSeed from '../views/SearchSeed';

Vue.use(VueRouter)

const parseProps = r => ({ id: parseInt(r.params.id) });

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    meta: {
      title: 'MemGrow - Home'
    },
  },
  {
    path: '/addMemGrow',
    name: 'AddMemGrow',
    component: AddMemGrow,
    meta: {
      title: 'MemGrow - Add seed'
    },
  },
  {
    path: '/editMemGrow/:id',
    name: 'EditMemGrow',
    component: EditSeed,
    props: parseProps,
    meta: {
      title: 'MemGrow - Edit seed'
    },
    // component: () =>
    //   import(/* webpackChunkName: "bundle.heroes" */ './views/hero-detail.vue'),
  },
  {
    path: '/search/:keyword',
    name: 'search',
    props: true,
    meta: {
      title: 'MemGrow - Search'
    },
    component: SearchSeed
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue'),
    meta: {
      title: 'MemGrow - About'
    },
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
