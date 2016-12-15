require('./assets/css/default.css');//import the global css file

import Vue from 'vue'
import Home from './components/Home.vue'

import VueRouter from 'vue-router'
import VueResource from 'vue-resource'
Vue.use(VueResource)
Vue.use(VueRouter)

export var router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', component: Home},    
  ]
  }
);


new Vue({
  router,
  
}).$mount('#app')

