<script lang="ts">
    export let onClick: () => void;
    export let buttonText: String = "Button";
</script>

<input type="button" on:click={onClick} value={buttonText}>