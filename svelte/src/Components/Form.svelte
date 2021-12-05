<script lang="ts">
    import Button from "./Button.svelte";
    import TextInput from "./TextInput.svelte";
    import { cheque, Cheque } from "../store";
    import NumberInput from "./NumberInput.svelte";

    /* Props */
    export let value: string = "";
    export let newCheque: Cheque = {...$cheque};

    let preValue: number = newCheque.amount;
    $: newCheque.amount =  preValue || 0;

    // Function to update cheque details and generate a new cheque ID.
    function generateCheque () {
        newCheque.id = Math.floor(Math.random() * 10000000);
        cheque.set(newCheque);
    }
</script>

<form>
    <TextInput label="First Name:" bind:value={newCheque.name}/>
    <TextInput label="Last Name:" bind:value={newCheque.surname}/>
    <NumberInput label="Amount:" bind:value={preValue}/>
    <TextInput label="Memo:" bind:value={newCheque.memo}/>
    <Button onClick={generateCheque} buttonText="Generate Cheque"/>
</form>

<style>
    form{
        text-align: left;
        display: flex;
        flex-direction: column;
        min-width: 300px;
        height: 300px;
        margin-bottom: 30px;
        margin-right: 16px;
    }
</style>