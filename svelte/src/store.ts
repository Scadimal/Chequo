import { writable, Writable } from "svelte/store";

export interface Cheque{
    name?: string,
    surname?: string,
    amount?: number,
    date?: Date,
    memo?: string,
    id: number;
}

export let cheque: Writable<Cheque> = writable({
    name: "John",
    surname: "Doe",
    amount: 10,
    date: new Date(),
    memo: "Example Cheque",
    id: Math.floor(Math.random() * 10000000),
    loading: false
});	
