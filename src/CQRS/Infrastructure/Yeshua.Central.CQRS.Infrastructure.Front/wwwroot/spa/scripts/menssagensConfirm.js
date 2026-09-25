export function showConfirm(message, onConfirm, onCancel = null) {
    const container = document.getElementById("alertContainer");

    const box = document.createElement("div");
    box.className = `
    px-4 py-3 border-l-4 border-yellow-600 bg-yellow-100 text-yellow-800
    shadow-sm w-full text-sm
  `;

    box.innerHTML = `
    <div class="flex justify-between items-center">
      <span>${message}</span>
    </div>
    <div class="flex justify-end gap-2 mt-2">
      <button class="bg-red-600 text-white px-3 py-1 rounded hover:bg-red-700">Sim</button>
      <button class="bg-gray-300 px-3 py-1 rounded hover:bg-gray-400">Cancelar</button>
    </div>
  `;

    const [btnYes, btnCancel] = box.querySelectorAll("button");

    btnYes.onclick = () => {
        onConfirm();
        box.remove();
    };

    btnCancel.onclick = () => {
        if (onCancel) onCancel();
        box.remove();
    };

    container.appendChild(box);
}
