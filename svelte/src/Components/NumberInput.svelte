<script lang="ts">
    export let value: number = 0;
    export let label: string = "numeric-input";
</script>
<main>
<label>{label}<input bind:value type="number"></label>
</main>

<style>
    input {
        margin-left: 10px;
    }
    label{
        display: flex;
        justify-content: space-between;
    }
</style>