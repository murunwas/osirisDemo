import { writable } from 'svelte/store';
import MovieApi from './apiService';

function createState() {
  const api = new MovieApi();
  const { set, subscribe, update } = writable({
    status: "loading",
    data:{}
  });


  function handleSuccess({ data }) {
    localStorage.setItem("token", data.token)
    update(x => ({ ...x, status: "success", ...data }))
  }
  function handleError(err) {
    update(x => ({ ...x, status: "error" }))
  }

  function updateState(data={}, status="loading") {
    update(x => ({ status, data }))
  }

  return {
    subscribe,
    api() {
      updateState();
      api.getMovies()
        .then(({data})=> updateState(data,"success"))
        .catch(err =>updateState(err,"error"))
    }

  }
}

function createAuthStore() {
  const api = new MovieApi();
  const { set, subscribe } = writable("");

  function handleSuccess({data}) {
    localStorage.setItem("token", data.token)
    set("done")
  }

  return{
    subscribe,
    login(data) {
      set("loading")
      api.login(data)
        .then(handleSuccess)
        .catch(set("error"))
    },
    register(data) {
      set("loading")
      api.register(data)
        .then(handleSuccess)
        .catch(set("error"))
    }
  }
}

export const authStore=createAuthStore();
export default createState();