<script>
  import { appState,authStore } from "../js";
  let user = {
    email: "",
    password: ""
  };
  appState.api();
</script>

<div class="bg-gray-500 w-full h-screen">

  {#if $appState.status == 'loading'}
    <div>Loading data...</div>
  {:else if $appState.status == 'success'}
    {JSON.stringify($appState, null, 2)}
  {:else if $appState.status == 'done'}
    {JSON.stringify($appState, null, 2)}
  {:else if $appState.status == 'error'}
    {JSON.stringify($appState, null, 2)}
  {:else}
    <form on:submit|preventDefault={() => authStore.login(user)}>
      <input bind:value={user.email} />
      <br />
      <hr />
      <input bind:value={user.password} />
      <br />
      <button type="submit">Login</button>
    </form>
  {/if}

</div>
