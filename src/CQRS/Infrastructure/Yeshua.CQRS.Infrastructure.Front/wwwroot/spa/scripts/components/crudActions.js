import {
    initActionModal,
    showActionModal,
    loadActionContent
} from "./actionModal.js";

export async function setupCrudActions(metadata, getFormData) {



    await initActionModal();

    const btnSave = document.getElementById("btn-save");
    if (!btnSave) return;

    // evita duplicação
    if (document.getElementById("btn-action-audio")) return;

    // 🔥 teu IF simples
    //if (metadata?.endpoints?.read === "/Sessoes/ReadSessoes") {

    if (true) {

        const btn = document.createElement("button");
        btn.id = "btn-action-audio";
        btn.textContent = "🎙️ Gravar";
        btn.className = "bg-purple-600 hover:bg-purple-700 text-white px-4 py-2 rounded ml-2";

        btn.onclick = async () => {

            const data = getFormData ? getFormData() : {};

            showActionModal();

            await loadActionContent(
                "components/recording/audio.html",
                {
                    metaData: data
                }
            );
        };

        btnSave.parentElement.appendChild(btn);
    }
}