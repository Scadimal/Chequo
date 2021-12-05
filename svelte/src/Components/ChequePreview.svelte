<script lang="ts">
    import { cheque, Cheque } from "../store";
	import { getTranslated } from "../numberTranslationService";

	/* Derived Values */
	$: englishNum = getTranslated($cheque.amount);
</script>

<div id="chequePreview">
    <h3>{`${$cheque.name} ${$cheque.surname}`}</h3>
    <h2>Bank Of Owen</h2>
    <!-- Wait for the API to return our numbers in english, then update the UI -->
    {#await englishNum then words}
        <p>THE SUM OF {words}</p>
	{:catch error}
        <!-- Some high quality error handling where we show the error but in RED -->
		<p style="color: red">{error.message}</p>
	{/await}
        <p style="border: 1px solid black">${Math.round($cheque.amount * 100)/100}</p>
        <p>{$cheque.memo}</p>
        <p style="text-align: right;">CHQ NR: <strong>{$cheque.id}</strong></p>
</div>

<style>
    #chequePreview{
        height: 300px;
        background-color: #f4f4f4;
        border-radius: 5px;
        min-width: 600px;
        max-width: 600px;
        display: flex;
        flex-wrap: wrap;
        flex-direction: column;
        padding: 0px 16px 0px 16px;
    }
    h3{
        margin-bottom: 0;
    }
    h2{
        margin-top: 0;
    }
    p{
        max-width: 50%;
    }
</style>