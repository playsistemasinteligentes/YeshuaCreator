window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaExtensions.pages['presenca-redacao'] = async () => {
    const page = await import('/Custon/Apps/Presenca/pages/redacao.js');
    await page.renderRedacao();
};
window.yeshuaExtensions.dashboard = window.yeshuaExtensions.pages['presenca-redacao'];
