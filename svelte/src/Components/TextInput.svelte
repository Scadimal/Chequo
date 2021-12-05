<script lang="ts">
    export let value: string = "";
    export let label: string = "form-input ";
</script>

<label>{label}<input bind:value></label>

<style>
    input {
        margin-left: 10px;
    }
    label{
        display: flex;
        justify-content: space-between;
    }
</style>