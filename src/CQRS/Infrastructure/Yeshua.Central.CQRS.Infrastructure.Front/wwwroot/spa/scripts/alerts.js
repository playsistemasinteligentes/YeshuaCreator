export function showAlert(message, type = "info", duration = 4000) {
    const container = document.getElementById("alertContainer");

    const baseStyles = "px-4 py-3 border text-sm shadow w-full transition transform";
    const typeStyles = {
        success: "border-l-4 border-green-600 bg-green-100 text-green-800",
        error: "border-l-4 border-red-600 bg-red-100 text-red-800",
        warning: "border-l-4 border-yellow-600 bg-yellow-100 text-yellow-800",
        info: "border-l-4 border-blue-600 bg-blue-100 text-blue-800",
    };

    const alert = document.createElement("div");
    alert.className = `
    ${baseStyles}
    ${typeStyles[type] || typeStyles.info}
    opacity-0 -translate-y-2
  `;
    const row = document.createElement('div');
    row.className = 'flex justify-between items-center';
    const text = document.createElement('span');
    text.textContent = message;
    text.style.whiteSpace = 'pre-line';
    const close = document.createElement('button');
    close.type = 'button'; close.textContent = '×';
    close.className = 'ml-4 font-bold text-xl leading-none';
    close.setAttribute('aria-label', 'Fechar mensagem');
    close.onclick = () => alert.remove();
    row.append(text, close); alert.append(row);

    container.appendChild(alert);

    // Animação de entrada
    requestAnimationFrame(() => {
        alert.classList.remove("opacity-0", "-translate-y-2");
        alert.classList.add("opacity-100", "translate-y-0");
    });

    // Auto remover
    if (duration) {
        setTimeout(() => {
            alert.classList.remove("opacity-100", "translate-y-0");
            alert.classList.add("opacity-0", "-translate-y-2");
            setTimeout(() => alert.remove(), 300);
        }, duration);
    }
}
