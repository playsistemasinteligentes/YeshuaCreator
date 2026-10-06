window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.menu = window.yeshuaExtensions.menu || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.pages['contingencia-fiscal'] = async function openContingenciaFiscal() {
    const page = await import('/Custon/Apps/Fiscal/pages/contingencia-fiscal.js?v=20261006-paginacao-botoes04');
    await page.renderContingenciaFiscal();
};
