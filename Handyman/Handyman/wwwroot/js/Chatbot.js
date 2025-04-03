document.addEventListener("DOMContentLoaded", function () {
    const chatbotContainer = document.getElementById("chatbot");
    const toggleButton = document.getElementById("toggle-chatbot");
    const closeButton = document.getElementById("close-chatbot");
    const sendButton = document.getElementById("chatbot-send");
    const userInput = document.getElementById("chatbot-input");
    const chatContent = document.getElementById("chatbot-messages");

    toggleButton.addEventListener("click", () => chatbotContainer.style.display = "block");
    closeButton?.addEventListener("click", () => chatbotContainer.style.display = "none");

    function sendMessage() {
        const message = userInput.value.trim();
        if (!message) return;

        chatContent.innerHTML += `<div><strong>You:</strong> ${message}</div>`;
        userInput.value = "";

        fetch("/Gemini/Chat", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ prompt: message })
        })
            .then(response => response.json())
            .then(data => {
                chatContent.innerHTML += `<div><strong>AI:</strong> ${data.response}</div>`;

                // Auto-scroll to latest message
                chatContent.scrollTop = chatContent.scrollHeight;
            });
    }

    sendButton.addEventListener("click", sendMessage);

    userInput.addEventListener("keypress", function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            sendMessage();
        }
    });
});
