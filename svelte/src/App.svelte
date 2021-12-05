<script lang="ts">
	import Form from "./Components/Form.svelte";
	import ChequePreview from "./Components/ChequePreview.svelte";
</script>

<main>
	<Form/>
	<ChequePreview/>
</main>

<style>
	main{
		display: flex;
		flex-wrap:wrap;
		margin: 16px;
	}
</style>