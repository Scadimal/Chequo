<script lang="ts">
    export let onClick: () => void;
    export let buttonText: string = "Button";
</script>

<input type="button" on:click={onClick} value={buttonText}>