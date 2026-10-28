window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaExtensions.pages['clinica-atendimentos'] = async () => {
    const page = await import('/Custon/Apps/Clinica/pages/atendimentos.js?v=20261028-clinica03');
    await page.renderClinicaAtendimentos();
};
window.yeshuaExtensions.dashboard = window.yeshuaExtensions.pages['clinica-atendimentos'];

window.yeshuaExtensions.crud = window.yeshuaExtensions.crud || {};
window.yeshuaExtensions.crud.replaceActions = ({ metadata, actionsContainer }) => {
    if (metadata?.entityName !== 'Sesoes') return false;
    if (document.getElementById('cli-open-atendimentos')) return true;
    const button = document.createElement('button');
    button.id = 'cli-open-atendimentos'; button.textContent = 'Abrir painel e gravar';
    button.className = 'px-4 py-2 rounded ml-2 bg-green-700 text-white';
    button.onclick = () => window.yeshuaExtensions.pages['clinica-atendimentos']();
    actionsContainer.append(button);
    return true;
};
