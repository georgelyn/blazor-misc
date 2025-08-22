function copyToClipboard() {
    const text = document.getElementById("copy-text").textContent;
    navigator.clipboard.writeText(text)
        .then(() => {
            console.log("Text copied")
        }).catch(err => console.error("Copy failed", err));
}