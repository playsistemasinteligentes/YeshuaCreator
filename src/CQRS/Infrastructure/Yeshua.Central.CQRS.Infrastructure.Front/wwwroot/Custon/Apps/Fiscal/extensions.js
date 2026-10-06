window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.menu = window.yeshuaExtensions.menu || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.pages['contingencia-fiscal'] = async function openContingenciaFiscal() {
    const page = await import('/Custon/Apps/Fiscal/pages/contingencia-fiscal.js?v=20261005-casos-recentes01');
    await page.renderContingenciaFiscal();
};
