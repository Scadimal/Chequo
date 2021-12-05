export async function getTranslated(amount) {
    const res = await fetch(`https://localhost:5001/NumberTranslator?credit=${amount}`);
    const text = await res.text();

    if (res.ok) {
        return text;
    } else {
        throw new Error(text);
    }
}