import axios from "axios"


export default class MovieApi {
  constructor() {
    this.api = axios.create(
      {
        baseURL: "/api/v1/",
        headers: {
          "ApiKey": "MySecretApiKey",

        }
      }
    )
  }

  async getMovies() {
    console.log(localStorage.getItem("token"));
    return this.api.get("movie", {
      headers: {
        "Authorization": `bearer ${localStorage.getItem("token")}`
      }
    });
  }

  async getMovie(id = "") {
    return this.api.get("movie/" + id);
  }

  getSecret() {
    return this.api.get("Test/secret");
  }

  //Auth
  login(data = {}) {
    return this.api.post("auth/login", data);
  }

  register(data = {}) {
    return this.api.post("auth/login", data);
  }


}