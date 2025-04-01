document.addEventListener("DOMContentLoaded", function () {
    const chatbotContainer = document.getElementById("chatbot");
    const toggleButton = document.getElementById("toggle-chatbot");
    const closeButton = document.getElementById("close-chatbot");
    const sendButton = document.getElementById("send-message");
    const userInput = document.getElementById("user-message");
    const chatContent = document.getElementById("chat-content");

    toggleButton.addEventListener("click", () => chatbotContainer.style.display = "block");
    closeButton.addEventListener("click", () => chatbotContainer.style.display = "none");

    sendButton.addEventListener("click", async function () {
        const message = userInput.value.trim();
        if (!message) return;

        chatContent.innerHTML += `<div><strong>You:</strong> ${message}</div>`;
        userInput.value = "";

        const response = await fetch("/Gemini/GetChatbotResponse", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ message })
        });

        const data = await response.json();
        chatContent.innerHTML += `<div><strong>AI:</strong> ${data.reply}</div>`;
        chatContent.scrollTop = chatContent.scrollHeight;
    });
});
